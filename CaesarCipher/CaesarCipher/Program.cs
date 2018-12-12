using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            CipherEncoder encoder = new CipherEncoder();
            string unencodedString;
            string encodedString;
            int offset = 0;
            bool intGivenForOffset = false;
            Console.WriteLine("Please enter a string to encode");
            unencodedString = Console.ReadLine();
            while (!intGivenForOffset)
            {
                Console.WriteLine("Please enter an integer for the offset for the encoding");
                intGivenForOffset = int.TryParse(Console.ReadLine(), out offset);
            }
            encodedString = encoder.Encrypt(unencodedString, offset);
            Console.WriteLine("Your encoded message is:");
            Console.WriteLine(encodedString);
            Console.ReadKey();
        }
    }

    public class CipherEncoder
    {
        public char[] alphabet;

        public CipherEncoder()
        {
            alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        }

        //Encrypts the unencoded message by shifting all letters according
        //to the given offset
        public string Encrypt(string unencodedMessage, int offset)
        {
            string encodedMessage = "";

            //Build encoded message by iterating through each character in the original
            //string and shifting them one at a time.
            for (int i = 0; i < unencodedMessage.Length; i++)
            {
                encodedMessage += SwitchLetter(unencodedMessage.Substring(i, 1), offset);
            }
            return encodedMessage;
        }

        public string SwitchLetter(string currentLetter, int offset)
        {
            string newLetter;

            //Check if the current character is a letter, return original
            //character if not
            if (alphabet.Contains(currentLetter.ToLower()[0]))
            {
                int index;
                int offsetIndex;
                index = Array.IndexOf(alphabet, currentLetter.ToLower()[0]);
                offsetIndex = (index + offset) % 26;

                //Check if current character is uppercase/lowercase, then return
                //encoded character as the same case
                if (Char.IsUpper(currentLetter[0]))
                    newLetter = alphabet[offsetIndex].ToString().ToUpper();
                else
                    newLetter = alphabet[offsetIndex].ToString();
            }
            else
            {
                newLetter = currentLetter;
            }

            return newLetter;
        }
    }
}
