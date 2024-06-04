using UnityEngine;

public class StormController : MonoBehaviour
{
    public  void stormAdvanceOnLevelUp()
    {
        if (gameObject.transform.position.z > 0) gameObject.transform.Translate(0, gameObject.transform.position.y + 1, 0);
    }
}
