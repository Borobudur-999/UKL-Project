using UnityEngine;

public class PlayerPickaxeManager : MonoBehaviour
{
    public SOPickaxe[] pickList;
    public int currentTier = 0;
    public float currentDurability;

    public SOPickaxe Current => pickList[currentTier];

    void Start()
    {
        currentDurability = Current.maxDurability;
    }

    public bool UpgradePickaxe()
    {
        // CEK kalau sudah max
        if (currentTier >= pickList.Length - 1)
        {
            Debug.Log("Pickaxe sudah MAX LEVEL!");
            return false;
        }

        var nextPick = pickList[currentTier + 1];
        int cost = nextPick.upgradeCost;

        // CEK uang lewat CoinManager
        if (!CoinManager.instance.SpendCoin(cost))
        {
            Debug.Log("💰 Uang tidak cukup untuk upgrade!");
            return false;
        }

        // UPGRADE
        currentTier++;
        currentDurability = Current.maxDurability;

        Debug.Log("🔥 Pickaxe di-upgrade ke: " + Current.pickName);
        return true;
    }

    public void ReduceDurability(int amount)
    {
        currentDurability -= amount;

        if (currentDurability < 0)
            currentDurability = 0;
    }
}
