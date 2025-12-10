using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActiveMenu : MonoBehaviour
{
    public GameObject _p;
    public string scene;
    public void Start()
    {
        _p.SetActive(false);
    }
    public void Gameplay()
    {
        SceneManager.LoadScene(scene);
    }

    public void Open()
    {
        _p.SetActive(true);
    }
    public void Opepn()
    {
        _p.SetActive(false);
    }
}
