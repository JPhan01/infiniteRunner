using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Activate();
        }
    }
    void Activate()
    {
        Debug.Log("space");
    }
}
