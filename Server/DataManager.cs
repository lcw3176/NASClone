using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class DataManager
    {
        // 데이터 전송, 관리 클래스 

        private Socket socket;
        private Socket dataSocket;
        public string userID { get; set; }

        public DataManager(Socket client, Socket data)
        {
            socket = client;
            dataSocket = data;
        }



        public string SetData()
        {
            byte[] receive = new byte[1024];
            socket.Receive(receive);
            return Encoding.UTF8.GetString(receive).Trim('\0');
        }

        public void SendData(bool flag)
        {
            if (flag)
            {
                socket.Send(Encoding.UTF8.GetBytes("Success"));
            }

            else
            {
                socket.Send(Encoding.UTF8.GetBytes("Failed"));
            }
        }

        public void SendData(string data)
        {
            socket.Send(Encoding.UTF8.GetBytes(data));
        }

        public void SendData(byte[] data)
        {
            socket.Send(data);
        }

        public void ShowList()
        {

            string path = @"D:\" + userID;
            DirectoryInfo di = new DirectoryInfo(path);
            StringBuilder sb = new StringBuilder();

            if (di.GetFiles().Length == 0)
            {
                SendData("null");
            }

            foreach (var i in di.GetFiles())
            {
                sb.Append(i.Name);
                sb.Append(',');
            }

            SendData(sb.ToString());


        }

        public void Download()
        {

            string fileName = SetData();
            string path = @"D:\" + userID + "\\" + fileName;

            FileInfo file = new FileInfo(path);
            string size = GetFileSize(file.Length);
            string info = fileName + ',' + size + ',' + file.Length.ToString() + ',' + "Download";

            SendData(info);

            Thread thread = new Thread(() => DownloadThread(path));
            thread.Start();

        }


        private void DownloadThread(string path)
        {
            Socket tempSocket = dataSocket.Accept();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    BinaryReader br = new BinaryReader(fs);
                    byte[] send = new byte[8192 * 64];
                    int count = 0;

                    while (count < fs.Length)
                    {
                        send = br.ReadBytes(send.Length);
                        count += tempSocket.Send(send, 0, send.Length, SocketFlags.None);
                    }

                    br.Close();
                }
            }

            catch
            {
                return;
            }


        }

        public void Upload()
        {
            string[] fileinfo = SetData().Split(',');
            string fileName = fileinfo[0];
            long len = Convert.ToInt64(fileinfo[1]);
            string path = @"D:\" + userID + "\\" + fileName;

            string size = GetFileSize(len);
            string info = fileName + ',' + size + ',' + len.ToString() + ',' + "Upload";

            SendData(info);

            Thread thread = new Thread(() => UploadThread(path, len));
            thread.Start();
        }

        private void UploadThread(string path, long len)
        {
            Socket tempSocket = dataSocket.Accept();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    BinaryWriter bw = new BinaryWriter(fs);

                    long count = 0;

                    byte[] receive = new byte[8192 * 64];

                    while (count < len)
                    {
                        int recv = tempSocket.Receive(receive);
                        bw.Write(receive, 0, recv);
                        count += recv;

                    }
                    bw.Close();
                }
            }

            catch
            {
                return;
            }

        }

        public void Delete()
        {
            string fileName = SetData();
            string path = @"D:\" + userID + "\\" + fileName;
            File.Delete(path);
            SendData(true);

        }

        private string GetFileSize(long byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024)
                size = byteCount.ToString() + " Bytes";

            return size;
        }

    }
}
