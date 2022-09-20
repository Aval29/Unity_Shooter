using UnityEngine;
using UnityEngine.SceneManagement;
namespace GameLogic
{
    public class BulletPlayer : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _distance;

        [SerializeField]
        private LayerMask _goal;

        [HideInInspector]
        public bool _glasses;
        [HideInInspector]
        public RaycastHit2D hit;

        private bool _rebound;

        public static event OnGlassesPlayer GlassesPlayer;
        public delegate void OnGlassesPlayer(bool glasses);

        public static event OnRebound Rebound;
        public delegate void OnRebound(bool rebound);

        public void Update()
        {
            hit = Physics2D.Raycast(transform.position, transform.up, _distance, _goal);
            ShotPlayer();
            ShotBlock();
        }
        public virtual void ShotPlayer()
        {
            if (hit.collider != null)
            {
                _glasses = false;
                if (hit.collider.CompareTag("Enemy"))
                {
                    _glasses = true;
                    GlassesPlayer(_glasses);
                    Destroy(gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        public void ShotBlock()
        {
            _rebound = false;
            Rebound(_rebound);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Block"))
                {
                    transform.up = Vector2.Reflect(transform.up, hit.normal).normalized;

                    _rebound = true;
                    Rebound(_rebound);
                }
            }
            transform.Translate(-Vector2.right * _speed * Time.deltaTime);
        }
    }
}

  
    

