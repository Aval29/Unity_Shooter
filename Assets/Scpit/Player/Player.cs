using UnityEngine;
namespace GameLogic
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _playerRb;
        public float _speed;
        [SerializeField]
        private GameObject _bullet;
        [SerializeField]
        private Transform _shotPoint;

        [SerializeField]
        private float _offset;
        [SerializeField]
        private float _startBtwShot;
        public float timeBtwShots;

        [HideInInspector]
        public bool _moving;
        [HideInInspector]
        public bool _shot;
        private bool _rotation;

        public static event OnMoving Moving;
        public delegate void OnMoving(bool moving);

        public static event OnRotation Rotation;
        public delegate void OnRotation(bool rotation);

        public static Player instance;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody2D>();
            instance = GetComponent<Player>();
            _rotation = false;
            _moving = false;
        }

        private void Update()
        {
            Motion—heck();
        }
        public void MovingPlayer(float x, float y)
        {
            _playerRb.velocity = new Vector2(x * _speed, y * _speed);
        }
        public void Motion—heck()
        {
            if (_playerRb.velocity.x != 0 || _playerRb.velocity.y != 0)
            {
                _moving = true;
                Moving(_moving);
            }
            else
            {
                _moving = false;
                Moving(_moving);
            }
        }
        public void RotationPlayer(float rotation)
        {
            float rot = transform.rotation.z;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation + _offset);
            if (rot == transform.rotation.z)
            {
                _rotation = false;
                Rotation(_rotation);
            }
            else
            {
                _rotation = true;
                Rotation(_rotation);
            }
        }
        public void ShotPlayer(bool start)
        {
            if (timeBtwShots <= 0)
            {
                if (start)
                {
                    Instantiate(_bullet, _shotPoint.position, transform.rotation);
                    timeBtwShots = _startBtwShot;
                }
            }
            else timeBtwShots -= Time.deltaTime;
        }
    }
}
