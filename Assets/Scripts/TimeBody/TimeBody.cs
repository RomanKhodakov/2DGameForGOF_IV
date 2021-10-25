using System.Collections.Generic;
using UnityEngine;


namespace ExampleGame
{
    internal sealed class TimeBody
    {
        private readonly float _recordTime;
        private readonly Enemy _enemy;
        private readonly EnemyInitialization _enemyInitialization;
        private readonly List<PointInTime> _pointsInTime;
        private readonly Transform _enemyTransform;
        private readonly Rigidbody2D _rb;
        private bool _isRewinding;
        private bool _isActiveNow;

        public TimeBody(Enemy enemy, EnemyInitialization enemyInitialization)
        {
            _enemy = enemy;
            _enemyInitialization = enemyInitialization;
            _recordTime = EnemyInitialization.RecordTime;
            _pointsInTime = new List<PointInTime>();
            _enemyTransform = enemy.transform;
            _rb = _enemy.GetComponent<Rigidbody2D>();
        }

        public void FixedExecute()
        {
            _isActiveNow = _enemy.gameObject.activeInHierarchy;
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }

        private void Rewind()
        {
            if (_pointsInTime.Count > 1 && _isActiveNow)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _enemyTransform.position = pointInTime.Position;
                _enemyTransform.rotation = pointInTime.Rotation;
                if (!pointInTime.IsActive)
                {
                    _enemyInitialization.ReturnEnemyToPool(_enemy.gameObject.GetInstanceID());
                }
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _enemyTransform.position = pointInTime.Position;
                _enemyTransform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        private void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }

            _pointsInTime.Insert(0, new PointInTime(_enemyTransform.position, 
                _enemyTransform.rotation, _rb.velocity, _rb.angularVelocity, _isActiveNow));
        }

        public void StartRewind()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
        }

        private void StopRewind()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
            _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
            _isActiveNow = _pointsInTime[0].IsActive;
        }
    }
}