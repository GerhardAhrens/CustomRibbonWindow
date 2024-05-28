//-----------------------------------------------------------------------
// <copyright file="DialogManager.cs" company="PTA GmbH">
//     Class: DialogManager
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024</date>
//
// <summary>
// Klasse für 
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;

    public sealed class DialogManager : IDisposable
    {
        private Window window = null;

        public DialogManager()
        {

            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            this.TopMost = false;
            this.WindowState = WindowState.Normal;
            this.ShowInTaskbar = false;
            this.ShowMinimizedButton = true;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.Opacity = 0.5;
        }

        public double Opacity { get; set; }

        public ResizeMode ResizeMode { get; set; }

        public WindowStyle WindowStyle { get; set; }

        public bool TopMost { get; set; }

        public WindowState WindowState { get; set; }

        public bool ShowMinimizedButton { get; set; }

        public bool ShowInTaskbar { get; set; }

        public WindowStartupLocation WindowStartupLocation { get; set; }

        public Point Location { get; set; }

        public string Title { get; set; }

        public ImageSource Icon { get; set; }

        public string WindowTooltip { get; set; }

        public object ResultContent { get; private set; }

        public object TagContent { get; set; }

        public bool? DialogResult { get; set; }

        public int ScreenCount
        {
            get
            {
                int count = System.Windows.Forms.Screen.AllScreens.Length;
                return count;
            }
        }

        public void Show<TWindow>(object viewModel, Window owner = null) where TWindow : Window, new()
        {
            try
            {
                if (owner == null)
                {
                    owner = Application.Current.Windows.Cast<Window>().SingleOrDefault(s => s.IsActive == true);
                }

                System.Windows.Forms.Screen currentScreen = System.Windows.Forms.Screen.AllScreens.FirstOrDefault<System.Windows.Forms.Screen>(p => p.Primary == true);

                SwitchAnimations.FadeOut(this.Opacity);

                this.window = new TWindow();
                this.window.WindowStartupLocation = this.WindowStartupLocation;
                this.window.ResizeMode = this.ResizeMode;
                this.window.Tag = this.TagContent;
                this.window.Owner = owner;
                this.window.Topmost = this.TopMost;
                this.window.ShowActivated = true;
                this.window.ShowInTaskbar = this.ShowInTaskbar;
                this.window.Title = this.Title == null ? typeof(TWindow).Name : this.Title;
                this.window.Icon = this.Icon;
                this.window.ToolTip = this.WindowTooltip;
                if (this.WindowStyle == WindowStyle.ThreeDBorderWindow)
                {
                    this.window.ResizeMode = ResizeMode.CanResizeWithGrip;
                }

                using (WaitCursor wc = new WaitCursor())
                {
                    this.window.DataContext = viewModel;
                }

                this.window.Show();
                this.ResultContent = this.window.Tag;
                this.TagContent = this.window.Tag;
                this.DialogResult = this.window.DialogResult;

                return;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SwitchAnimations.FadeIn();
            }
        }

        public void Show<TWindow>(Window owner = null) where TWindow : Window, new()
        {
            this.Show<TWindow>(null, owner = null);
        }

        public bool? ShowDialog<TWindow>(object viewModel) where TWindow : Window, new()
        {
            bool? result = null;

            try
            {
                SwitchAnimations.FadeOut(this.Opacity);

                this.window = new TWindow();
                this.window.WindowStartupLocation = this.WindowStartupLocation;
                this.window.Tag = this.TagContent;
                this.window.Topmost = this.TopMost;
                this.window.ShowActivated = true;
                this.window.ShowInTaskbar = this.ShowInTaskbar;
                this.window.Title = this.Title == null ? typeof(TWindow).Name : this.Title;
                this.window.Icon = this.Icon;
                this.window.ToolTip = this.WindowTooltip;
                this.window.WindowStyle = this.WindowStyle;

                using (WaitCursor wc = new WaitCursor())
                {
                    this.window.DataContext = viewModel;
                }

                result = this.window.ShowDialog();
                this.ResultContent = this.window.Tag;
                this.TagContent = this.window.Tag;
                this.DialogResult = this.window.DialogResult;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SwitchAnimations.FadeIn();
            }
        }

        public bool? ShowDialog<TWindow>(object viewModel, Window owner) where TWindow : Window, new()
        {
            bool? result = null;

            try
            {
                if (owner == null)
                {
                    owner = Application.Current.Windows.Cast<Window>().SingleOrDefault(s => s.IsActive == true);
                }

                System.Windows.Forms.Screen currentScreen = System.Windows.Forms.Screen.AllScreens.FirstOrDefault<System.Windows.Forms.Screen>(p => p.Primary == true);

                SwitchAnimations.FadeOut(this.Opacity);

                this.window = new TWindow();
                this.window.WindowStartupLocation = this.WindowStartupLocation;
                this.window.Tag = this.TagContent;
                this.window.Owner = owner;
                this.window.Topmost = this.TopMost;
                this.window.ShowActivated = true;
                this.window.ShowInTaskbar = this.ShowInTaskbar;
                this.window.Title = this.Title == null ? typeof(TWindow).Name : this.Title;
                this.window.Icon = this.Icon;
                this.window.ToolTip = this.WindowTooltip;
                this.window.WindowStyle = this.WindowStyle;
                if (this.WindowStyle == WindowStyle.ThreeDBorderWindow)
                {
                    this.window.ResizeMode = ResizeMode.CanResizeWithGrip;
                }

                using (WaitCursor wc = new WaitCursor())
                {
                    this.window.DataContext = viewModel;
                }

                result = this.window.ShowDialog();
                this.ResultContent = this.window.Tag;
                this.TagContent = this.window.Tag;
                this.DialogResult = this.window.DialogResult;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SwitchAnimations.FadeIn();
            }
        }

        public bool? ShowDialog<TWindow>(Window owner = null) where TWindow : Window, new()
        {
            return this.ShowDialog<TWindow>(null, owner);
        }

        public bool? ShowDialog<TWindow>() where TWindow : Window, new()
        {
            return this.ShowDialog<TWindow>(null, null);
        }

        public void Dispose()
        {
            this.window = null;
        }
    }
}