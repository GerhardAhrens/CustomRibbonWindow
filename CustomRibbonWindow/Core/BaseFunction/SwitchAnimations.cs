//-----------------------------------------------------------------------
// <copyright file="SwitchAnimations.cs" company="Lifeprojects.de">
//     Class: SwitchAnimations
//     Copyright © Lifeprojects.de 2017
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>developer@lifeprojects.de</email>
// <date>11.08.2017</date>
//
// <summary>
//      Klasse zur Animation bei Wartezeiten
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;


    public static class SwitchAnimations
    {
        public static void FadeOut(FrameworkElement control, double opacity = 0.5)
        {
            if (control != null)
            {
                DoubleAnimation anim = new DoubleAnimation(1, opacity, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
                control.BeginAnimation(FrameworkElement.OpacityProperty, anim);
            }
        }

        public static void FadeOut(double opacity = 0.5)
        {
            FrameworkElement control = Application.Current.Windows.Cast<Window>().SingleOrDefault(s => s.IsActive == true);

            if (control != null)
            {
                DoubleAnimation anim = new DoubleAnimation(1, opacity, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
                control.BeginAnimation(FrameworkElement.OpacityProperty, anim);
            }
        }

        public static void FadeIn(FrameworkElement control)
        {
            if (control != null)
            {
                control.Opacity = 1;
                DoubleAnimation anim = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
                control.BeginAnimation(FrameworkElement.OpacityProperty, anim);
            }
        }

        public static void FadeIn()
        {
            FrameworkElement control = Application.Current.Windows.Cast<Window>().SingleOrDefault(s => s.IsActive == true);

            if (control != null)
            {
                control.Opacity = 1;
                DoubleAnimation anim = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
                control.BeginAnimation(FrameworkElement.OpacityProperty, anim);
            }
        }
    }
}