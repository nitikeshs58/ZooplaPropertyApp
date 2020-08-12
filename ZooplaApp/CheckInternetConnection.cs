using System.Runtime.InteropServices;

namespace ZooplaApp
{
    public class CheckInternetConnection
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetConnectedState(out int Description, int ReservedValue);
        public bool IsConnectedToInternet()
        {
            return InternetConnectedState(out int Desc, 0);
        }
    }
}
