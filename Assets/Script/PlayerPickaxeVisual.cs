using UnityEngine;

public class PlayerPickaxeVisual : MonoBehaviour
{
    public PlayerPickaxeManager pickManager;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        if (spriteRenderer != null)
            spriteRenderer.sprite = pickManager.Current.sprite;
    }
}
