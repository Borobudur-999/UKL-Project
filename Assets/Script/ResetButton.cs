using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void ResetGameOnly()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
