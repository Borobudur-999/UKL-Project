using UnityEngine;
using UnityEngine.UI;

public class SmeltSlot : MonoBehaviour
{
    public Image icon;
    public int amount;

    public void Set(Sprite sprite, int value)
    {
        icon.sprite = sprite;
        amount = value;
    }

    public void Add(int value)
    {
        amount += value;
    }
}
