using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_1_5_
{
    internal class Methods
    {
        // Задание 1
        public static bool HasDublicates<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Лист пустой");
                return false;
            }

            if (list.Count == 1)
            {
                Console.WriteLine("В листе есть только 1 элемент");
                return false;
            }

            HashSet<T> check = new HashSet<T>();

            foreach (T item in list)
            {
                if (check.Contains(item))
                {
                    return true;
                }
                check.Add(item);
            }
            return false;

        }
        // Задание 2 
        public static LinkedList<T> DeleteFirst<T>(LinkedList<T> linklist, T a)
        {
            if (linklist == null)
            {
                Console.WriteLine("Список пустой");
                return null;
            }

            if (linklist.Contains(a))
            {
                linklist.Remove(a);
                return linklist;
            }
            else
            {
                Console.WriteLine("Такого элемента нет");
                return null;
            }
        }
        // Задание 3 
        public static HashSet<string> GetTracksLikedByAll(HashSet<string> allTracks, List<HashSet<string>> melomanPreferences)
        {
            if (melomanPreferences == null || melomanPreferences.Count == 0)
                return new HashSet<string>();

            HashSet<string> commonTracks = new HashSet<string>(melomanPreferences[0]);

            for (int i = 1; i < melomanPreferences.Count; i++)
            {
                commonTracks.IntersectWith(melomanPreferences[i]);
            }

            return commonTracks;
        }

        public static HashSet<string> GetTracksLikedBySome(HashSet<string> allTracks, List<HashSet<string>> melomanPreferences)
        {
            if (melomanPreferences == null || melomanPreferences.Count == 0)
                return new HashSet<string>();

            HashSet<string> likedBySome = new HashSet<string>();

            foreach (var preferences in melomanPreferences)
            {
                likedBySome.UnionWith(preferences);
            }

            return likedBySome;
        }

        public static HashSet<string> GetTracksLikedByNone(HashSet<string> allTracks, List<HashSet<string>> melomanPreferences)
        {
            HashSet<string> likedBySome = GetTracksLikedBySome(allTracks, melomanPreferences);

            HashSet<string> likedByNone = new HashSet<string>(allTracks);
            likedByNone.ExceptWith(likedBySome);

            return likedByNone;
        }

        public static (HashSet<string> likedByAll, HashSet<string> likedBySome, HashSet<string> likedByNone)
            AnalyzePreferences(HashSet<string> allTracks, List<HashSet<string>> melomanPreferences)
        {
            var likedByAll = GetTracksLikedByAll(allTracks, melomanPreferences);
            var likedBySome = GetTracksLikedBySome(allTracks, melomanPreferences);
            var likedByNone = GetTracksLikedByNone(allTracks, melomanPreferences);

            return (likedByAll, likedBySome, likedByNone);
        }

        public static void PrintResult(string title, HashSet<string> tracks)
        {
            Console.WriteLine($"{title}:");
            if (tracks.Count == 0)
            {
                Console.WriteLine("  (пусто)");
            }
            else
            {
                foreach (var track in tracks.OrderBy(t => t))
                {
                    Console.WriteLine($"  - {track}");
                }
            }
            Console.WriteLine();
        }
        // Задание 4
        public static HashSet<char> FindUniqueVowels(string text, HashSet<char> RussianVowels)
        {
            Dictionary<char, HashSet<string>> vowelOccurrences = new Dictionary<char, HashSet<string>>();

            string[] words = text.Split(new[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                HashSet<char> vowelsInWord = new HashSet<char>();

                foreach (char c in word)
                {
                    if (RussianVowels.Contains(c))
                    {
                        vowelsInWord.Add(char.ToLower(c)); 
                    }
                }

                foreach (char vowel in vowelsInWord)
                {
                    if (!vowelOccurrences.ContainsKey(vowel))
                    {
                        vowelOccurrences[vowel] = new HashSet<string>();
                    }
                    vowelOccurrences[vowel].Add(word);
                }
            }

            HashSet<char> result = new HashSet<char>();
            foreach (var kvp in vowelOccurrences)
            {
                if (kvp.Value.Count <= 1)
                {
                    result.Add(kvp.Key);
                }
            }

            return new HashSet<char>(result.OrderBy(v => v));
        }
        

    }
}
