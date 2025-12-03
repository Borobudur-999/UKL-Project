using UnityEngine;

public class OreBlock : MonoBehaviour
{
    public int coinReward = 1;  // coin untuk block ini
    public string oreType;       // nama ore / layer

    private void OnDestroy()
    {
        // add coin ke CoinManager saat dihancurkan
        CoinManager.instance.AddCoin(coinReward);
    }
}
