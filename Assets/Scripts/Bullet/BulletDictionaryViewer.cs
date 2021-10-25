using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    public class BulletDictionaryViewer : MonoBehaviour
    { //для отображения пуль в инспекторе
        public Dictionary<int, Bullet> BulletsWithID { get; private set; }

        public void SetDictionary(Dictionary<int, Bullet> bullets)
        {
            if (bullets != null) BulletsWithID = bullets;
        }
    }
}
