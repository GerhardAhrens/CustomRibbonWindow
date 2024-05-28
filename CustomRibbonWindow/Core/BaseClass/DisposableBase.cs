//-----------------------------------------------------------------------
// <copyright file="DisposableBase.cs" company="PTA GmbH">
//     Class: DisposableBase
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024</date>
//
// <summary>
// Basisklasse für die Erstellung von Objekten die Dispose implementieren
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core.BaseClass
{
    using System;
    using System.Diagnostics;

    [DebuggerStepThrough]
    [Serializable]
    public abstract class DisposableBase : IDisposable
    {
        private bool disposedClass = false;

        ~DisposableBase()
        {
            this.Dispose(false);
        }

        public bool Disposed { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void DisposeManagedResources();

        protected abstract void DisposeUnmanagedResources();

        private void Dispose(bool disposing)
        {
            if (this.disposedClass == false)
            {
                if (disposing)
                {
                    this.DisposeManagedResources();
                }

                this.DisposeUnmanagedResources();

                this.disposedClass = true;
            }
        }
    }
}
