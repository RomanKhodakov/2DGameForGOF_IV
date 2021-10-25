using System.Collections.Generic;
using ExampleGame;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(BulletDictionaryViewer))]
    public class BulletDictionaryEditor : UnityEditor.Editor
    {
        private Dictionary<int, Bullet> _bulletPoolWithID = new Dictionary<int, Bullet>();
        private BulletDictionaryViewer _viewer;
        public override void OnInspectorGUI()
        {
            _viewer = (BulletDictionaryViewer) target;
            _bulletPoolWithID = _viewer.BulletsWithID;
            if (_bulletPoolWithID != null)
            {
                foreach (var kvp in _bulletPoolWithID)
                {
                    EditorGUILayout.IntField($"{kvp.Value.name} ID:", kvp.Key);
                }
            }

            DrawDefaultInspector();
        }
    }
}