using UnityEngine;
using TMPro;
public class MaxSpeedCounter : MonoBehaviour
{
    private TMP_Text maxSpeedCounter;
    void Start()
    {
        maxSpeedCounter = GetComponent<TMP_Text>();
        maxSpeedCounter.text = ship_controller.maxSpeedCounter.ToString("F3") + " m/s";
    }
}