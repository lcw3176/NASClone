using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class NAServer
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 3000));
            socket.Listen(1);

            Socket DSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            DSocket.Bind(new IPEndPoint(IPAddress.Any, 4000));
            DSocket.Listen(1);

            while (true)
            {
                Socket user = socket.Accept();

                Client client = new Client() { socket = user, dataSocket = DSocket };
                client.DataInit();

                Thread thread = new Thread(new ThreadStart(client.Run));
                thread.Start();
            }
        }
    }
}
