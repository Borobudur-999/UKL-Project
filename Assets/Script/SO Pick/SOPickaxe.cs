using UnityEngine;

[CreateAssetMenu(menuName = "SO/Pickaxe")]
public class SOPickaxe : ScriptableObject
{
    public string pickName;
    public Sprite sprite;

    [Header("Stats")]
    public float damage = 1;
    public int radius = 1;  // Ability utama
    public float maxDurability = 100;

    [Header("Upgrade")]
    public int upgradeCost;
}
