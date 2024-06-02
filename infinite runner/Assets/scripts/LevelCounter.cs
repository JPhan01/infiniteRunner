using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    private TMP_Text levelCounter;
    void Start()
    {
        levelCounter = GetComponent<TMP_Text>();
        levelCounter.text = GameController.instance.level.ToString();
    }
}
