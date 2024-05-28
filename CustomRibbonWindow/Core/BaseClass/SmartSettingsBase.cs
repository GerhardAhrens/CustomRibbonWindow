//-----------------------------------------------------------------------
// <copyright file="SmartSettingsBase.cs" company="PTA GmbH">
//     Class: SmartSettingsBase
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024</date>
//
// <summary>
// Abstrakte Klassen zum Bearbeiten (Lesen, schreiben) von Settings Dateien
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core.BaseClass
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Base class for settings.
    /// </summary>
    public abstract class SmartSettingsBase : DisposableBase
    {
        private readonly IReadOnlyList<PropertyInfo> _properties;
        private readonly IReadOnlyDictionary<PropertyInfo, object> _defaults;

        /// <summary>
        /// Initializes an instance of <see cref="SmartSettingsBase" />.
        /// </summary>
        protected SmartSettingsBase(string filePath = "", string namePrefix = "Application")
        {
            this.NamePrefix = namePrefix;

            if (string.IsNullOrEmpty(filePath) == true)
            {
                this.SettingsLocation = SettingsLocation.ProgramData;
                string settingsPath = this.CurrentSettingsPath();
                string settingsName = $"{namePrefix}.{this.UserSettingsName()}";
                string settingsFile = Path.Combine(settingsPath, settingsName);
                this.FilePath = settingsFile;
            }
            else
            {
                this.SettingsLocation = SettingsLocation.AssemblyLocation;
                this.FilePath = filePath;
            }

            _properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.DeclaringType != typeof(SmartSettingsBase))
                .Where(p => p.CanRead && p.CanWrite)
                .Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() is null)
                .ToArray();

            // Default values for properties are initialized before the constructor is called,
            // so we can safely retrieve them here.
            _defaults = _properties.ToDictionary(p => p, p => p.GetValue(this));
        }

        public string Filename
        {
            get
            {
                string settingsPath = this.CurrentSettingsPath();
                string settingsName = $"{this.NamePrefix}.{this.UserSettingsName()}";
                string settingsFile = Path.Combine(settingsPath, settingsName);
                return settingsFile;
            }
        }

        public string Pathname
        {
            get
            {
                return $"{this.CurrentSettingsPath()}\\";
            }
        }

        public IReadOnlyList<PropertyInfo> GetProperties
        {
            get
            {
                return this._properties;
            }
        }

        public IReadOnlyDictionary<PropertyInfo, object> GetDefaults
        {
            get
            {
                return this._defaults;
            }
        }

        public int Count
        {
            get
            {
                return this._properties != null ? this._properties.Count : 0;
            }
        }

        private string NamePrefix { get; set; }

        private SettingsLocation SettingsLocation { get; set; }

        private string FilePath { get; }

        /// <summary>
        /// Resets the settings to their default values.
        /// </summary>
        public virtual void Reset()
        {
            foreach (var property in _properties)
            {
                property.SetValue(this, _defaults[property]);
            }
        }

        /// <summary>
        /// Saves the settings to file.
        /// </summary>
        public virtual void Save()
        {
            var dirPath = Path.GetDirectoryName(this.FilePath);
            if (!string.IsNullOrWhiteSpace(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            using var stream = File.Create(this.FilePath);
            using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
            {
                Indented = true
            });

            writer.WriteStartObject();

            foreach (var property in _properties)
            {
                var options = new JsonSerializerOptions();

                // Use custom converter if set
                if (property.GetCustomAttribute<JsonConverterAttribute>()?.ConverterType is { } converterType &&
                    Activator.CreateInstance(converterType) is JsonConverter converter)
                {
                    options.Converters.Add(converter);
                }

                // Use custom name if set
                writer.WritePropertyName(property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name);

                JsonSerializer.Serialize(writer, property.GetValue(this), property.PropertyType, options);
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Loads the settings from file.
        /// Returns true if the file was loaded, false if it didn't exist.
        /// </summary>
        public virtual bool Load()
        {
            try
            {
                using var stream = File.OpenRead(this.FilePath);
                using var document = JsonDocument.Parse(stream, new JsonDocumentOptions
                {
                    AllowTrailingCommas = true,
                    CommentHandling = JsonCommentHandling.Skip
                });

                foreach (var jsonProperty in document.RootElement.EnumerateObject())
                {
                    // Use custom name if set
                    var property = _properties
                        .FirstOrDefault(p => string.Equals(
                            p.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? p.Name,jsonProperty.Name, StringComparison.Ordinal
                    ));

                    if (property is null)
                    {
                        continue;
                    }

                    var options = new JsonSerializerOptions();

                    // Use custom converter if set
                    if (property.GetCustomAttribute<JsonConverterAttribute>()?.ConverterType is { } converterType &&
                        Activator.CreateInstance(converterType) is JsonConverter converter)
                    {
                        options.Converters.Add(converter);
                    }

                    property.SetValue(
                        this,
                        JsonSerializer.Deserialize(jsonProperty.Value.GetRawText(), property.PropertyType, options)
                    );
                }

                return true;
            }
            catch (Exception ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the settings file.
        /// Returns true if the file was deleted, false if it didn't exist.
        /// </summary>
        public virtual bool Delete()
        {
            try
            {
                if (File.Exists(this.FilePath))
                {
                    // This doesn't throw if the file doesn't exist, but
                    // does throw if the directory doesn't exist.
                    File.Delete(this.FilePath);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
            {
                return false;
            }
        }

        public bool IsExitSettings()
        {
            if (File.Exists(this.FilePath) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string CurrentSettingsPath()
        {
            string settingsPath = string.Empty;

            if (this.SettingsLocation == SettingsLocation.ProgramData)
            {
                string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                settingsPath = $"{rootPath}\\{this.ApplicationName()}\\Settings";
            }
            else
            {
                string rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                settingsPath = $"{rootPath}\\{this.ApplicationName()}\\Settings";
            }

            if (string.IsNullOrEmpty(settingsPath) == false)
            {
                try
                {
                    if (Directory.Exists(settingsPath) == false)
                    {
                        Directory.CreateDirectory(settingsPath);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return settingsPath;
        }

        private string ApplicationName()
        {
            string result = string.Empty;

            Assembly assm = Assembly.GetEntryAssembly();
            result = assm.GetName().Name;
            return result;
        }

        private string UserSettingsName()
        {
            string result = string.Empty;
            string username = Environment.UserName;

            result = $"{username}.Settings";

            return result;
        }
    }
}
