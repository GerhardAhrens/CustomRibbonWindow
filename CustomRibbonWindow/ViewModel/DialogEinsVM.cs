//-----------------------------------------------------------------------
// <copyright file="DialogEinsVM.cs" company="www.pta.de">
//     Class: DialogEinsVM
//     Copyright © www.pta.de 2024
// </copyright>
//
// <author>Gerhard Ahrens - www.pta.de</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>27.05.2024 14:24:16</date>
//
// <summary>
// ViewModel Klasse für Dialog
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.ViewModel
{
    using System.Windows;
    using System.Linq;

    using CustomRibbonWindow.Core;
    using CustomRibbonWindow.Core.BaseClass;

    public class DialogEinsVM : ViewModelBase
    {
        public DelegateCommand DialogCloseCommand => new DelegateCommand(this.CloseDialog, this.CanCloseDialog);

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogEinsVM"/> class.
        /// </summary>
        public DialogEinsVM()
        {
            this.DialogTitle.Value = "DialogEins";
            this.LoadData();
        }

        public BindableObjectProperty<string> DialogTitle { get; set; } = new BindableObjectProperty<string>();


        private void LoadData()
        {
            StatusbarDialog.Notification = "Bereit";
            base.IsModified = false;
        }

        private void CloseDialog(object parameter)
        {
            Window currentWindow = Application.Current.Windows.Cast<Window>().Single(s => s.IsActive == true);
            if (currentWindow != null)
            {
                currentWindow.Close();
            }
        }

        private bool CanCloseDialog()
        {
            return true;
        }
    }
}
