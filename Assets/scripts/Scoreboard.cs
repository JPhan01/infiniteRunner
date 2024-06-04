using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class Scoreboard : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < 10; i++) 
        {
            if (DBManager.scores[i] != null) Debug.Log(DBManager.scores[i]);
        }
    }
}
