namespace GameLogic
{
    public class PlayerComputer : Computer
    {
        void OnEnable()
        {
            ManagerComputer.MovingComputer += MovingPlayerComputer;
            ManagerComputer.RotationComputer += RotationPlayer;
            ManagerComputer.ShotComputer += ShotPlayer;
        }
        void OnDisable()
        {
            ManagerComputer.MovingComputer -= MovingPlayerComputer;
            ManagerComputer.RotationComputer -= RotationPlayer;
            ManagerComputer.ShotComputer -= ShotPlayer;
        }
    }
}
