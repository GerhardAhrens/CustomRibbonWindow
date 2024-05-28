//-----------------------------------------------------------------------
// <copyright file="DialogViewModelBase.cs" company="www.pta.de">
//     Class: DialogViewModelBase
//     Copyright © www.pta.de 2024
// </copyright>
//
// <author>Gerhard Ahrens - www.pta.de</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024 13:13:54</date>
//
// <summary>
// Klasse für 
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core.BaseClass
{
    using System.Windows;

    public abstract class DialogViewModelBase : ViewModelBase
    {
        internal Window AttachedWindow { get; set; }

        public void TryClose(bool? dialogResult = null)
        {
            try
            {
                if (AttachedWindow != null)
                {
                    AttachedWindow.DialogResult = dialogResult;
                    AttachedWindow.Close();
                }
            }
            catch { }
        }
    }
}
