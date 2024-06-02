using UnityEngine;

public class Scroll_Script : MonoBehaviour
{
    public Transform chunksContainer;

    public void Forward(Vector3 velocity)
    {
        foreach (Transform child in chunksContainer)
        {
            child.position += velocity;
        }
    }

}
