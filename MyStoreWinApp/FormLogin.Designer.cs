namespace MyStoreWinApp
{
    partial class FormLogin
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
            btnLogin = new System.Windows.Forms.Button();
            btnCancle = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnLogin.Location = new System.Drawing.Point(164, 199);
            btnLogin.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(92, 48);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "&Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancle
            // 
            btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancle.Location = new System.Drawing.Point(329, 199);
            btnCancle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new System.Drawing.Size(92, 48);
            btnCancle.TabIndex = 1;
            btnCancle.Text = "&Cancel";
            btnCancle.UseVisualStyleBackColor = true;
            btnCancle.Click += btnCancle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(36, 60);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 20);
            label1.TabIndex = 2;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(36, 133);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(140, 59);
            txtEmail.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(317, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(140, 131);
            txtPassword.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(317, 27);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 274);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancle);
            Controls.Add(btnLogin);
            Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            Name = "FormLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormLogin";
            FormClosing += FormLogin_FormClosing;
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
    }
}