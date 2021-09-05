using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace TcpEchoClient {
    public class EchoClientSocket {
        public TcpClient Client;
        public StreamReader Reader;
        public StreamWriter Writer;

        public EchoClientSocket(string host, int port) {
            Console.WriteLine("This is the Client");

            Client = new TcpClient(host, port);
            NetworkStream ns = Client.GetStream();
            Reader = new StreamReader(ns);
            Writer = new StreamWriter(ns);
        }

        public void Run() {
            Boolean end = false;

            while (!end) {
                try {
                    string message = Console.ReadLine();
                    if (message.ToLower().Contains("/q")) {
                        end = true;
                        /*
                    } else if(message.ToLower().Contains("nr.")) {
                        PrintNumbers();
                        */
                    } else {
                        Writer.WriteLine(message);
                        Writer.Flush();

                        ReadLines();
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            Client.Close();
        }

        public void ReadLines() {
            Console.WriteLine("Receiving: " + Reader.ReadLine());

            if(Reader.Peek() >= 0) {
                ReadLines();
            }
        }

        /*
        private void PrintNumbers() {
            Task[] tasks = new Task[1000];

            for (int i = 0; i < tasks.Length; i++) {
                string message = "" + i;

                tasks[i] = new Task(() => {
                    Writer.WriteLine(message);
                    Writer.Flush();
                });
                tasks[i].Start();
            }

            for (int i = 0; i < tasks.Length; i++) {
                while (!tasks[i].IsCompleted) {
                    Thread.Sleep(10);
                }
            }
        }
        */
    }
}