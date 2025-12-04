using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quit pressed!");

        // Keluar game (hanya berfungsi di build)
        Application.Quit();
    }
}
