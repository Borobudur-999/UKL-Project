using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public PlayerPickaxeManager pickManager;

    public void OnUpgradeButton()
    {
        pickManager.UpgradePickaxe();
    }
}
