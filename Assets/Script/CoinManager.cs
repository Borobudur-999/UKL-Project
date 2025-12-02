using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinText;

    void Start()
    {
        // Load coin kalau ada
        coins = PlayerPrefs.GetInt("Coins", 0);
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        PlayerPrefs.SetInt("Coins", coins);  // langsung save
        UpdateUI();
    }

    public void ResetCoinOnExit()
    {
        PlayerPrefs.SetInt("Coins", 0);
    }

    void UpdateUI()
    {
        coinText.text = coins.ToString();
    }
}
