using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ManagerComputer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPerson;
        private Transform _playerTransform;
        private Vector3 _playerPosition;
        private float _playerComputer;
        private bool _startPlayerComputer;

        public static event OnMovingComputer MovingComputer;
        public delegate void OnMovingComputer(Transform player);

        public static event OnRotationComputer RotationComputer;
        public delegate void OnRotationComputer(float rotation);

        public static event OnShotComputer ShotComputer;
        public delegate void OnShotComputer(bool startShot);

        private void Awake()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            _playerPerson = GameObject.FindWithTag("Player");
        }
        private void Update()
        {
            InputMovingComputer();
            InputRotationComputer();
            InputShotComputer();
        }
        public void InputMovingComputer()
        {
            MovingComputer(_playerTransform);
        }
        public void InputRotationComputer()
        {
            _playerPosition = _playerTransform.position - transform.position;
            _playerComputer = Mathf.Atan2(_playerPosition.y, _playerPosition.x) * Mathf.Rad2Deg;
            RotationComputer(_playerComputer);
        }
        public void InputShotComputer()
        {
            if (_playerPerson)
            {
                _startPlayerComputer = true;
                ShotComputer(_startPlayerComputer);
            }
        }
    }
}
