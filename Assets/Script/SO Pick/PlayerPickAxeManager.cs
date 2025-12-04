using UnityEngine;

public class PlayerPickaxeManager : MonoBehaviour
{
    public SOPickaxe[] pickList;
    public int currentTier = 0;
    public float currentDurability;

    public GameObject brokenPanel;
    private const string TierKey = "PickaxeTier";
    private const string DurabilityKey = "PickaxeDurability";

        public SOPickaxe Current => pickList[currentTier];

    public UIUpgradeController uiUpgrade;

    void Start()
    {
        LoadPickaxe();
        currentDurability = Current.maxDurability;

        var visual = FindAnyObjectByType<PlayerPickaxeVisual>();
        if (visual != null) visual.UpdateVisual();
    }


    // 🔥 Tambahkan fungsi ini
    public bool CanMine()
        {
            return currentDurability > 0;
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

            // UPDATE VISUAL PICKAXE
            FindAnyObjectByType<PlayerPickaxeVisual>().UpdateVisual();


            Debug.Log("🔥 Pickaxe di-upgrade ke: " + Current.pickName);
            SavePickaxe();
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

    public void SavePickaxe()
    {
        PlayerPrefs.SetInt(TierKey, currentTier);
        PlayerPrefs.SetFloat(DurabilityKey, currentDurability);
        PlayerPrefs.Save();
    }

    public void LoadPickaxe()
    {
        currentTier = PlayerPrefs.GetInt(TierKey, 0);
        currentDurability = PlayerPrefs.GetFloat(DurabilityKey, Current.maxDurability);
    }

    public void CheckPickaxeStatus()
    {
        if (currentDurability <= 0)
        {
            // munculin UI pickaxe hancur
            UIManager.instance.ShowPickaxeBroken();
        }
    }

}
