using UnityEngine;
using UnityEngine.UI;
using GameLogic;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    private static int scorePlaer;
    private static int scoreEmeny;
    void OnEnable()
    {
        BulletPlayer.GlassesPlayer += Kill;
        BulletComputer.GlassesComputer += KillPlayer;
    }
    void OnDisable()
    {
        BulletPlayer.GlassesPlayer -= Kill;
        BulletComputer.GlassesComputer -= KillPlayer;
    }
    private void Start()
    {
        ScoreText();
    }
    void ScoreText()
    {
        _scoreText.text = scorePlaer.ToString() + ":" + scoreEmeny.ToString();
    }
    public void Kill(bool start)
    {
        if(start)
        scorePlaer++;
        ScoreText();
    }
    private void KillPlayer(bool start)
    {
        if (start)
         scoreEmeny++;
        ScoreText();     
    }
}
