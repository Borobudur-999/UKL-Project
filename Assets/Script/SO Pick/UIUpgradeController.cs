using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIUpgradeController : MonoBehaviour
{
    public PlayerPickaxeManager manager;

    [Header("UI Awal")]
    public TextMeshProUGUI pickNameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI abilityText;
    public Image pickIcon;

    [Header("Popup")]
    public GameObject popup;
    public TextMeshProUGUI nextNameText;
    public TextMeshProUGUI nextDamageText;
    public TextMeshProUGUI nextRadiusText;
    public TextMeshProUGUI nextDurabilityText;
    public TextMeshProUGUI nextCostText;
    public Image nextIcon;

    void Start()
    {
        UpdateMainUI();
        popup.SetActive(false);
    }

    public void UpdateMainUI()
    {
        var current = manager.Current;

        pickNameText.text = current.pickName;
        pickIcon.sprite = current.sprite;
        abilityText.text = $"Radius : {current.radius}";

        // Jika belum max
        if (manager.currentTier < manager.pickList.Length - 1)
        {
            var next = manager.pickList[manager.currentTier + 1];
            costText.text = $"Cost : {next.upgradeCost}";
            abilityText.text = $"Radius : {current.radius}";
        }
        else
        {
            costText.text = "MAX";
            abilityText.text = $"Radius : {current.radius}";
        }
    }

    public void OpenPopup()
    {
        if (manager.currentTier >= manager.pickList.Length - 1)
            return;

        var next = manager.pickList[manager.currentTier + 1];

        nextNameText.text = next.pickName;
        nextDamageText.text = $"Damage: {next.damage}";
        nextRadiusText.text = $"Radius: {next.radius}";
        nextDurabilityText.text = $"Durability: {next.maxDurability}";
        nextCostText.text = $"Cost: {next.upgradeCost}";
        nextIcon.sprite = next.sprite;

        popup.SetActive(true);
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
    }

    public void BuyUpgrade()
    {
        if (manager.UpgradePickaxe())
        {
            UpdateMainUI();
        }

        popup.SetActive(false);
    }
}
