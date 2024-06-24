using TMPro;
using UnityEngine;

public class RepairCounter : MonoBehaviour
{
    private TMP_Text repairCounter;
    void Start()
    {
        repairCounter = GetComponent<TMP_Text>();
        repairCounter.text = PickUp.nmbRepair.ToString();
    }
}
