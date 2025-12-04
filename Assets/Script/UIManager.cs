using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Panels")]
    public GameObject pickaxeBrokenPanel;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ShowPickaxeBroken()
    {
        if (pickaxeBrokenPanel != null)
        {
            pickaxeBrokenPanel.SetActive(true);
            Time.timeScale = 0f; // freeze game
        }
        else
        {
            Debug.LogError("PickaxeBrokenPanel belum di-assign di Inspector!");
        }
    }
}
