
//-----------------------------------------------------------------------
// <copyright file="IEnumerationBase.cs" company="PTA GmbH">
//     Class: IEnumerationBase
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024</date>
//
// <summary>
// Interface zur Abstrakte Klasse zur Erstellung einer Basisklasse Enumeration
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core.BaseClass
{
    public interface IEnumerationBase
    {
        public int Key { get; }

        public string Value { get; }

        public string Description { get; }
    }
}
