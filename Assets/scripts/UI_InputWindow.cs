using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InputWindow : MonoBehaviour
{
    private TMP_InputField inputField;
    public void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
        Show();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
