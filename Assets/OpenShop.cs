using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    public GameObject _panelShop;

    void Start()
    {
        _panelShop.SetActive(false);
    }

    public void Shop()
    {
        _panelShop.SetActive(true);
    }

    public void CloseShop()
    {
        _panelShop.SetActive(false);
    }
}
