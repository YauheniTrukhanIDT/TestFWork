using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFWork.Constants;

namespace TestFWork.Entities
{
    class User
    {
        private string Login { get; set; }

        private string Password { get; set; }

        public User(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }

        public User()
        {
        }

        public static User GetDefaultUser()
        {
            return new User(UserConstants.Login, UserConstants.Password);
        }
    }
}
