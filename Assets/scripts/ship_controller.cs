using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ship_controller : MonoBehaviour
{
    [SerializeField] private float speed = 15f; // speed de base qui ne bouge pas
    public static float maxSpeedCounter { get; private set; }
    [SerializeField] private float accelFactor = 0.01f;
    private float accel = 1f; // utilisé pour l accel speed et direction
    public static float travelDistance { get; private set; }
    private Vector3 currentDirection = Vector3.zero;
    private Vector3 dampVelocity = Vector3.zero;
    [SerializeField] private int bounds = 4;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float dampFactor = 0.08f;

    [SerializeField] private int maxHealth = 10;
    private int health;

    [SerializeField] private Camera MainCam;
    [SerializeField] private Camera NoseCam;

    public UnityEvent<int> onSetHealth;
    public UnityEvent<int> onSetMaxHealth;
    public UnityEvent<Vector3> onSetVelocity;
    public UnityEvent<float> onSetDistanceTraveled;
   
//____________________________________________________

    private MeshRenderer meshRenderer;
    private Color originColor;
    [SerializeField] private float flashTime = 0.1f;
    [SerializeField] private int damage_per_hit = 1;
    private List<Color> originMaterialsColor;

    [SerializeField] private float invicibiltyMaxTime = 1f;
    private float invicibilityTimer;

    void Start()
    {
        health = maxHealth;
        onSetMaxHealth.Invoke(maxHealth);
        maxSpeedCounter = speed * accel;
        travelDistance = 0;
        accel = 1;
//________________________________________________________
        originMaterialsColor = new List<Color>();
        meshRenderer = GetComponent<MeshRenderer>();
        foreach (Material mat in meshRenderer.materials)
        {
            originColor = mat.color;
            originMaterialsColor.Add(originColor);
        }
    }

    void Update()
    {
        MoveCommand();
        CamSwitch();
        onSetHealth.Invoke(health);
        LoseCondition();
        if (maxSpeedCounter < speed * accel) maxSpeedCounter = speed * accel;
        //________________________________________________________
        if (invicibilityTimer > 0)
        {
            invicibilityTimer -= Time.deltaTime * GameController.instance.level;
        }
    }
    public void Repair(int repairAmount)
    {
        if (health < maxHealth) health += repairAmount;
    }
    
    public void MoveCommand()
    {
        var velocity = Vector3.back * speed * accel * Time.deltaTime;
        onSetVelocity.Invoke(velocity); 
        TraveledDistance(velocity.magnitude);

        accel += Time.deltaTime * accelFactor;
        Vector3 targetDirection = Vector3.zero;
        var left = Input.GetKey(KeyCode.LeftArrow);
        var right = Input.GetKey(KeyCode.RightArrow);
        var up = Input.GetKey(KeyCode.UpArrow);
        var down = Input.GetKey(KeyCode.DownArrow);

        if (left && transform.position.x > -bounds) targetDirection += Vector3.left * accel;
        else if (right && transform.position.x < bounds) targetDirection += Vector3.right * accel;
        
        if (up && transform.position.y < 3) targetDirection += Vector3.up * .5f * accel;
        else if (down && transform.position.y > .3f) targetDirection += Vector3.down * .5f * accel;
        
        currentDirection = Vector3.SmoothDamp(currentDirection, targetDirection, ref dampVelocity, dampFactor);
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime, Space.World);
        ApplyTilt();
    }
    public void ApplyTilt()
    {
        float roll = -currentDirection.x * 50f;
        float pitch = -currentDirection.y * 30f;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0, roll);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5f);
    }
    public void CamSwitch()
    {
        var camSwitch = Input.GetKeyDown(KeyCode.C);
        if (camSwitch)
        {
            if (NoseCam.enabled)
            {
                MainCam.enabled = true;
                NoseCam.enabled = false;
            }
            else
            {
                NoseCam.enabled = true;
                MainCam.enabled = false;
            }
        }
    }
    private void LoseCondition()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void TraveledDistance(float dist)
    {
        travelDistance += dist;
        onSetDistanceTraveled.Invoke(travelDistance);
        GameController.instance.SetDistance(travelDistance);
        if (travelDistance > GameController.instance.distanceToLevel * GameController.instance.level)
        {
            GameController.instance.LevelUp();
            accelFactor += 0.5f;
        }
    }
//________________________________________________________
    private void OnTriggerEnter(Collider collider)
    {
        OnHit(collider);
    }
    public void OnHit(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            if (invicibilityTimer <= 0)
            {
                invicibilityTimer = invicibiltyMaxTime;
                health -= damage_per_hit;
                StartCoroutine(FlashMultiple(Color.red));
            }
        }
    }
    public void FlashStartHit(Color color)
    {
        foreach (Material mat in meshRenderer.materials) // chope tout les mat dans le mesh renderer
        {
            mat.color = color;
            Invoke("FlashStop", flashTime);
        }
    }
    public void FlashStop()
    {
        int i = 0;
        foreach (Material mat in meshRenderer.materials)
        {
            mat.color = originMaterialsColor[i];
            i++;
        }
    }
    IEnumerator FlashMultiple(Color color) //utilisé pour le clignotement
    {
        while (invicibilityTimer > 0)
        {
            FlashStartHit(color);
            yield return new WaitForSeconds(flashTime * 2);
        }
    }
}
