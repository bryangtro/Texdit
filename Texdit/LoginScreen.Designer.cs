using System.Drawing;

namespace Texdit
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.signInLabel = new System.Windows.Forms.Label();
            this.usernameLine = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.signUpLabel = new System.Windows.Forms.Label();
            this.closeForm = new System.Windows.Forms.PictureBox();
            this.signInButton = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closeForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signInButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // signInLabel
            // 
            this.signInLabel.AutoSize = true;
            this.signInLabel.Font = new System.Drawing.Font("Yu Gothic UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInLabel.ForeColor = System.Drawing.Color.Black;
            this.signInLabel.Location = new System.Drawing.Point(499, 45);
            this.signInLabel.Name = "signInLabel";
            this.signInLabel.Size = new System.Drawing.Size(120, 45);
            this.signInLabel.TabIndex = 2;
            this.signInLabel.Text = "Sign In";
            // 
            // usernameLine
            // 
            this.usernameLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usernameLine.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usernameLine.Location = new System.Drawing.Point(507, 271);
            this.usernameLine.Name = "usernameLine";
            this.usernameLine.Size = new System.Drawing.Size(390, 2);
            this.usernameLine.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Location = new System.Drawing.Point(507, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 2);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(492, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(413, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = " Start using Texdit and customise any text the ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(492, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 30);
            this.label3.TabIndex = 13;
            this.label3.Text = " way you want within seconds!";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordTextBox.BackColor = System.Drawing.Color.White;
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.passwordTextBox.Location = new System.Drawing.Point(507, 313);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(291, 28);
            this.passwordTextBox.TabIndex = 15;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.Click += new System.EventHandler(this.PasswordTextBox_Enter);
            this.passwordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            this.passwordTextBox.Leave += new System.EventHandler(this.PasswordTextBox_Leave);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(955, 594);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 28);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.AcceptsReturn = true;
            this.usernameTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.usernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usernameTextBox.BackColor = System.Drawing.Color.White;
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextBox.CausesValidation = false;
            this.usernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.usernameTextBox.Location = new System.Drawing.Point(507, 237);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(291, 28);
            this.usernameTextBox.TabIndex = 14;
            this.usernameTextBox.Text = "Username";
            this.usernameTextBox.Enter += new System.EventHandler(this.UsernameTextBox_Enter);
            this.usernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTextBox_KeyDown);
            this.usernameTextBox.Leave += new System.EventHandler(this.UsernameTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(88)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(569, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Don\'t have an account ? ";
            // 
            // signUpLabel
            // 
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signUpLabel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLabel.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.signUpLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.signUpLabel.Location = new System.Drawing.Point(739, 453);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(105, 21);
            this.signUpLabel.TabIndex = 20;
            this.signUpLabel.Text = "Sign Up Now";
            this.signUpLabel.Click += new System.EventHandler(this.signUpLabel_Click);
            // 
            // closeForm
            // 
            this.closeForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeForm.Image = ((System.Drawing.Image)(resources.GetObject("closeForm.Image")));
            this.closeForm.Location = new System.Drawing.Point(922, 12);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(32, 27);
            this.closeForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeForm.TabIndex = 18;
            this.closeForm.TabStop = false;
            this.closeForm.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.Color.White;
            this.signInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInButton.Image = ((System.Drawing.Image)(resources.GetObject("signInButton.Image")));
            this.signInButton.Location = new System.Drawing.Point(573, 387);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(271, 53);
            this.signInButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.signInButton.TabIndex = 17;
            this.signInButton.TabStop = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            this.signInButton.MouseLeave += new System.EventHandler(this.signInButton_MouseLeave);
            this.signInButton.MouseHover += new System.EventHandler(this.signInButton_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Texdit.Properties.Resources.Texdit_Logo;
            this.pictureBox3.Location = new System.Drawing.Point(48, 158);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(368, 252);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Texdit.Properties.Resources.main_color;
            this.pictureBox1.Location = new System.Drawing.Point(-767, -180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1242, 1105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(966, 601);
            this.Controls.Add(this.signUpLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeForm);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usernameLine);
            this.Controls.Add(this.signInLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texdit";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Shown += new System.EventHandler(this.loginScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.closeForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signInButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label signInLabel;
        private System.Windows.Forms.Panel usernameLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox signInButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.PictureBox closeForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label signUpLabel;
    }
}

