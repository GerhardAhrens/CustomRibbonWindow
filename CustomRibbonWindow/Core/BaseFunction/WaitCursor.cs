//-----------------------------------------------------------------------
// <copyright file="WaitCursor.cs" company="PTA GmbH">
//     Class: WaitCursor
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024</date>
//
// <summary>
// Class with WaitCursor Definition
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core
{
    using System;
    using System.Windows.Input;

    public class WaitCursor : IDisposable
    {
        private readonly Cursor previousCursor;

        public WaitCursor()
        {
            this.previousCursor = Mouse.OverrideCursor;

            Mouse.OverrideCursor = Cursors.Wait;
        }

        public WaitCursor(Cursor cursorTyp)
        {
            this.previousCursor = cursorTyp;

            Mouse.OverrideCursor = Cursors.Wait;
        }

        public Cursor CurrentCursor
        {
            get { return Mouse.OverrideCursor; }
        }

        public static void SetNormal()
        {
            Mouse.OverrideCursor = null;
        }

        public static void SetWait()
        {
            Mouse.OverrideCursor = Cursors.Wait;
        }

        public void Dispose()
        {
            Mouse.OverrideCursor = this.previousCursor;
        }
    }
}