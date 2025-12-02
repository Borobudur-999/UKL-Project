using UnityEngine;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour
{
    public SOSmeltRecipe recipe;
    public Smelter smelter;
    public Image icon;

    void Start()
    {
        icon.sprite = recipe.oreSprite;
    }

    public void OnClick()
    {
        smelter.SelectRecipe(recipe);
    }
}
