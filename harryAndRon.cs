using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace TextAnalysis
{
    public static class Answer
    {
        static void Main()
        {
            Dictionary<string, string> nextWords = new Dictionary<string, string>
            {
                {"x", "y"},
                {"x y", "z"},
                {"y", "q"}
            };
            var phraseBeginning = "x";
            var wordsCount = 4;
            var text = TextGeneratorTask.ContinuePhrase(nextWords, 
                                                        phraseBeginning, 
                                                        wordsCount);
            Console.WriteLine(text);
            Console.WriteLine(text.Length);
            Console.ReadKey();
        }
    }
    
    public static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            string[] stringToArray = phraseBeginning.Split(' ');
            string[] anewer = WordSeparatin(nextWords,
                                            stringToArray,
                                            wordsCount);
            return string.Join(" ", anewer);
        }

        static string[] WordSeparatin(
            Dictionary<string, string> nextWords,
            string[] stringToArray,
            int wordsCount)
        {
            int lenStringToArray = stringToArray.Length;
            while (wordsCount != 0)
            {
                stringToArray = Resider(nextWords, stringToArray, lenStringToArray);
                if (stringToArray.Length > lenStringToArray)
                {
                    ++lenStringToArray;
                    --wordsCount;
                }
                else wordsCount = 0;
            }
            return stringToArray;
        }

        static string[] Resider(
            Dictionary<string, string> nextWords,
            string[] stringToArray, int lenStringToArray)
        {
            string[] returningString = ArrayIncreaser(stringToArray, lenStringToArray);
            if (lenStringToArray > 1)
            {
                string word = stringToArray[lenStringToArray - 2] +
                              " " + stringToArray[lenStringToArray - 1];
                if (nextWords.ContainsKey(word))
                {
                    returningString[lenStringToArray] = nextWords[word];
                    return returningString;
                }
            }
            if (nextWords.ContainsKey(stringToArray[lenStringToArray - 1]))
            {
                returningString = IfKeyIsSingle(returningString, nextWords, stringToArray,
                                                lenStringToArray);
                return returningString;
            }
            else
                return stringToArray;
        }

        static string[] ArrayIncreaser(string[] stringToArray,
                                              int lenStringToArray)
        {
            string[] returningArray = new string[lenStringToArray + 1];
            for (int i = 0; i < lenStringToArray; i++)
                returningArray[i] = stringToArray[i];
            return returningArray;
        }

        static string[] IfKeyIsSingle(string[] returningString,
                                             Dictionary<string, string> nextWords,
                                             string[] stringToArray,
                                             int lenStringToArray)
        {
            returningString[lenStringToArray] =
                nextWords[stringToArray[lenStringToArray - 1]];
            return returningString;
        }
    }
}
