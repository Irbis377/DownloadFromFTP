namespace WF_DownloadFTP
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_serverUrl = new System.Windows.Forms.TextBox();
            this.pb_download = new System.Windows.Forms.ProgressBar();
            this.bt_download = new System.Windows.Forms.Button();
            this.lb_serverUrl = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.lb_login = new System.Windows.Forms.Label();
            this.lb_pass = new System.Windows.Forms.Label();
            this.lb_count = new System.Windows.Forms.Label();
            this.sfd_downloadedFile = new System.Windows.Forms.SaveFileDialog();
            this.cb_auth = new System.Windows.Forms.CheckBox();
            this.lb_time = new System.Windows.Forms.Label();
            this.bgw_download = new System.ComponentModel.BackgroundWorker();
            this.lb_speed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_serverUrl
            // 
            this.tb_serverUrl.Location = new System.Drawing.Point(10, 31);
            this.tb_serverUrl.Name = "tb_serverUrl";
            this.tb_serverUrl.Size = new System.Drawing.Size(447, 20);
            this.tb_serverUrl.TabIndex = 0;
            // 
            // pb_download
            // 
            this.pb_download.Location = new System.Drawing.Point(10, 138);
            this.pb_download.Name = "pb_download";
            this.pb_download.Size = new System.Drawing.Size(447, 23);
            this.pb_download.TabIndex = 7;
            // 
            // bt_download
            // 
            this.bt_download.Location = new System.Drawing.Point(463, 31);
            this.bt_download.Name = "bt_download";
            this.bt_download.Size = new System.Drawing.Size(116, 108);
            this.bt_download.TabIndex = 3;
            this.bt_download.Text = "Go!";
            this.bt_download.UseVisualStyleBackColor = true;
            this.bt_download.Click += new System.EventHandler(this.bt_download_Click);
            // 
            // lb_serverUrl
            // 
            this.lb_serverUrl.AutoSize = true;
            this.lb_serverUrl.Location = new System.Drawing.Point(7, 9);
            this.lb_serverUrl.Name = "lb_serverUrl";
            this.lb_serverUrl.Size = new System.Drawing.Size(60, 13);
            this.lb_serverUrl.TabIndex = 4;
            this.lb_serverUrl.Text = "Path to file:";
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(73, 57);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(169, 20);
            this.tb_login.TabIndex = 1;
            this.tb_login.Text = "login";
            this.tb_login.Visible = false;
            // 
            // tb_pass
            // 
            this.tb_pass.Location = new System.Drawing.Point(73, 80);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.Size = new System.Drawing.Size(169, 20);
            this.tb_pass.TabIndex = 2;
            this.tb_pass.Text = "password";
            this.tb_pass.UseSystemPasswordChar = true;
            this.tb_pass.Visible = false;
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.Location = new System.Drawing.Point(7, 60);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(58, 13);
            this.lb_login.TabIndex = 5;
            this.lb_login.Text = "Username:";
            this.lb_login.Visible = false;
            // 
            // lb_pass
            // 
            this.lb_pass.AutoSize = true;
            this.lb_pass.Location = new System.Drawing.Point(7, 83);
            this.lb_pass.Name = "lb_pass";
            this.lb_pass.Size = new System.Drawing.Size(56, 13);
            this.lb_pass.TabIndex = 6;
            this.lb_pass.Text = "Password:";
            this.lb_pass.Visible = false;
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.Location = new System.Drawing.Point(265, 100);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(32, 13);
            this.lb_count.TabIndex = 9;
            this.lb_count.Text = "bytes";
            // 
            // cb_auth
            // 
            this.cb_auth.AutoSize = true;
            this.cb_auth.Location = new System.Drawing.Point(265, 57);
            this.cb_auth.Name = "cb_auth";
            this.cb_auth.Size = new System.Drawing.Size(131, 17);
            this.cb_auth.TabIndex = 10;
            this.cb_auth.Text = "Need authentificaton?";
            this.cb_auth.UseVisualStyleBackColor = true;
            this.cb_auth.CheckedChanged += new System.EventHandler(this.cb_auth_CheckedChanged);
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Location = new System.Drawing.Point(265, 83);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(26, 13);
            this.lb_time.TabIndex = 11;
            this.lb_time.Text = "time";
            // 
            // bgw_download
            // 
            this.bgw_download.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_download_DoWork);
            // 
            // lb_speed
            // 
            this.lb_speed.AutoSize = true;
            this.lb_speed.Location = new System.Drawing.Point(265, 117);
            this.lb_speed.Name = "lb_speed";
            this.lb_speed.Size = new System.Drawing.Size(36, 13);
            this.lb_speed.TabIndex = 12;
            this.lb_speed.Text = "speed";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 173);
            this.Controls.Add(this.lb_speed);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.cb_auth);
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.lb_pass);
            this.Controls.Add(this.lb_login);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(this.lb_serverUrl);
            this.Controls.Add(this.bt_download);
            this.Controls.Add(this.pb_download);
            this.Controls.Add(this.tb_serverUrl);
            this.Name = "MainForm";
            this.Text = "Download from FTP";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_serverUrl;
        private System.Windows.Forms.ProgressBar pb_download;
        private System.Windows.Forms.Button bt_download;
        private System.Windows.Forms.Label lb_serverUrl;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.TextBox tb_pass;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.Label lb_pass;
        private System.Windows.Forms.Label lb_count;
        private System.Windows.Forms.SaveFileDialog sfd_downloadedFile;
        private System.Windows.Forms.CheckBox cb_auth;
        private System.Windows.Forms.Label lb_time;
        private System.ComponentModel.BackgroundWorker bgw_download;
        private System.Windows.Forms.Label lb_speed;
    }
}

