using UnityEngine;
namespace GameLogic
{
    public class ManagerPlayer : MonoBehaviour
    {
        private float _movingX, _movingY;
        private Vector2 _diffense;

        private float _playerRotation;
        [HideInInspector]
        public bool _startShot;

        public static event OnMoving Moving;
        public delegate void OnMoving(float x, float y);

        public static event OnRotation Rotation;
        public delegate void OnRotation(float rotation);

        public static event OnShot Shot;
        public delegate void OnShot(bool start);
        public static ManagerPlayer instance;

        private void Awake()
        {
            instance = GetComponent<ManagerPlayer>();
        }
        private void FixedUpdate()
        {
            InputMoving();
            InputRotation();
            InputShot();
        }
        public virtual void InputMoving()
        {
            _movingX = Input.GetAxisRaw("Horizontal");
            _movingY = Input.GetAxisRaw("Vertical");
            Moving(_movingX, _movingY);
        }
        public virtual void InputRotation()
        {
            _diffense = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _playerRotation = Mathf.Atan2(_diffense.y, _diffense.x) * Mathf.Rad2Deg;
            Rotation(_playerRotation);
        }
        public virtual void InputShot()
        {
            if (Input.GetMouseButton(0))
            {
                _startShot = true;
                Shot(_startShot);
            }
            else
            {
                _startShot = false;
                Shot(_startShot);
            }
        }
    }
}
