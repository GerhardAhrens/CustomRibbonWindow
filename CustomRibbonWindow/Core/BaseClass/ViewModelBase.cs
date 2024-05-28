//-----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="www.pta.de">
//     Class: ViewModelBase
//     Copyright © www.pta.de 2024
// </copyright>
//
// <author>Gerhard Ahrens - www.pta.de</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>28.05.2024 10:02:04</date>
//
// <summary>
// Basisklasse zur implementierung einer ViewModel Klasse
// </summary>
//-----------------------------------------------------------------------

namespace CustomRibbonWindow.Core.BaseClass
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        protected ViewModelBase()
        {
        }

        public bool IsModified { get; set; }
    }
}
