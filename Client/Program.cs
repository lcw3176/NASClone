
using Client.ControllerSource;
using Client.ModelSource;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;


namespace Client
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bNew;
            Mutex mutex = new Mutex(true, "NASClient", out bNew);
           

            if (bNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                NASClient view = new NASClient();
                IModel model = new Model();
                IController controller = new Controller(view, model);

                Application.Run(view);

                mutex.ReleaseMutex();
            }

            else
            {
                MessageBox.Show("이미 실행중입니다.");
                Application.Exit();
            }
        }
    }
}
