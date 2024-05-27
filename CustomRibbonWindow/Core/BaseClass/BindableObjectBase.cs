//-----------------------------------------------------------------------
// <copyright file="BindableObjectBase.cs" company="PTA GmbH">
//     Class: BindableObjectBase
//     Copyright © PTA GmbH 2024
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>Gerhard Ahrens@pta.de</email>
// <date>27.05.2024</date>
//
// <summary>
// Klasse zum Binden eines Property im XAML Code an ein Control
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototypingNET.BaseClass
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BindableObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string property = "")
        {
            if (object.Equals(oldValue, newValue))
            {
                return;
            }

            oldValue = newValue;
            this.OnPropertyChanged(property);
        }

        protected virtual void OnPropertyChanged(string property)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
