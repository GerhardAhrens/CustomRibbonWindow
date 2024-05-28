//-----------------------------------------------------------------------
// <copyright file="SettingsLocation.cs" company="PTA GmbH">
//     Class: SettingsLocation
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024</date>
//
// <summary>
// Enum zur Festlegung der Speicherorts von Einstellungem (Applikation, User)
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core.BaseClass
{
    using System.ComponentModel;

    public enum SettingsLocation
    {
        [Description("No Location, default is 1")]
        None = 0,
        [Description("Settings are stored in the assembly directory")]
        AssemblyLocation = 1,
        [Description("Settings are stored in the ProgramData directory")]
        ProgramData = 2,
        [Description("Settings are stored in the Custom selected directory")]
        CustomLocation = 3
    }
}
