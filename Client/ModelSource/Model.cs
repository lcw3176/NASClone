using Client.SocketConnection;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Client.ModelSource
{
    public class Model : IModel
    {
        public event ModelHandler<Model> changed;
        public event ModelHandler<Model> add;
        public event ModelHandler<Model> progress;

        bool connection = true;

        public Model()
        {

        }

        public void Attach(IModelObserver observer)
        {
            changed += new ModelHandler<Model>(observer.ValueChanged);
            add += new ModelHandler<Model>(observer.ValueAdd);
            progress += new ModelHandler<Model>(observer.ProgressbarAdd);
        }

        public void valueCheck(bool isConnect)
        {
            Console.WriteLine("값 변경");
            connection = isConnect;
        }


        public void ShowList()
        {
            SocketManager.sendData("ShowList");
            string info = SocketManager.getData();

            changed.Invoke(this, new ModelEventArgs(info));
        }

        public void Download(string fileName)
        {
            string userPath;
            
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    userPath = folder.SelectedPath;
                    SocketManager.sendData("Download");
                    SocketManager.sendData(fileName);

                    string info = SocketManager.getData();
                    // 파일 다운목록 추가
                    add.Invoke(this, new ModelEventArgs(info));

                    long len = Convert.ToInt64(info.Split(',')[2]);

                    Thread thread = new Thread(() => Downloadthread(userPath, fileName, len));
                    thread.Start();            
                }
            }
        }

        public void Redownload(string fileName)
        {
            string userPath;

            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    userPath = folder.SelectedPath;
                    SocketManager.sendData("Download");
                    SocketManager.sendData(fileName);

                    string info = SocketManager.getData();
                    // 파일 다운목록 추가

                    long len = Convert.ToInt64(info.Split(',')[2]);

                    Thread thread = new Thread(() => Downloadthread(userPath, fileName, len));
                    thread.Start();
                }
            }
        }


        public void Upload()
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    string path = file.FileName;

                    FileInfo fileInfo = new FileInfo(path);
                    string fileName = fileInfo.Name;
                    long len = fileInfo.Length;

                    SocketManager.sendData("Upload");

                    string info = fileName + ',' + len.ToString();
                    SocketManager.sendData(info);

                    info = SocketManager.getData();

                    add.Invoke(this, new ModelEventArgs(info));

                    Thread thread = new Thread(() => Uploadthread(path, fileName));
                    thread.Start();

                }
            }
        }

        private void Downloadthread(string userPath, string fileName, long len)
        {
            Socket downloadSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            downloadSocket.Connect(new IPEndPoint(IPAddress.Loopback, 4000));


            using (FileStream fs = new FileStream(userPath + "\\" + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                BinaryWriter bw = new BinaryWriter(fs);

                long count = 0;
                long chunck = len / 100;
                int per = 0;
                long temp;

                byte[] receive = new byte[8192 * 64];

                while (count < len)
                {
                    int recv = downloadSocket.Receive(receive);
                    bw.Write(receive, 0, recv);
                    count += recv;
                    temp = count / chunck;

                    if (per == temp)
                    {
                        progress.Invoke(this, new ModelEventArgs(fileName + ',' + per.ToString()));
                        per++;
                    }

                }

                // 극소 용량 파일 처리를 위한 코드
                per = 100;
                progress.Invoke(this, new ModelEventArgs(fileName + ',' + per.ToString()));
                bw.Close();

            }

            downloadSocket.Close();
        }

        private void Uploadthread(string path, string fileName)
        {
            Socket uploadSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            uploadSocket.Connect(new IPEndPoint(IPAddress.Loopback, 4000));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                BinaryReader br = new BinaryReader(fs);
                byte[] send = new byte[8192 * 64];

                long count = 0;
                long chunck = fs.Length / 100;
                int per = 0;
                long temp;

                while (count < fs.Length)
                {
                    send = br.ReadBytes(send.Length);
                    count += uploadSocket.Send(send, 0, send.Length, SocketFlags.None);
                    temp = count / chunck;


                    if (per == temp)
                    {
                        progress.Invoke(this, new ModelEventArgs(fileName + ',' + per.ToString()));
                        per++;
                    }

                }

                per = 100;
                progress.Invoke(this, new ModelEventArgs(fileName + ',' + per.ToString()));

                br.Close();

                ShowList();
            }

            uploadSocket.Close();
        }

        public void delete(string fileName)
        {

            SocketManager.sendData("Delete");
            SocketManager.sendData(fileName);

            if (SocketManager.getData() == "Success")
            {
                ShowList();
            }

        }
    }
}
