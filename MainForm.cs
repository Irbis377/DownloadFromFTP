using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WF_DownloadFTP
{
    public partial class MainForm : Form
    {
        private string RemoteFtpPath;
        private string LocalDestinationPath;
        private bool auth = false;
        private long size = 0;
        private const int buffsize = 1024;
        public delegate void ChangeTextSafe(TimeSpan time, int position, int percent, double speed);
        public delegate void DownloadComplete();
      
        public MainForm()
        {
            InitializeComponent();
        }

        private void bt_download_Click(object sender, EventArgs e)
        {

            lb_count.Text = "";
            lb_time.Text = "";
            lb_speed.Text = "";
            //get address of file 
            RemoteFtpPath = tb_serverUrl.Text;

            if (string.IsNullOrEmpty(RemoteFtpPath))
            {
                MessageBox.Show("Check the path!");
                return;
            }

            //ask where need to save this file 
            sfd_downloadedFile  = new SaveFileDialog();
            sfd_downloadedFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd_downloadedFile.FilterIndex = 2;
            sfd_downloadedFile.RestoreDirectory = true;
            string[] name = RemoteFtpPath.TrimEnd().Split('/');
            sfd_downloadedFile.FileName = name[name.Length - 1];

            if (sfd_downloadedFile.ShowDialog() != DialogResult.OK)
            {
                  return; 
            }

            LocalDestinationPath = sfd_downloadedFile.FileName;
            
            if (string.IsNullOrEmpty(LocalDestinationPath))
            {
                MessageBox.Show("Check the LocalDestinationPath!");
                return;
            }


            if (auth)
            {
                if (string.IsNullOrEmpty(tb_login.Text) || string.IsNullOrEmpty(tb_pass.Text))
                {
                    MessageBox.Show("Check your username and password!");
                    return;
                }
            }

            this.Text = "Trying to get file size...";

            // Query size of the file to be downloaded
            WebRequest sizeRequest = WebRequest.Create(RemoteFtpPath);
            if (auth)
            {
                sizeRequest.Credentials = new NetworkCredential(tb_login.Text, tb_pass.Text);
            }
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            try
            {
                size = sizeRequest.GetResponse().ContentLength;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Text = "Download from FTP";
                return;
            }
           
            //set maximu value of progressbar
            pb_download.Invoke((MethodInvoker)(() => pb_download.Maximum = (int)size));

            pb_download.Visible = true;
            lb_count.Visible = true;
            bt_download.Enabled = false;

            try
            {
                //start async download 
                bgw_download.RunWorkerAsync();

              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                bt_download.Enabled = true;
            }

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            lb_count.Text = "";
            lb_time.Text = "";
            lb_speed.Text = "";
            pb_download.Visible = false;


        }

        private void cb_auth_CheckedChanged(object sender, EventArgs e)
        {
            //show textboxes for auth
            if (cb_auth.Checked == true)
            {
                auth = true;
                lb_login.Visible = true;
                lb_pass.Visible = true;
                tb_login.Visible = true;
                tb_pass.Visible = true;
            }
            else  //hide textboxes for auth
            {
                auth = false; 
                lb_login.Visible = false;
                lb_pass.Visible = false;
                tb_login.Visible = false;
                tb_pass.Visible = false;

                tb_login.Text = string.Empty;
                tb_pass.Text = string.Empty;
            }
        }

        private void bgw_download_DoWork(object sender, DoWorkEventArgs e)
        { 
            //create new delegate to show progress on label and for the end of downloading
            ChangeTextSafe safedelegate = ChangeTextOnLabels;
            DownloadComplete downloadComplete = EndOfDownload;
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(RemoteFtpPath);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //if we need authentfication - set credentials
            if (auth)
            {
                request.Credentials = new NetworkCredential(tb_login.Text, tb_pass.Text);
            }

            //need for show current speed 
            Stopwatch speedTimer = new Stopwatch();
            //need for show estimated time 
            TimeSpan elapsedTime;
            double currentSpeed = -1;
            double recivedBytes = 0; 
            
            using (Stream ftpStream = request.GetResponse().GetResponseStream())
            using (Stream fileStream = File.Create(LocalDestinationPath))
            {
                byte[] buffer = new byte[buffsize];
                int read;
                DateTime started = DateTime.Now;

                speedTimer.Start();
                while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                   
                    fileStream.Write(buffer, 0, read);
                    recivedBytes += read;

                    int position = (int)fileStream.Position;
                    //show progress on progressbar
                    pb_download.Invoke((MethodInvoker)(() => pb_download.Value = position));
                    //calculate transfer rate 
                    currentSpeed = position / 1024d / speedTimer.Elapsed.TotalSeconds; //kb/sec
                    
                    //calculate estimated time
                    elapsedTime = DateTime.Now - started;
                    TimeSpan estimatedTime = TimeSpan.FromSeconds((double)(size - recivedBytes) /*bytes left */ * elapsedTime.TotalSeconds / (double)recivedBytes);
                    //calculate how many percent we've already got
                    short percent = (short)((position * 100)/size);
                    //call the delegate to refresh progress on labels
                    this.Invoke(safedelegate, estimatedTime, position, percent, currentSpeed);
                }

                //we've received file
                speedTimer.Stop();
                this.Invoke(downloadComplete);
            }
        }

        public void ChangeTextOnLabels(TimeSpan estTime, int position, int percent, double speed)
        {
            lb_time.Text = estTime.ToString(); 
            lb_count.Text = position.ToString() + "/" + size.ToString() + " bytes" + " ("+percent.ToString()+"%)";
            lb_speed.Text = String.Format("{0} kb/s", speed.ToString("0.##")); 
            
        }

        public void EndOfDownload()
        {
            lb_time.Text = "Download finished!";
            lb_speed.Text = "";
            pb_download.Visible = false;
            bt_download.Enabled = true;

            this.Text = "Download from FTP";

        }
    }
}
