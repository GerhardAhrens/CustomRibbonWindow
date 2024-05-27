//-----------------------------------------------------------------------
// <copyright file="GeometryIcon.cs" company="NRM Netzdienste Rhein-Main GmbH">
//     Class: GeometryIcon
//     Copyright © NRM Netzdienste Rhein-Main GmbH 2023
// </copyright>
//
// <author>DeveloperName - NRM Netzdienste Rhein-Main GmbH</author>
// <email>DeveloperName@nrm-netzdienste.de</email>
// <date>07.12.2023 08:04:30</date>
//
// <summary>
// Klasse für 
// </summary>
//-----------------------------------------------------------------------


namespace CustomRibbonWindow.Core
{
    using CustomRibbonWindow.Core.BaseClass;

    public class GeometryIcon : EnumerationBase
    {
        public static readonly GeometryIcon WindowButtonMax = new IconWindowButtonMax();
        public static readonly GeometryIcon WindowButtonMin = new IconWindowButtonMin();
        public static readonly GeometryIcon WindowButtonRestore = new IconWindowButtonRestore();
        public static readonly GeometryIcon WindowButtonClose = new IconWindowButtonClose();

        /// <summary>
        /// Initializes a new instance of the <see cref="GeometryIcon"/> class.
        /// </summary>
        public GeometryIcon()
        {
        }

        public GeometryIcon(int value, string name, string description = null) : base(value, name, description)
        {
        }

        #region Class with Icon WindowButton Definition

        public class IconWindowButtonMax : GeometryIcon
        {
            public IconWindowButtonMax() : base(10, "M4,4H20V20H4V4M6,8V18H18V8H6Z")
            {
            }
        }

        public class IconWindowButtonMin : GeometryIcon
        {
            public IconWindowButtonMin() : base(10, "M20,14H4V10H20")
            {
            }
        }

        public class IconWindowButtonRestore : GeometryIcon
        {
            public IconWindowButtonRestore() : base(10, "M4,8H8V4H20V16H16V20H4V8M16,8V14H18V6H10V8H16M6,12V18H14V12H6Z")
            {
            }
        }

        public class IconWindowButtonClose : GeometryIcon
        {
            public IconWindowButtonClose() : base(10, "M13.46,12L19,17.54V19H17.54L12,13.46L6.46,19H5V17.54L10.54,12L5,6.46V5H6.46L12,10.54L17.54,5H19V6.46L13.46,12Z")
            {
            }
        }
        #endregion Class with Icon WindowButton Definition
    }
}
