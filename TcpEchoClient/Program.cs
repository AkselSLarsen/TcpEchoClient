using System;
using System.IO;
using System.Net.Sockets;

namespace TcpEchoClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This is the client");
            Console.WriteLine("Which message to send to the server");
            string message = Console.ReadLine();
            Console.WriteLine("Your message: " + message);
            TcpClient socket = new TcpClient("localhost", 7);
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);
            writer.WriteLine(message);
            writer.Flush();
            string messageReceived = reader.ReadLine();
            Console.WriteLine("Received: " + messageReceived);
            socket.Close();
        }
    }
}
