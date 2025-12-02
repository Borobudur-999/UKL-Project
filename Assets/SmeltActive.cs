using UnityEngine;
using UnityEngine.UI;

public class SmeltActive : MonoBehaviour
{
    public Button _button;
    public GameObject _panel;
    public float _y;

    void Start()
    {
        _button.onClick.AddListener(OpenSmelt);
    }

    void OpenSmelt()
    {
        Debug.Log("open");
        _panel.transform.Translate(0, _y, 0);
    }
}
