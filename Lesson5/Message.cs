using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Message
    {
        private static string[] separators = { ",", ".", "!", "?", ":", "-", "...", " " };
        /// <summary>
        /// Вывол на экран слов, которые содержат количество символов меньше заданного
        /// </summary>
        /// <param name="userMessage">сообщение</param>
        /// <param name="numberOfLetters">максимальное количество символов в слове</param>
        public static void PrintWords(string userMessage, int numberOfLetters)
        {
            var words = userMessage.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length<numberOfLetters)
                {
                    Console.WriteLine($"{words[i]}");
                }
            }
        }
        /// <summary>
        /// удаление из сообщения слов, заканчивающихся на заданный символ
        /// </summary>
        /// <param name="userMessage"></param>
        /// <param name="symbol">заданный символ</param>
        public static void DeleteWords (string userMessage, char symbol)
        {
            var words = userMessage.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var result = words.Where(word => !EndsWithSpecifiedLetter(word, symbol));
            var deletedWords = words.Where(word => EndsWithSpecifiedLetter(word, symbol));

            Console.WriteLine($"Сообщение без слов, оканчивающихся на {symbol} : {string.Join(' ', result)}"
                + $"\nУдалены слова: {string.Join(',', deletedWords)}.");
        }
        /// <summary>
        /// метод проверяет, заканчивается ли слово на заданный символ, а также удаляет последний символ в слове, если это не буква (например, "слово:") 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="letter"></param>
        /// <returns></returns>
        private static bool EndsWithSpecifiedLetter(string word, char letter)
        {
            if (!char.IsLetter(word.Last()))
            {
                word = word.Remove(word.Length - 1, 1);
            }
            return word.EndsWith(letter);
        }
        /// <summary>
        /// Метод находит самое длинное слово в сообщении (или слова, если максимальная длинна есть у нескольких слов)
        /// </summary>
        /// <param name="userMessage">сообщение</param>
        /// <returns></returns>
        public static List <string> FindLongestWords(string userMessage)
        {
            var words = userMessage.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var count = 0;
            var longestWords = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > count)
                {
                    count = words[i].Length;
                    longestWords.Clear();
                    longestWords.Add(words[i]);
                }
                else if (words[i].Length == count)
                {
                    longestWords.Add(words[i]);
                }
            }
            return longestWords;
        }
        /// <summary>
        /// Более короткий вариант метода FindLongestWords
        /// </summary>
        /// <param name="userMessage">сообщение</param>
        /// <returns></returns>
        public static List<string> FindLongestWordsShort(string userMessage)
        {
            var words = userMessage.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return words.GroupBy(word => word.Length).OrderByDescending(group => group.Key).First().ToList();

        }
    }
}
