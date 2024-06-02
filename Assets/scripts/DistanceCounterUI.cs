using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DistanceCounterUI : MonoBehaviour
{
    private TMP_Text distanceCounter;

    void Start()
    {
        distanceCounter = GetComponent<TMP_Text>();
    }

    public void UpdateDistance(float distanceTraveled)
    {
        if (distanceTraveled < 1000) distanceCounter.text = distanceTraveled.ToString("F2") + "m";
        else if (distanceTraveled >= 1000)
        {
            distanceTraveled /= 1000;
            distanceCounter.text = distanceTraveled.ToString("F1") + "km";
        }
    }
}
