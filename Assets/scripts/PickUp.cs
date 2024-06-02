using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int repairAmount = 1;
    [SerializeField] private GameObject fx;
    public static int nmbRepair { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        ship_controller ship = other.GetComponent<ship_controller>();

        if (ship)
        {
            if (fx != null)
            {
                var newfx = Instantiate(fx,transform.position, Quaternion.identity);
                Destroy(newfx, 1f);
            }
            ship.Repair(repairAmount);
            nmbRepair++;
            Destroy(gameObject);
        }
    }
}
