using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client.SocketConnection
{
    class SocketManager
    {
        // 싱글톤 패턴
        private static Socket socket;

        protected SocketManager()
        {

        }

        public static Socket getSocket()
        {
            if (socket == null)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

            if (!socket.Connected)
            {
                socket.Connect(new IPEndPoint(IPAddress.Loopback, 3000));
            }

            return socket;
        }

        public static void sendData(string data)
        {
            getSocket().Send(Encoding.UTF8.GetBytes(data));
        }

        public static string getData()
        {
            byte[] receive = new byte[1024];
            getSocket().Receive(receive);
            return Encoding.UTF8.GetString(receive).Trim('\0');
        }

        public static byte[] getByte()
        {
            byte[] receive = new byte[1024];
            getSocket().Receive(receive);
            return receive;
        }

        public static void closeSocket()
        {
            if (socket != null)
            {
                socket.Close();
            }
        }
    }
}
