using UnityEngine;
using TMPro;

public class ThisRunScore : MonoBehaviour
{
    private TMP_Text distanceCounter;
    void Start()
    {
        distanceCounter = GetComponent<TMP_Text>();
        FinalDistance(ship_controller.travelDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FinalDistance(float distanceTraveled)
    {
        distanceCounter.text = distanceTraveled.ToString("F2") + "m";
    }

}
