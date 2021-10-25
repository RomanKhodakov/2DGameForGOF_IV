using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class JsonData<T>
    {
        public List<T> Load(string path = null)
        {
            List<T> list = new List<T>();
            var str = File.ReadAllText(path);
            if (typeof(T) == typeof(SavedDataEnemy))
            {
                str = str.Substring(2, str.Length - 4);
                string[] separatingStrings = {"},"};
                string[] words = str.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length - 1; i++)
                {
                    words[i] += "}";
                }

                foreach (var res in words)
                {
                    list.Add(JsonUtility.FromJson<T>(res));
                }
            }
            else
            {
                list.Add(JsonUtility.FromJson<T>(str));
            }
            return list;
        }
    }
}