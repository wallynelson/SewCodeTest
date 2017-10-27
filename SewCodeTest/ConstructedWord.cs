using System.Collections.Generic;

namespace SewCodeTest
{
    public class ConstructedWord
    {
        public string Word { get; set; }
        public int Length { get; set; }
        public List<string> ShortWords { get; set; }

        public ConstructedWord(string word)
        {
            Word = word;
            Length = word.Length;
            ShortWords = new List<string>();
        }
    }
}
