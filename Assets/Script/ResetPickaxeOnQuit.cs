using UnityEngine;

public class ResetPickaxeOnQuit : MonoBehaviour
{
    private const string TierKey = "PickaxeTier";
    private const string DurabilityKey = "PickaxeDurability";

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(TierKey);
        PlayerPrefs.DeleteKey(DurabilityKey);
        PlayerPrefs.Save();

        Debug.Log("Pickaxe tier dan durability di-reset karena keluar game.");
    }
}
