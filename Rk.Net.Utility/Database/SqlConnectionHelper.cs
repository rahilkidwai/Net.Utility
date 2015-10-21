using System;
using System.Collections.Generic;
using System.Data;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SqlConnectionHelper
    {
        #region Fields
        private readonly static object _syncRoot = new Object();//for locking purposee
        private static SqlConnectionHelper _instance;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the <see cref="SqlConnectionHelper" /> class.
        /// </summary>
        private SqlConnectionHelper()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the default singleton instance. A SetConnection call on default throws exception as 
        /// connections can not be set explicitly on default instance.
        /// </summary>
        /// <value>
        /// The default singleton instance.
        /// </value>
        public static SqlConnectionHelper Default
        {
            get
            {
                //double-check locking approach solves the thread concurrency problems while avoiding an exclusive lock in every call
                //to the Default property method. It also allows you to delay instantiation until the object is first accessed
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new SqlConnectionHelper();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}