using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_saver
{
    [Serializable]
    public class data
    {
        private string password1="";
        private string password2="";
        private string question = "";
        private string answer = "";
        private string passwordcode;
        private List<UP> UPs;

        public string Password1 { get => password1; set => password1 = value; }
        public string Password2 { get => password2; set => password2 = value; }
        public List<UP> UPs1 { get => UPs; set => UPs = value; }
        public string Question { get => question; set => question = value; }
        public string Answer { get => answer; set => answer = value; }
        public string Passwordcode { get => passwordcode; set => passwordcode = value; }

        public static List<string> QA = new List<string>() { "your crush's name?", "your favorite artist?" , "your favorite song?" , "your favorite fruit?" , "your favorite drink?" , "your favorite movie?"};
    }
}
