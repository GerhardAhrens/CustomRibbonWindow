//-----------------------------------------------------------------------
// <copyright file="RibbonButtonExtensions.cs" company="NRM Netzdienste Rhein-Main GmbH">
//     Class: RibbonButtonExtensions
//     Copyright © NRM Netzdienste Rhein-Main GmbH 2023
// </copyright>
//
// <author>DeveloperName - NRM Netzdienste Rhein-Main GmbH</author>
// <email>DeveloperName@nrm-netzdienste.de</email>
// <date>28.10.2023 10:53:01</date>
//
// <summary>
// Extension Class for 
// </summary>
//-----------------------------------------------------------------------

namespace System.Windows.Controls
{
    using System.Windows;
    using System.Windows.Controls.Ribbon;

    using CustomRibbonWindow.Core;

    public static class RibbonButtonExtensions
    {

        public static void ChangeFontWeight(this object @this, UserControl uc)
        {
            if (@this is RibbonButton btn)
            {
                foreach (RibbonButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonButton>(uc))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonSplitButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonSplitButton>(uc))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                btn.FontWeight = FontWeights.Bold;
            }
            else if (@this is RibbonSplitButton btnSplitt)
            {
                foreach (RibbonSplitButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonSplitButton>(uc))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonButton>(uc))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonMenuItem rb in VisualTreeHelpers.FindVisualChildrens<RibbonMenuItem>(uc))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                btnSplitt.FontWeight = FontWeights.Bold;
            }
            else if (@this is RibbonMenuItem btnItem)
            {
                foreach (RibbonSplitButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonSplitButton>(uc))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonButton>(uc))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonMenuItem rb in VisualTreeHelpers.FindVisualChildrens<RibbonMenuItem>(uc))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                btnItem.FontWeight = FontWeights.Bold;
            }
        }

        public static void ChangeFontWeight(this object @this, Window window)
        {
            if (@this is RibbonButton btn)
            {
                foreach (RibbonButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonButton>(window))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonSplitButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonSplitButton>(window))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                btn.FontWeight = FontWeights.Bold;
            }
            else if (@this is RibbonSplitButton btnSplitt)
            {
                foreach (RibbonSplitButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonSplitButton>(window))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonButton>(window))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonMenuItem rb in VisualTreeHelpers.FindVisualChildrens<RibbonMenuItem>(window))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                btnSplitt.FontWeight = FontWeights.Bold;
            }
            else if (@this is RibbonMenuItem btnItem)
            {
                foreach (RibbonSplitButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonSplitButton>(window))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonButton rb in VisualTreeHelpers.FindVisualChildrens<RibbonButton>(window))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                foreach (RibbonMenuItem rb in VisualTreeHelpers.FindVisualChildrens<RibbonMenuItem>(window))
                {
                    rb.FontWeight = FontWeights.Normal;
                }

                btnItem.FontWeight = FontWeights.Bold;
            }
        }
    }
}
