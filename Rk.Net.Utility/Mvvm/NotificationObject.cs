using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace Rk.Net.Utility
{
    /// <summary>
    /// Base class for items that support property notification.
    /// </summary>
    /// <remarks>This class provides basic support for implementing the <see cref="INotifyPropertyChanged"/> interface and for marshalling execution to the UI thread.</remarks>
    [DataContract(Namespace = "")]
    public abstract class NotificationObject : INotifyPropertyChanged
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationObject"/> class.
        /// </summary>
        protected NotificationObject()
        {
        }
        #endregion

        #region Events
        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise an event")]
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentException("Null or invalid value supplied.", "propertyName");
            CheckPropertyExists(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises this object's PropertyChanged event for each of the properties.
        /// </summary>
        /// <param name="propertyNames">The properties that have a new value.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise an event")]
        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null) throw new ArgumentNullException("propertyNames");
            foreach (var name in propertyNames)
            {
                CheckPropertyExists(name);
                RaisePropertyChanged(name);
            }
        }

        /// <summary>
        /// Checks the property exists.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void CheckPropertyExists(string propertyName)
        {
            Type type = GetType();
            if (type.GetProperty(propertyName) == null)
            {
                Debug.Assert(false, string.Format(CultureInfo.InvariantCulture, "Invalid property '{0}.{1}'", type.FullName, propertyName));
            }
        }
        #endregion
    }
}