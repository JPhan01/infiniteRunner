using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InputWindow : MonoBehaviour
{
    public bool clearToValidate;

    public void validate()
    {
        if (clearToValidate) Hide();
    }

    public void Awake()
    {
        Show();
    }
    public void Start()
    {
        clearToValidate= false;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void RegisterName(string name)
    {
        if (name !=null) 
        {
            GameOverController.inputName = name;
            clearToValidate = true;
        }
    }
}
