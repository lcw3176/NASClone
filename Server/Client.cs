using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Client
    {
        public Socket socket { get; set; }
        public Socket dataSocket { get; set; }

        private DataManager dataManager;

        bool token = false;
        string userID;

        public Client()
        {
            
        }

        public void DataInit()
        {
            dataManager = new DataManager(socket, dataSocket);
        }



        public void Run()
        {
            try
            {

                while (!token)
                {
                    Login();
                }

                Console.WriteLine(userID + " --> 연결 시작됨");
                dataManager.userID = userID;

                while (token)
                {

                    string command = dataManager.SetData();

                    if (command == "ShowList")
                    {
                        dataManager.ShowList();
                    }

                    else if (command == "Download")
                    {
                        dataManager.Download();
                    }

                    else if(command == "Upload")
                    {
                        dataManager.Upload();
                    }

                    else if (command == "Delete")
                    {
                        dataManager.Delete();
                    }
                }
            }

            catch
            {
                Console.WriteLine(userID + " --> 연결 종료됨");
            }

        }

        private void Login()
        {
            // [0] id
            // [1] pw

            string path = @"D:\userData.txt";
            string[] confirm = File.ReadAllLines(path);


            string[] userInfo = dataManager.SetData().Split(',');

            string id = userInfo[0];
            string pw = userInfo[1];

            foreach (string i in confirm)
            {
                if (id == i.Split(',')[0] && pw == i.Split(',')[1])
                {
                    userID = id;
                    dataManager.SendData(true);
                    token = true;
                    return;
                }

            }

            dataManager.SendData(false);

        }

    }
}
