using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string Input = "Enter scrambled word(s) manually or as a file: F - file / M - manual";
        public const string EmptError = "String is empty";
        public const string FileName = "Enter full path including the file name: ";
        public const string InstructionsForInput = "Enter word(s) manually (separated by commas if multiple): ";
        public const string InstructionsForInput2 = "Input '/done' when you have completed your list of scrambled words";
        public const string InstructionsForInput3 = "Input '/done' when you have completed your list of none scrambled words";
        public const string InputError = "The entered option was not recognized.";
        public const string Terminate = "The program will be terminated.";
        public const string Prompt = "Please input your word";


        public const string WordList = "wordlist.txt";
    }
}
