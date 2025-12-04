using UnityEngine;

public class StartGameUI : MonoBehaviour
{
    public GameObject startButton;
    public GameObject shopButton;
    public GameObject smeltButton;

    void Start()
    {
         Time.timeScale = 0f;
        // AWAL GAME:
        startButton.SetActive(true);   // Start MUNCUL
        shopButton.SetActive(true);   // Shop HILANG
        smeltButton.SetActive(true);  // Smelt HILANG
    }

    public void OnStartButton()
    {
        Time.timeScale = 1f;
        // Start hilang
        startButton.SetActive(false);

        // Shop & Smelt muncul
        shopButton.SetActive(false);
        smeltButton.SetActive(false);
    }
}
