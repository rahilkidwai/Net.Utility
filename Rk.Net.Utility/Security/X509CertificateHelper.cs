using System;
using System.Security.Cryptography.X509Certificates;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class X509CertificateHelper
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public X509CertificateHelper()
        {
        }
        #endregion 

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public X509Certificate2 FindBySerialNumber(string serialNumber)
        {
            X509Certificate2 certificate = null;

            //search in 'My' store first
            certificate = FindBySerialNumber(StoreName.My, StoreLocation.LocalMachine, serialNumber);
            if (certificate != null) return certificate;

            certificate = FindBySerialNumber(StoreName.My, StoreLocation.CurrentUser, serialNumber);
            if (certificate != null) return certificate;

            //not found so search in all stores
            foreach (StoreLocation storeLocation in (StoreLocation[])Enum.GetValues(typeof(StoreLocation)))
            {
                foreach (StoreName storeName in (StoreName[])Enum.GetValues(typeof(StoreName)))
                {
                    certificate = FindBySerialNumber(StoreName.My, StoreLocation.CurrentUser, serialNumber);
                    if (certificate != null) return certificate;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the certificate by serial number.
        /// </summary>
        /// <param name="storeName">Name of the store.</param>
        /// <param name="storeLocation">The store location.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <returns></returns>
        public X509Certificate2 FindBySerialNumber(StoreName storeName, StoreLocation storeLocation, string serialNumber)
        {
            X509Store store = null;
            X509Certificate2Collection certificates = null;

            store = new X509Store(storeName, storeLocation);

            store.Open(OpenFlags.MaxAllowed | OpenFlags.ReadOnly);
            certificates = store.Certificates.Find(X509FindType.FindBySerialNumber, serialNumber, false);
            //certificates = store.Certificates.Find(X509FindType.FindBySubjectName, "Samer Farha", false);
            if (certificates.Count > 0)
                return certificates[0];

            return null;
        }
        #endregion Methods

    }
}