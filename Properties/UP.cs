using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_saver
{
    public class UP
    {
        private string username;
        private string password;
        private string title;
        private string website;
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
        public string Title { get => title; set => title = value; }
        public string Website { get => website; set => website = value; }
    }
}
