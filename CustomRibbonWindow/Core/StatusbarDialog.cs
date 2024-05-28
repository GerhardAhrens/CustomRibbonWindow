//-----------------------------------------------------------------------
// <copyright file="StatusbarDialog.cs" company="PTA GmbH">
//     Class: StatusbarDialog
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024</date>
//
// <summary>
// Statische Klasse zur Darstellung von Information in der Statuszeile eines Dialog Window
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core
{
    using System;

    public class StatusbarDialog
    {
        private static string notification = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarDialog"/> class.
        /// </summary>
        static StatusbarDialog()
        {
            NotificationChanged += (sender, e) => { return; };
        }

        public static string Notification
        {
            get { return notification; }
            set
            {
                notification = value;
                OnNotificationChanged(EventArgs.Empty);
            }
        }

        // Declare a static event representing changes to your static property
        public static event EventHandler NotificationChanged;

        // Raise the change event through this static method
        protected static void OnNotificationChanged(EventArgs e)
        {
            EventHandler handler = NotificationChanged;

            if (handler != null)
            {
                handler(null, e);
            }
        }
    }
}
