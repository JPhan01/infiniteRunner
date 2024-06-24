using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public static bool scoreValidated = false;
    public UnityEvent validate;
    public static string inputName;
    private void Start()
    {
        scoreValidated = false;
    }
    public void Retry()  
    { 
        if (scoreValidated) SceneManager.LoadScene("Game"); 
    }
    public void Menu() 
    { 
        if (scoreValidated) SceneManager.LoadScene("Menu"); 
    }
    public void Validate()
    {
        validate.Invoke();
        DBManager.InsertNewScore(inputName, (int)ship_controller.travelDistance);
        scoreValidated = true;
    }
}
