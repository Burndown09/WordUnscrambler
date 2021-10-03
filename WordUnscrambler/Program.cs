using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args){
            
            bool repeat = false;
            do
            {
                try
                {
                    


                    Console.WriteLine(Constants.Input);

                    String option = Console.ReadLine() ?? throw new ArgumentNullException(Constants.EmptError);


                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine(Constants.FileName);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine(Constants.InstructionsForInput);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.InputError);
                            repeat = true;
                            break;
                    }

                    Console.ReadLine();
                    
                }


                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(Constants.EmptError + ex.Message);
                    repeat = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(Constants.Terminate + ex.Message);

                }
            } while (repeat);
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var filename = Console.ReadLine();
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWordsFileScenerio(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            List<string> listOfScrambledWords = new List<string>();
            Console.WriteLine(Constants.InstructionsForInput2);
            string finished = "";
            do
            {
                Console.WriteLine(Constants.Prompt);

                string userInput = Console.ReadLine();

                if (userInput.Equals("/done")) {
                    finished = userInput;

                }
                else {
                    listOfScrambledWords.Append(userInput);
                }

            }   while(!finished.Equals("/done"));
            
            string[] scrambledwords = new string[listOfScrambledWords.Count];
            
            for (int i = 0; i < scrambledwords.Length; i++) {
                scrambledwords[i] = listOfScrambledWords[i];
            }
            
            List<string> listOfWords = new List<string>();
            
            Console.WriteLine(Constants.InstructionsForInput3);
            string done = "";
            
            do
            {
                Console.WriteLine(Constants.Prompt);
                string input = Console.ReadLine();
                if (input.Equals("/done"))
                {
                    done = "/done";
                }
                else
                {
                    listOfWords.Append(input);
                }

            } while (!done.Equals("/done"));

            string[] wordList = new string[listOfWords.Count];

            for (int i = 0; i < wordList.Length; i++)
            {
                wordList[i] = listOfWords[i];
            }
            DisplayMatchedUnscrambledWordsManualScenerio(scrambledwords, wordList);
        }

        private static void DisplayMatchedUnscrambledWordsFileScenerio(string[] scrambledWords)
        {
            //read the list of words from the system file. 
            string[] wordList = _fileReader.Read(Constants.WordList);

            //call a word matcher method to get a list of structs of matched words.
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            foreach (var matchedWord in matchedWords)
            {
                int i = 0;
                Console.WriteLine("the scrambled word" + matchedWords[i].ScrambledWord + "matched with" +
                    matchedWords[i].Word);
                i++;
            }
        }

        private static void DisplayMatchedUnscrambledWordsManualScenerio(string[] scrambledWords, string[] wordList)
        {

            //call a word matcher method to get a list of structs of matched words.
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            foreach(var matchedWord in matchedWords){ 
                    int i = 0;
                Console.WriteLine("the scrambled word" + matchedWords[i].ScrambledWord + "matched with" + 
                    matchedWords[i].Word);
                   i++;
            }

        }
    }
}
