using UnityEngine;
using UnityEngine.UI;
using GameLogic; 
public class RecognitionActionPlayer : MonoBehaviour
{
    [SerializeField]
    private Text _recognitionAction;

    private bool _moving;
    private bool _shot;
    private bool _rebound;
    private bool _rotation;

    void OnEnable()
    {
        Player.Moving += Moving;
        ManagerPlayer.Shot += Shot;
        BulletPlayer.Rebound += Rebound;
        Player.Rotation += Rotation;
    }
    void OnDisable()
    {
        Player.Moving -= Moving;
        ManagerPlayer.Shot -= Shot;
        BulletPlayer.Rebound -= Rebound;
        Player.Rotation -= Rotation;
    }
    private void Update()
    {
        RecognitionAction();      
    }
    void Moving (bool moving)
    {
        if (moving)
            _moving = moving;   
    }
    void  Shot(bool shot)
    {   
            _shot = shot;
    }
    void Rebound(bool rebound)
    {
        _rebound = rebound;
    }
    void Rotation (bool rotation)
    {
        _rotation = rotation;
    }
    void RecognitionAction ()
    {
        if (Player.instance._moving && _rotation && _shot)
            _recognitionAction.text = "Перемещение, разворот и выстрел";
        else  if (Player.instance._moving && _rotation && _rebound)
            _recognitionAction.text = "Перемещение, разворот, выстрел с отскоком снаряда;";
        else if (_moving && _rebound)
            _recognitionAction.text = "Перемещение и выстрел с отскоком снаряда";
        else if (_rotation && _shot)
            _recognitionAction.text = "Разворот и выстрел";
    }
}
