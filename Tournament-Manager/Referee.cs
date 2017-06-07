using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csUnit;

namespace Tournament_Manager
{
    [Serializable]
    public class Referee
    {
        private String name;
        private String surname;

        public String FullName
        {
            get { return name + " " + surname; }
        }
        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public Referee(String input)
        {
            input = input.Trim();
            String[] words = input.Split(' ');

            if (words.Length != 2)
            {
                throw new ArgumentException("Prawidłowy format danych sędziego: imię + nazwisko");
            } else
            {
                name = FirstCharToUpper(words[0]);
                surname = FirstCharToUpper(words[1]);

            }
        }

        public static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }
    }
}
