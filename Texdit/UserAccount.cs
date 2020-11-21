using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texdit
{
    public class UserAccount
    {
        private string username;
        private string password;
        private string userType;
        private string firstName;
        private string lastName;
        private string dateOfBirth;


        public UserAccount(string username, string password, string userType, string firstName, string lastName, string dateOfBirth)
        {
            this.username = username;
            this.password = password;
            this.userType = userType;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }

        public UserAccount ()
        {
            username = null;
            password = null;
            userType = null;
            firstName = null;
            lastName = null;
            dateOfBirth = null;
        }

        // Getter setter for each of the userAccoutn variables
        public string Username { get => username; }
        public string Password { get => password; }
        public string UserType { get => userType; }
        public string FirstName { get => firstName; }
        public string LastName { get => lastName; }
        public string DateOfBirth { get => dateOfBirth; }

        
        // Insert to the temp object after reading a line from the StreamReader
        public void insertTemp (string fileLine)
        {
            // Split the comma 
            string[] fields = fileLine.Split(',');

            // Assign values to the attribute
            username = fields[0];
            password = fields[1];
            userType = fields[2];
            firstName = fields[3];
            lastName = fields[4];
            dateOfBirth = fields[5];

            
        }
        
    }


}
