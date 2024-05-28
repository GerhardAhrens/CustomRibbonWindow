//-----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="www.pta.de">
//     Class: ViewModelBase
//     Copyright © www.pta.de 2024
// </copyright>
//
// <author>Gerhard Ahrens - www.pta.de</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>27.05.2024 10:19:22</date>
//
// <summary>
// Klasse für 
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core.BaseClass
{
    using System;
    using System.Runtime.CompilerServices;


    public static class BindableObjectProperty
    {
        public static BindableObjectProperty<T> Set<T>(Action<T, string> actionMethod, T value = default, [CallerMemberName] string propertyName = "")
        {
            var property = new BindableObjectProperty<T>(default(T), actionMethod, propertyName);
            property.Value = value;
            return property;
        }

        public static BindableObjectProperty<T> Set<T>(Action<T> actionMethod, T value = default, [CallerMemberName] string propertyName = "")
        {
            var property = new BindableObjectProperty<T>(default(T), actionMethod, propertyName);
            property.Value = value;
            return property;
        }

        public static BindableObjectProperty<T> Set<T>(T value = default, [CallerMemberName] string propertyName = "")
        {
            var property = new BindableObjectProperty<T>(default(T), propertyName);
            property.Value = value;
            return property;
        }
    }

    public class BindableObjectProperty<T> : BindableObjectBase
    {
        private T value;

        public BindableObjectProperty(T value, Action<T, string> actionMethod, [CallerMemberName] string propertyName = "")
        {
            this.ActionMethodB = actionMethod;
            this.value = value;
            this.Name = propertyName;

            if (actionMethod != null)
            {
                actionMethod(value, propertyName);
            }
        }

        public BindableObjectProperty(T value, Action<T> actionMethod, [CallerMemberName] string propertyName = "")
        {
            this.ActionMethodA = actionMethod;
            this.value = value;
            this.Name = propertyName;
        }

        public BindableObjectProperty(T value, [CallerMemberName] string propertyName = "")
        {
            this.value = value;
            this.Name = propertyName;
        }

        public BindableObjectProperty([CallerMemberName] string propertyName = "")
        {
            this.value = default(T);
            this.Name = propertyName;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.SetProperty(ref this.value, value);

                if (this.value != null)
                {
                    if (this.ActionMethodA != null)
                    {
                        this.ActionMethodA(value);
                    }

                    if (this.ActionMethodB != null)
                    {
                        this.ActionMethodB(value, this.Name);
                    }
                }
            }
        }

        public string Name { get; private set; }

        private Action<T> ActionMethodA { get; set; }

        private Action<T, string> ActionMethodB { get; set; }

        public static BindableObjectProperty<T> Set(T value, [CallerMemberName] string propertyName = "")
        {
            return new BindableObjectProperty<T>(value, propertyName);
        }

        public static BindableObjectProperty<T> Set([CallerMemberName] string propertyName = "")
        {
            return new BindableObjectProperty<T>(default(T), propertyName);
        }
    }
}
