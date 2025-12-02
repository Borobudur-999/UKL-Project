using UnityEngine;

public class ResetOnQuit : MonoBehaviour
{
    public CoinManager coinManager;

    private void OnApplicationQuit()
    {
        coinManager.ResetCoinOnExit();
    }
}
