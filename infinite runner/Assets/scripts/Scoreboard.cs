using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private TMP_Text scoreDisplay;
    private void Start()
    {
        ScoreDisplay();
    }
    public void ScoreDisplay()
    {
        scoreDisplay = GetComponent<TMP_Text>();
        var scores = DBManager.scores;

        for (int i = 1; i < scores.Count; i++)
        {
            if (scores[i] != null)
            {
                //Debug.Log(scores[i].name + " " + scores[i].score);
                var scoreText = scores[i].name + " " + scores[i].score;
                scoreDisplay.text = scoreText.ToString();
            }
        }
    }
}
