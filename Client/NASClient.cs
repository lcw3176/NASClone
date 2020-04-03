using Client.ControllerSource;
using Client.ModelSource;
using Client.ViewSource;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class NASClient : MetroForm, IView, IModelObserver
    {

        IController controller;

        public event ViewHandler<IView> isConnect;

        public void SetController(IController cont)
        {
            controller = cont;
        }

        public void ValueChanged(IModel model, ModelEventArgs e)
        {
            string[] info = e.newval.Split(',');

            fileListview.Invoke(new Action(delegate ()
            {
                if (info[0] == "null")
                {
                    fileListview.Items.Clear();
                    return;
                }

                fileListview.Items.Clear();
                fileListview.BeginUpdate();

                for(int i = 0; i < info.Length - 1; i++)
                {
                    fileListview.Items.Add(info[i]).ImageIndex = 0;
                }
                    
                fileListview.EndUpdate();

            }));

        }

        public void ValueAdd(IModel model, ModelEventArgs e)
        {
            // [0] 파일이름
            // [1] 표기 용량
            // [2] 실제 용량
            // [3] 업/ 다운 구분

            string[] info = e.newval.Split(',');
            string fileName = info[0];
            string len = info[1];
            string status = info[3];

            ListViewItem item = new ListViewItem();
            MetroProgressBar progress = new MetroProgressBar();

            statusListview.BeginUpdate();

            item.SubItems[0].Text = fileName;
            item.SubItems.Add(len);
            item.SubItems.Add("");
            item.SubItems.Add(status);

            statusListview.Items.Add(item);

            Rectangle r = item.SubItems[2].Bounds;

            progress.SetBounds(r.X + 30, r.Y, r.Width - 30, r.Height);
            progress.Maximum = 100;
            progress.Minimum = 0;
            progress.Value = 0;
            progress.Parent = statusListview;
            progress.Visible = true;
            progress.Name = fileName;

            statusListview.EndUpdate();

        }

        public void ProgressbarAdd(IModel mode, ModelEventArgs e)
        {
            ListViewItem item;
            MetroProgressBar progressBar;
            // 0 파일 이름
            // 1 진행 상황

            string fileName = e.newval.Split(',')[0];
            int per = Convert.ToInt32(e.newval.Split(',')[1]);

            statusListview.Invoke(new Action(delegate ()
            {
                statusListview.BeginUpdate();

                item = statusListview.Items.Cast<ListViewItem>().FirstOrDefault(q => q.SubItems[0].Text == fileName);
                item.SubItems[2].Text = per.ToString();

                progressBar = statusListview.Controls.OfType<MetroProgressBar>().FirstOrDefault(q => q.Name == fileName);
                progressBar.Value = per;

                statusListview.EndUpdate();
            }));

        }

        public NASClient()
        {
            InitializeComponent();
        }

        private void Form_Shown(object sender, System.EventArgs e)
        {
            this.Hide();
            Login login = new Login();

            if (login.ShowDialog() == DialogResult.OK)
            {
                login.Close();
                this.Show();
                controller.Refresh();
                ChangePanel(filelistPanel);
            }
            
            else
            {
                login.Close();
                this.Close();
            }
        }

        private void filelistButton_Click(object sender, System.EventArgs e)
        {
            ChangeButtonColor(filelistButton);
            ChangePanel(filelistPanel);
        }

        private void ChangeButtonColor(Button button)
        {
            filelistButton.BackColor = Color.Transparent;
            statusButton.BackColor = Color.Transparent;
            uploadButton.BackColor = Color.Transparent;

            button.BackColor = Color.RoyalBlue;
        }

        private void ChangePanel(Panel panel)
        {
            filelistPanel.Hide();
            statusPanel.Hide();
            
            panel.Show();
        }

        private void fileLIstview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string fileName = fileListview.SelectedItems[0].Text;

                foreach (ListViewItem i in statusListview.Items)
                {
                    if (fileName == i.SubItems[0].Text)
                    {
                        return;
                    }
                }
                controller.ClickFile(fileName);
            }

            catch
            {
                return;
            }
            
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(statusButton);
            ChangePanel(statusPanel);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(uploadButton);
            controller.ClickUpload();
        }

        private void statusListview_ColumwChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = 150;
        }

        private void reDownloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (statusListview.SelectedItems[0].SubItems[2].Text == "100")
                {
                    MetroProgressBar progress = new MetroProgressBar();
                    string fileName = statusListview.SelectedItems[0].SubItems[0].Text;
                    statusListview.SelectedItems[0].SubItems[3].Text = "Download";
                    progress = statusListview.Controls.OfType<MetroProgressBar>().FirstOrDefault(q => q.Name == fileName);
                    progress.Value = 0;

                    controller.reDownload(fileName);
                }
            }

            catch
            {
                MessageBox.Show("다시 다운할 파일을 클릭 후 진행해 주세요.", "알림");
            }
           
         
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            controller.Refresh();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = fileListview.SelectedItems[0].Text;
                if(MessageBox.Show(fileName + "이 삭제됩니다." , "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.DeleteButton(fileName);
                    refreshButton_Click(sender, e);
                }

            }

            catch
            {
                MessageBox.Show("삭제할 파일을 클릭 후 진행해 주세요.", "알림");
            }

        }
    }
}
