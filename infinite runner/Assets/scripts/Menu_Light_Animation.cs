using UnityEngine;

public class Menu_Light_Animation : MonoBehaviour
{
    private Vector3 rotateLight;
    void Update()
    {
        rotateLight += Vector3.up;
        transform.rotation = Quaternion.Euler(rotateLight);
    }
}
