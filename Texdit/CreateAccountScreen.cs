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
    public partial class CreateAccountScreen : Form
    {
        private Image cancelButtonTemp;
        private Image createAccountButtonTemp;
        LoginScreen loginScreen;
        private List<UserAccount> userAccountList = new List<UserAccount>();
        public CreateAccountScreen(LoginScreen loginScreen, List<UserAccount> userAccountList)
        {
            InitializeComponent();
            cancelButtonTemp = cancelButton.Image;
            createAccountButtonTemp = createAccountButton.Image;
            this.loginScreen = loginScreen;
            this.userAccountList = userAccountList;

        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
            loginScreen.Close();
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

        private void createAccountButton_MouseHover(object sender, EventArgs e)
        {
            Image tempImage;
            tempImage = ChangeImageOpacity(createAccountButton.Image, 0.8);
            createAccountButton.Image = tempImage;
        }

        private void cancelButton_MouseHover(object sender, EventArgs e)
        {
            Image tempImage;
            tempImage = ChangeImageOpacity(cancelButton.Image, 0.5);
            cancelButton.Image = tempImage;
        }

        private void cancelButton_MouseLeave(object sender, EventArgs e)
        {
            // Revert back the button image to its original opacity
            cancelButton.Image = cancelButtonTemp;
        }

        private void createAccountButton_MouseLeave(object sender, EventArgs e)
        {
            // Revert back the button image to its original opacity
            createAccountButton.Image = createAccountButtonTemp;
        }

        // Create Account Button Logic
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text == "")
            {
                MessageBox.Show("First Name cannot be blank.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                firstNameTextBox.Focus();
            }
            else if (lastNameTextBox.Text == "")
            {
                MessageBox.Show("Last Name cannot be blank.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lastNameTextBox.Focus();
            }
            else if (usernameTextBox.Text == "")
            {
                MessageBox.Show("Username cannot be blank.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                usernameTextBox.Focus();
            }
            else if (passwordTextBox.Text == "" || confirmPasswordTextBox.Text == "")
            {
                MessageBox.Show("Password cannot be blank.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                passwordTextBox.Focus();
            }
            else if (userTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select user type.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                userTypeComboBox.Focus();
            }
            else if (UsernameExists(usernameTextBox.Text))
            {
                MessageBox.Show("Username already exists.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                usernameTextBox.Text = String.Empty;
                usernameTextBox.Focus();
            }
            else if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                passwordTextBox.Text = String.Empty;
                confirmPasswordTextBox.Text = String.Empty;
                passwordTextBox.Focus();
            }
            else
            {
                // Update the login txt file
                File.AppendAllText("login.txt", $"\n{usernameTextBox.Text},{passwordTextBox.Text}," +
                   $"{userTypeComboBox.SelectedItem},{firstNameTextBox.Text},{lastNameTextBox.Text}," +
                    $"{dateOfBirth.Text}");
                MessageBox.Show("Account created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                
                loginScreen.Show();

                // Reload the userAccounts so the newly created account is in the Collection
                loginScreen.LoadUserAccounts("login.txt");
            }
        }
        // Check if username exists
        private bool UsernameExists(string username)
        {
            // Chck the userAccountList that was loaded in the CreateAccount constructor
            foreach (UserAccount userAccounts in userAccountList)
            {
                if (username == userAccounts.Username)
                    return true;
            }
            return false;
        }

        // Go back to login Screen
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            loginScreen.Show();
        }


        private void CreateAccountScreen_Shown(object sender, EventArgs e)
        {
            firstNameTextBox.Focus();
        }


        private void lastNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void userTypeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                createAccountButton_Click(this, new EventArgs());
        }
    }
}
