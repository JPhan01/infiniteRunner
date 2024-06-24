using UnityEngine.UI;
using UnityEngine;
public class health_bar_script : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
