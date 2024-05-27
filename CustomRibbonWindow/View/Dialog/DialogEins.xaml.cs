namespace CustomRibbonWindow.View.Dialog
{
    using System.Windows;

    using CustomRibbonWindow.ViewModel;

    /// <summary>
    /// Interaktionslogik für DialogEins.xaml
    /// </summary>
    public partial class DialogEins : Window
    {
        public DialogEins()
        {
            this.InitializeComponent();
            this.DataContext = new DialogEinsVM();
        }
    }
}
