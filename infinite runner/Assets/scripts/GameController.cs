using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    public UnityEvent stormAdvancing;

    public float distance { get; private set; } = 0f;
    public int level { get; private set; } = 1;
    [SerializeField] public float distanceToLevel = 500;
    private void Awake()
    {
        if (instance !=null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Reset();
    }
    public void LevelUp()
    {
        level++;
        stormAdvancing.Invoke();
    }

    public void SetDistance(float dist) => distance = dist;
    public void Reset()
    {
        distance = 0f;
        level = 1;
    }
}
