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


namespace CustomRibbonWindow.GeneralBaseClass
{
    public class GeometryIcon : EnumerationBase
    {
        public static readonly GeometryIcon FolderAccount = new IconFolderAccount();
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

        public class IconFolderAccount : GeometryIcon
        {
            public IconFolderAccount() : base(10, "M15 14C16.33 14 19 14.67 19 16V17H11V16C11 14.67 13.67 14 15 14M15 13C16.11 13 17 12.11 17 11S16.11 9 15 9C13.9 9 13 9.89 13 11C13 12.11 13.9 13 15 13M22 8V18C22 19.11 21.11 20 20 20H4C2.9 20 2 19.11 2 18V6C2 4.89 2.9 4 4 4H10L12 6H20C21.11 6 22 6.9 22 8M20 8H4V18H20V8Z")
            {
            }
        }

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
