using UnityEngine;

public class repair_animation_script : MonoBehaviour
{
    private Vector3 rotateWrench;
    void Update()
    {
        rotateWrench += Vector3.up;
        transform.rotation = Quaternion.Euler(rotateWrench);
    }
}
