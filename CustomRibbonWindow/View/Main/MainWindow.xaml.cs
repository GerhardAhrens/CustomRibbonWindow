namespace CustomRibbonWindow
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Ribbon;
    using System.Windows.Input;
    using System.Windows.Media;

    using CustomRibbonWindow.Core;
    using CustomRibbonWindow.Core.BaseClass;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
            WeakEventManager<RibbonWindow, MouseButtonEventArgs>.AddHandler(this, "MouseLeftButtonDown", this.OnWindowMouseLeftButtonDown);
            WeakEventManager<RibbonWindow, CancelEventArgs>.AddHandler(this, "Closing", this.OnMainWindowClosing);
            WeakEventManager<RibbonWindow, RoutedEventArgs>.AddHandler(this, "Loaded", this.OnMainWindowLoaded);
            WeakEventManager<Ribbon, RoutedEventArgs>.AddHandler(this.mainRibbon, "Loaded", this.OnRibbonLoaded);
            WeakEventManager<Button, RoutedEventArgs>.AddHandler(this.buttonMinimize, "Click", this.OnButtonMinimizeClick);
            WeakEventManager<Button, RoutedEventArgs>.AddHandler(this.buttonMaximize, "Click", this.OnButtonMaximizeClick);
            WeakEventManager<Button, RoutedEventArgs>.AddHandler(this.buttonClose, "Click", this.OnButtonCloseClick);

            /* Ribbon Menü Button */
            WeakEventManager<RibbonButton, RoutedEventArgs>.AddHandler(this.BtnExitApplication, "Click", this.OnButtonCloseClick);
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            StatusbarContent.Notification = "Bereit";
        }

        private void OnMainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Programm beenden?", this.Title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void OnRibbonLoaded(object sender, RoutedEventArgs e)
        {
            int childControlCount = VisualTreeHelper.GetChildrenCount((System.Windows.Controls.Ribbon.Ribbon)sender);

            if (childControlCount != 0)
            {
                int step = VisualTreeHelper.GetChildrenCount((System.Windows.Controls.Ribbon.Ribbon)sender);
                for (int i = 0; i < step; i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild((System.Windows.Controls.Ribbon.Ribbon)sender, i);

                    if (child is Grid)
                    {
                        ((Grid)child).RowDefinitions[0].Height = new GridLength(0);
                    }
                }
            }
        }

        private void OnButtonMinimizeClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void OnButtonMaximizeClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                this.buttonMinimize.Content = GeometryTools.GetPathGeometry(GeometryIcon.WindowButtonMin.Value, Colors.Black);
                this.buttonMinimize.ToolTip = "Window minimieren";
                this.buttonMaximize.Content = GeometryTools.GetPathGeometry(GeometryIcon.WindowButtonMax.Value, Colors.Black);
                this.buttonMaximize.ToolTip = "Window maximieren";
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                this.buttonMaximize.Content = GeometryTools.GetPathGeometry(GeometryIcon.WindowButtonRestore.Value, Colors.Black);
                this.buttonMaximize.ToolTip = "Window wiederherstellen";
            }
        }

        private void OnButtonCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnWindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ChangeFontWeightOnClick(object sender, RoutedEventArgs e)
        {
            sender.ChangeFontWeight(this);
        }
    }
}
