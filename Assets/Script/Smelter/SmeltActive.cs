using UnityEngine;
using UnityEngine.UI;

public class SmeltActive : MonoBehaviour
{
    public Button _button;
    public GameObject _panel;
    public float _y;

    private bool isOpen = false;

    void Start()
    {
        _button.onClick.AddListener(OpenSmelt);
    }

    void OpenSmelt()
    {
        // cek apakah panel sudah terbuka
        if (isOpen) return;

        isOpen = true;                     // tandai sudah membuka panel
        _button.interactable = false;      // matikan tombol biar tidak bisa dipencet lagi

        // buka panel
        // Debug.Log("open");
        _panel.transform.Translate(0, _y, 0);
    }

    public void CloseSmelt()
    {
        isOpen = false;                    // panel sudah ditutup
        _button.interactable = true;       // tombol aktif kembali

        _panel.transform.Translate(0, -_y, 0);
    }
}
