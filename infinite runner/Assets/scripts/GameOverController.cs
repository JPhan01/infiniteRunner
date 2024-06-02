using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private bool ScoreValidated = false;
    private void Start()
    {
        ScoreValidated = false;
        
        var scores = DBManager.topScores(3);
        foreach (var score in scores)
        {

        }
    }
    public void Retry() => SceneManager.LoadScene("Game");
    public void Menu() => SceneManager.LoadScene("Menu");
    public void OnValidate()
    {
        //DBManager.InsertNewScore(inputName, ship_controller.travelDistance);
        ScoreValidated = true;
        //UI_InputWindow.Hide();
    }
}
