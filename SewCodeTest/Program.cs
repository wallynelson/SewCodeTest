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
            var constructedWords = new List<ConstructedWord>();

            var words = new HashSet<string>(File.ReadLines("wordlist.txt"));

            foreach (var word in words)
            {
                var constructedWord = new ConstructedWord(word);
                var shortword = string.Empty;

                for (int i = word.Length - 1; i >= 0; i--)
                {
                    shortword = word[i]+ shortword;
                    if (words.Contains(shortword) && shortword != word)
                    {
                        constructedWord.ShortWords.Add(shortword);
                        shortword = string.Empty;
                    }
                }

                //for (int i = 0; i < word.Length; i++)
                //{
                //    shortword += word[i];
                //    if (wordlist.Contains(shortword) && shortword != word)
                //    {
                //        constructedWord.ShortWords.Add(shortword);
                //        if (i <= word.Length)
                //        {
                //            shortword = word.Substring(i + 1);
                //            if (wordlist.Contains(shortword))
                //            {
                //                constructedWord.ShortWords.Add(shortword);
                //                i = word.Length;
                //            }
                //        }
                //        shortword = string.Empty;
                //    }
                //}

                //foreach (var chr in word)
                //{
                //    shortword += chr;
                //    if (wordlist.Contains(shortword) && shortword != word)
                //    {
                //        constructedWord.ShortWords.Add(shortword);
                //        shortword = string.Empty;
                //    }
                //}

                if (string.IsNullOrEmpty(shortword))
                {
                    constructedWords.Add(constructedWord);
                }
            }

            var longestWords = constructedWords.OrderByDescending(c => c.Length).Take(2);

            foreach (var longestWord in longestWords)
            {
                Console.WriteLine(longestWord.Word);
                foreach (var shortword in longestWord.ShortWords)
                {
                    Console.WriteLine(shortword);
                }
            }

            Console.ReadLine();
        }
    }
}
