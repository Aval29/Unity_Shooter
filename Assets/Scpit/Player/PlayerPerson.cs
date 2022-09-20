namespace GameLogic
{
    public class PlayerPerson : Player
    {
        void OnEnable()
        {
            ManagerPlayer.Moving += MovingPlayer;
            ManagerPlayer.Rotation += RotationPlayer;
            ManagerPlayer.Shot += ShotPlayer;
        }
        void OnDisable()
        {
            ManagerPlayer.Moving -= MovingPlayer;
            ManagerPlayer.Rotation -= RotationPlayer;
            ManagerPlayer.Shot -= ShotPlayer;
        }
    }
}
