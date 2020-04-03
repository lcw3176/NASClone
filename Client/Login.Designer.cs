namespace Client
{
    partial class Login
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
            this.idTextbox = new System.Windows.Forms.TextBox();
            this.pwTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idTextbox
            // 
            this.idTextbox.Location = new System.Drawing.Point(67, 85);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.Size = new System.Drawing.Size(270, 25);
            this.idTextbox.TabIndex = 0;
            this.idTextbox.Enter += new System.EventHandler(this.idTextbox_Enter);
            // 
            // pwTextbox
            // 
            this.pwTextbox.Location = new System.Drawing.Point(67, 130);
            this.pwTextbox.Name = "pwTextbox";
            this.pwTextbox.PasswordChar = '*';
            this.pwTextbox.Size = new System.Drawing.Size(270, 25);
            this.pwTextbox.TabIndex = 1;
            this.pwTextbox.Enter += new System.EventHandler(this.pwTextbox_Enter);
            this.pwTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(29, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 100;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(18, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 23);
            this.label2.TabIndex = 200;
            this.label2.Text = "PW:";
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.loginButton.Location = new System.Drawing.Point(353, 85);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(114, 70);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Log-In";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 198);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pwTextbox);
            this.Controls.Add(this.idTextbox);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idTextbox;
        private System.Windows.Forms.TextBox pwTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginButton;
    }
}