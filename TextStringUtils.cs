﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectForNeuralab
{
    class TextStringUtils
    {
        //Static method will generate a random string in given length from hardcoded dictionary//////////////////////////////////////

        public static string generateRandomString(int length)
        {
            string dictionary = "abcdefghijklmnopqrstuvwxyz01234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Random random = new Random();

            string key = new string(
                        Enumerable.Repeat(dictionary, length) // Numbers are possible values //
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());

            return key;
        }



        /*Static method will generate a random string in 11-letter length from hardcoded dictionary. It will be suitable for windows admin passwords as the straing will include numbers,
         * LARGE letters and small letters.
         */

        public static string generateRandomStringforWindowsPasswords()
        {
            string dictionarysmall = "abcdefghijklmnopqrstuvwxyz";
            string dictionaryLARGE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string dictionaryNum = "01234567890";

            Random random1 = new Random();

            string keysmall = new string(
                        Enumerable.Repeat(dictionarysmall, 4) // Numbers are possible values //
                                  .Select(s => s[random1.Next(s.Length)])
                                  .ToArray());


            Random random2 = new Random();

            string keysLARGE = new string(
                        Enumerable.Repeat(dictionaryLARGE, 4) // Numbers are possible values //
                                  .Select(s => s[random2.Next(s.Length)])
                                  .ToArray());


            Random random3 = new Random();

            string keysNum = new string(
                        Enumerable.Repeat(dictionaryNum, 3) // Numbers are possible values //
                                  .Select(s => s[random3.Next(s.Length)])
                                  .ToArray());


            string original = keysmall + keysNum + keysLARGE;

            // The random number sequence for shufling
            Random num = new Random();

            // Create new string from the reordered char array
            string rand = new string(original.ToCharArray().
                OrderBy(s => (num.Next(2) % 2) == 0).ToArray());

            return rand;
        }




        //Method checks if given string is valid VAT number. Tested for Croatian usage////////////////////////////////////

        public static bool checkOIB(string oib)
        {
            if (oib.Length != 11) return false;

            long b;

            if (!long.TryParse(oib, out b)) return false;

            int a = 10;

            for (int i = 0; i < 10; i++)
            {
                a = a + Convert.ToInt32(oib.Substring(i, 1));
                a = a % 10;
                if (a == 0) a = 10;
                a *= 2;
                a = a % 11;
            }

            int controlNum = 11 - a;

            if (controlNum == 10) controlNum = 0;

            return controlNum == Convert.ToInt32(oib.Substring(10, 1));
        } 




        //Method checks if given straing is a valid email address///////////////////////////////////////////////////////////

        public static bool checkEmailValidation(string emailToCheck)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

            Match match = regex.Match(emailToCheck);

            return match.Success;
        }


        /// <summary>
        /// Method generates random string (key) of length 10 based on provided dictionary.
        /// </summary>
        /// <param name="dictionary">String of characters that method will generate random string from.</param>
        /// <returns>Random generated string.</returns>
        public static string generateRandomStringOnInputDictionary(string dictionary)
        {
            Random random = new Random();

            string key = new string(
                        Enumerable.Repeat(dictionary, 10) // Numbers are possible values //
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());

            return key;
        }

    }
}
