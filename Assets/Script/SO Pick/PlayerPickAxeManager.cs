using UnityEngine;

public class PlayerPickaxeManager : MonoBehaviour
{
    public SOPickaxe[] pickList;
    public int currentTier = 0;
    public float currentDurability;

    public GameObject brokenPanel;

    public SOPickaxe Current => pickList[currentTier];

    // AMBIL radius dari SO
    public int CurrentRadius => Current.radius;

    void Start()
    {
        currentDurability = Current.maxDurability;
    }

    // 🔥 Tambahkan fungsi ini
    public bool CanMine()
    {
        return currentDurability > 0;
    }

    public bool UpgradePickaxe()
    {
        if (currentTier >= pickList.Length - 1)
        {
            Debug.Log("Pickaxe sudah MAX LEVEL!");
            return false;
        }

        var nextPick = pickList[currentTier + 1];
        int cost = nextPick.upgradeCost;

        if (!CoinManager.instance.SpendCoin(cost))
        {
            Debug.Log("💰 Uang tidak cukup untuk upgrade!");
            return false;
        }

        currentTier++;
        currentDurability = Current.maxDurability;

        Debug.Log("🔥 Pickaxe di-upgrade ke: " + Current.pickName);
        return true;
    }

    public void ReduceDurability(int amount)
    {
        currentDurability -= amount;

        if (currentDurability <= 0)
        {
            currentDurability = 0;

            // Munculin UI
            if (brokenPanel != null)
                brokenPanel.SetActive(true);

            // Freeze game
            Time.timeScale = 0f;

            Debug.Log("Pickaxe rusak! Game freeze.");
        }
    }
}
