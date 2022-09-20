using UnityEngine.SceneManagement;
namespace GameLogic
{
    public class BulletComputer : BulletPlayer
    {
        public static event OnGlassesComputer GlassesComputer;
        public delegate void OnGlassesComputer(bool glasses);
        public override void ShotPlayer()
        {
            if (hit.collider != null)
            {
                _glasses = false;
                if (hit.collider.CompareTag("Player"))
                {
                    _glasses = true;
                    GlassesComputer(_glasses);
                    Destroy(gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
