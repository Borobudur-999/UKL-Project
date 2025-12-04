using UnityEngine;

public class OreBlock : MonoBehaviour
{
    [Header("Block Stats")]
    public float maxHP = 10;
    private float currentHP;

    [Header("Reward")]
    public int coinReward = 1;

    void Start()
    {
        currentHP = maxHP;
    }

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
        CoinManager.instance.AddCoin(coinReward);
        Destroy(gameObject);
    }
}
