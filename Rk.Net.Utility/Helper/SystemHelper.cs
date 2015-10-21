using System;
using System.Net;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class SystemHelper
    {
        /// <summary>
        /// Gets the machine ip. Returns machine name if unable to find IP address.
        /// </summary>
        /// <returns></returns>
        public static string GetMachineIP()
        {
            string value = null;
            try
            {
                IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());
                if (iphostentry != null && iphostentry.AddressList.Length > 0)
                {
                    value = iphostentry.AddressList[0].ToString();
                    foreach (IPAddress address in iphostentry.AddressList)
                    {
                        if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) //try to get IPV4 address
                        {
                            value = address.ToString();
                            break;
                        }
                    }
                }
            }
            finally
            {
                if (value == null) value = Environment.MachineName;//if no ip then use machine name
            }
            return value;
        }
    }
}