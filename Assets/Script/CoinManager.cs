using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int coins;
    public TextMeshProUGUI coinText;

void Start()
{
    // Pastikan UI text di scene baru terhubung
    coinText = GameObject.FindWithTag("CoinText")?.GetComponent<TextMeshProUGUI>();
    UpdateUI();
}

    void Awake()
{
    Debug.Log("CoinManager Awake: " + gameObject.name);

    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Debug.Log("Duplicate CoinManager found → destroyed");
        Destroy(gameObject);
        return;
    }

    LoadCoins();
}


    public void AddCoin(int amount)
    {
        coins += amount;
        SaveCoins();
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (coinText != null)
            coinText.text = coins.ToString();
    }

    void SaveCoins()
    {
        PlayerPrefs.SetInt("Coin", coins);
        PlayerPrefs.Save();
    }

    void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coin", 0);
    }
}
