namespace CustomRibbonWindow.View
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaktionslogik für HomeCtrl.xaml
    /// </summary>
    public partial class HomeCtrl : UserControl
    {
        public HomeCtrl()
        {
            this.InitializeComponent();
            WeakEventManager<UserControl, RoutedEventArgs>.AddHandler(this, "Loaded", this.OnLoaded);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
