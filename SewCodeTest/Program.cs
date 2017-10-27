using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SewCodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if there is an argument
            if (args.Length != 1)
            {
                return;
            }

            // Check to see if the argument is a file
            var wordFile = args[0];
            if (!File.Exists(wordFile))
            {
                return;
            }

            // Find Constructed Words
            var constructedWords = FindConstructedWords(wordFile);

            // Display Constructed Words Results
            DisplayConstructedWordsResult(constructedWords);
        }

        private static List<ConstructedWord> FindConstructedWords(string wordFile)
        {
            // Create a list of all words contracted of other words
            var constructedWords = new List<ConstructedWord>();

            // Get all the words from the file
            var words = new HashSet<string>(File.ReadLines(wordFile));

            // Cycle through all the words looking for constructed words
            foreach (var word in words)
            {
                var constructedWord = new ConstructedWord(word);
                var shortWord = string.Empty;

                // Cycle through all the characters in the word backwards looking for short words
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    shortWord = word[i] + shortWord;
                    if (words.Contains(shortWord) && shortWord != word)
                    {
                        constructedWord.ShortWords.Add(shortWord);
                        shortWord = string.Empty;
                    }
                }

                // The word is constructed of other words
                if (string.IsNullOrEmpty(shortWord))
                {
                    constructedWords.Add(constructedWord);
                }
            }

            return constructedWords;
        }

        private static void DisplayConstructedWordsResult(List<ConstructedWord> constructedWords)
        {
            // Get the top 2 longest constructed words
            var longestWords = constructedWords.OrderByDescending(c => c.Length).Take(2);

            Console.WriteLine("CONSTRUCTED WORDS RESULTS:");
            foreach (var longestWord in longestWords)
            {
                Console.WriteLine($"\n{longestWord.Word} is {longestWord.Length} characters long and is made up of the following short words:");
                longestWord.ShortWords.Reverse();
                foreach (var shortword in longestWord.ShortWords)
                {
                    Console.WriteLine($"\t{shortword}");
                }
            }

            Console.WriteLine($"\nTotal Constructed Words: {constructedWords.Count():n0}");

            Console.WriteLine("\nPress any key to continue.");

            Console.ReadKey();
        }
    }
}
