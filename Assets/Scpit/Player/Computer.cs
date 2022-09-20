using UnityEngine;
namespace GameLogic
{
    public class Computer : Player
    {
        [SerializeField]
        private float rac;
        public void MovingPlayerComputer(Transform player)
        {
            if ((transform.position.magnitude - player.position.magnitude) > rac && timeBtwShots >= 0)
                transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position, -player.position, _speed * Time.deltaTime);
        }
    }
}
