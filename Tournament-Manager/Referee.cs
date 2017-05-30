﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    public class Referee
    {
        private String name;
        private String surname;

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
                throw new NotImplementedException(); //TODO
            } else
            {
                name = FirstCharToUpper(words[0]);
                surname = FirstCharToUpper(words[1]);
            }
        }
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }
    }
}
