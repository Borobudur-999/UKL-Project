using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActiveMenu : MonoBehaviour
{
    public string scene;
    public void Gameplay()
    {
        SceneManager.LoadScene(scene);
    }
}
