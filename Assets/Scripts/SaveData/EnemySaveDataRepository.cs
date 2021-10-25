using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class EnemySaveDataRepository <T> : ISaveDataRepository <T>
    {
        private readonly JsonData<T> _enemyJsonData;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public EnemySaveDataRepository()
        {
            _enemyJsonData = new JsonData<T>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public List<T> Load()
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return null;
            var newEnemies = _enemyJsonData.Load(file);
            foreach (var res in newEnemies)
            {
                Debug.Log(res);
            }

            return newEnemies;
        }
    }
}