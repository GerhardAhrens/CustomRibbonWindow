//-----------------------------------------------------------------------
// <copyright file="SerializeFormatter.cs" company="PTA GmbH">
//     Class: SerializeFormatter
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024</date>
//
// <summary>
// Enum Klasse zu Auswahl der Art der Serilisation
// </summary>
//-----------------------------------------------------------------------


namespace CustomRibbonWindow.Core.BaseClass
{
    public enum SerializeFormatter : int
    {
        None = 0,
        Xml = 1,
        Text = 2,
        Json = 3
    }
}
