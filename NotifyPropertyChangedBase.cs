namespace UsefulTool
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Simple base implementation for <see cref="INotifyPropertyChanged"/>
    /// </summary>
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets a property and notifies <see cref="PropertyChanged"/> if the value changes.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="property">Existing property changing.</param>
        /// <param name="newValue">New value of property.</param>
        /// <param name="propertyName">Optional parameter to specify the name of the property.</param>
        protected void SetProperty<T>(ref T property, T newValue, [CallerMemberName] String propertyName = "")
        {
            bool propertyChanged = false;
            if (property == null && newValue != null)
            {
                propertyChanged = true;
            }
            else if (newValue == null && property != null)
            {
                propertyChanged = true;
            }
            else if (!property.Equals(newValue))
            {
                propertyChanged = true;
            }

            property = newValue;
            if (propertyChanged)
            {
                OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// Triggers <see cref="PropertyChanged"/>.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
