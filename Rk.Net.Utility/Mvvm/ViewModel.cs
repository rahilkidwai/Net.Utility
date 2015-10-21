using System.ComponentModel;

namespace Rk.Net.Utility
{
    /// <summary>
    /// Base class for items that support property notification.
    /// </summary>
    /// <remarks>This class provides basic support for implementing the <see cref="INotifyPropertyChanged"/> interface and for marshalling execution to the UI thread.</remarks>
    public abstract class ViewModel : NotificationObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        protected ViewModel()
        {
        }
        #endregion

        #region Properties
        #endregion
    }
}