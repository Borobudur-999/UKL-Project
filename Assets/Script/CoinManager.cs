using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinText;

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = coins.ToString();
    }
}
