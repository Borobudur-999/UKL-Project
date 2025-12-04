using UnityEngine;

public class OreBlock : MonoBehaviour
{
    [Header("Block Stats")]
    public float maxHP = 20;        // ketahanan ore
    private float currentHP;

    [Header("Reward")]
    public int coinReward = 1;      // coin yang diberikan

    void Start()
    {
        currentHP = maxHP;
    }

    // Dipanggil oleh MiningSystem ketika pickaxe menyerang block ini
    public bool Hit(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    void Die()
    {
        // kasih coin ketika hancur
        CoinManager.instance.AddCoin(coinReward);

        Destroy(gameObject);
    }
}
