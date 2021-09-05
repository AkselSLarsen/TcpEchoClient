using System;
using System.IO;
using System.Net.Sockets;

namespace TcpEchoClient {
    public class Program {

        private static string host = "localhost";
        private static int port = 7;

        public static void Main() {
            EchoClientSocket socket = new EchoClientSocket(host, port);
            socket.Run();
        }
    }
}