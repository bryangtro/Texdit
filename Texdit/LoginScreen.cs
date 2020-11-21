using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texdit
{
    public partial class LoginScreen : Form
    {
        // Backup of original Image no reduced transparency
        private Image temp;
        private List <UserAccount> userAccountList = new List <UserAccount>();

        public LoginScreen()
        {
            InitializeComponent();
            temp = signInButton.Image;
            LoadUserAccounts("login.txt");
        }

        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            Focus(usernameTextBox, "Username");
        }

        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            Defocus(usernameTextBox, "Username");
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            Focus(passwordTextBox, "Password");
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            Defocus(passwordTextBox, "Password");
        }

        // When user type a text into the textbox, make the textbox empty and change the properties to make it more visible
        private void Focus(TextBox textBox, string text)
        {
            string hexColor = "#333258";

            Color myColor = System.Drawing.ColorTranslator.FromHtml(hexColor);
            if (textBox.Text == text)
            {
                textBox.Text = string.Empty;
                textBox.Font = new Font("Segoe UI Light", 15.75F);
                textBox.ForeColor = myColor;
                if (text == "Password")
                    textBox.PasswordChar = '\u25cf';
            }
        }

        // When user leaves the textbox with 0 input display the current text context along with its propertise
        private void Defocus(TextBox textBox, string text)
        {
            if (textBox.TextLength == 0)
            {
                textBox.Text = text;
                textBox.Font = new Font("Segoe UI Light", 15.75F);
                textBox.ForeColor = Color.Gray;
                if (text == "Password")
                    textBox.PasswordChar = '\u0000';

            }
        }



        private void signInButton_MouseHover(object sender, EventArgs e)
        {
            Image tempImage;
            tempImage = ChangeImageOpacity(signInButton.Image, 0.8);
            signInButton.Image = tempImage;

        }

        public static Image ChangeImageOpacity(Image originalImage, double opacity)
        {
            const int bytesPerPixel = 4;
            try
            {
                if ((originalImage.PixelFormat & PixelFormat.Indexed) == PixelFormat.Indexed)
                {
                    // Cannot modify an image with indexed colors
                    return originalImage;
                }

                Bitmap bmp = (Bitmap)originalImage.Clone();

                // Specify a pixel format.
                PixelFormat pxf = PixelFormat.Format32bppArgb;

                // Lock the bitmap's bits.
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);

                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                // This code is specific to a bitmap with 32 bits per pixels 
                // (32 bits = 4 bytes, 3 for RGB and 1 byte for alpha).
                int numBytes = bmp.Width * bmp.Height * bytesPerPixel;
                byte[] argbValues = new byte[numBytes];

                // Copy the ARGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, argbValues, 0, numBytes);

                // Manipulate the bitmap, such as changing the
                // RGB values for all pixels in the the bitmap.
                for (int counter = 0; counter < argbValues.Length; counter += bytesPerPixel)
                {
                    // argbValues is in format BGRA (Blue, Green, Red, Alpha)

                    // If 100% transparent, skip pixel
                    if (argbValues[counter + bytesPerPixel - 1] == 0)
                        continue;

                    int pos = 0;
                    pos++; // B value
                    pos++; // G value
                    pos++; // R value

                    argbValues[counter + pos] = (byte)(argbValues[counter + pos] * opacity);
                }

                // Copy the ARGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(argbValues, 0, ptr, numBytes);

                // Unlock the bits.
                bmp.UnlockBits(bmpData);

                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void signInButton_MouseLeave(object sender, EventArgs e)
        {
            // Revert back the button to its original opacity
            signInButton.Image = temp;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Check if username and password are same after clicking the sign in button
        private void signInButton_Click(object sender, EventArgs e)
        {
            bool loginSuccessful = false;
           

            foreach (UserAccount userAccounts in userAccountList)
            {
                if (usernameTextBox.Text == userAccounts.Username && passwordTextBox.Text == userAccounts.Password)
                {
                    loginSuccessful = true;

                    // Make the password Texbox and username Textbox to empty in the event the user logs out, for safety and security purposes
                    passwordTextBox.Text = String.Empty;
                    usernameTextBox.Text = String.Empty;


                    // Focus the user cursor on the username textbox
                    usernameTextBox.Focus();

                    // Hide the current login form
                    Hide();

                    // Direct the user to the Text Editor Form and create a UserAccount Object
                    Form textEditorScreen = new TextEditorScreen(userAccounts, this);
                    textEditorScreen.Show();

                }
            }

            // If username and password is wrong
            if (!loginSuccessful)
            {
                DialogResult result = MessageBox.Show("Incorrect Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                if (result == DialogResult.OK)
                {
                    // Focus to the usernameTextBox after use clicks ok
                    usernameTextBox.Focus();

                    // Set the fields or the text box of password to default value
                    passwordTextBox.Font = new Font("Segoe UI Light", 15.75F);
                    passwordTextBox.ForeColor = Color.Gray;
                    passwordTextBox.Text = "Password";
                    usernameTextBox.Text = String.Empty;
                    passwordTextBox.PasswordChar = '\0';
                }

            }
        }

        private void usernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // After the user enters the username textbox, redirect the user to the password Text Field
            if (e.KeyCode == Keys.Enter)
                passwordTextBox.Focus();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // After the user presses enter after password is entered, it will run the signInButoon_Click event
            if (e.KeyCode == Keys.Enter)
                signInButton_Click(this, new EventArgs());
        }

        private void loginScreen_Shown(object sender, EventArgs e)
        {
            signInLabel.Focus();
        }

        private void signUpLabel_Click(object sender, EventArgs e)
        {
            Hide();

            // Instansiate Create Account Screen Object and display it
            Form CreateAccountScreen = new CreateAccountScreen(this, userAccountList);
            CreateAccountScreen.Show();
        }

        // Load the user accounts from the login.txt file first
        public void LoadUserAccounts (string filename)
        {
            // Read the file content using the Stream Reader
            StreamReader fileContent = new StreamReader(filename);

            // Create a temp object of the userAccount
            UserAccount userAccountTemp;

            while (!fileContent.EndOfStream)
            {
                string line = fileContent.ReadLine();
                
                // Make the userAccountTemp's attribute empty
                userAccountTemp = new UserAccount();

                // Set the values for the userAccountTemp
                userAccountTemp.insertTemp(line);

                // Insert the userAccountTemp attribute to the List
                userAccountList.Add(userAccountTemp);
            }

            // Close StreamReader
            fileContent.Close();
        }


    }


}

