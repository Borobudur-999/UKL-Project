using UnityEngine;

public class Smelter : MonoBehaviour
{
    public SmeltSlot inputOre;
    public SmeltSlot inputCoal;
    public SmeltSlot output;

    public SOSmeltRecipe selectedRecipe;

    public void SelectRecipe(SOSmeltRecipe recipe)
    {
        selectedRecipe = recipe;

        // auto-set input slot
        inputOre.Set(recipe.oreSprite, recipe.oreNeeded);
        inputCoal.Set(null, recipe.coalNeeded); // ikon coal nanti
    }

    public void Smelt()
    {
        if (selectedRecipe == null)
        {
            Debug.Log("Belum memilih recipe.");
            return;
        }

        if (inputOre.amount < selectedRecipe.oreNeeded ||
            inputCoal.amount < selectedRecipe.coalNeeded)
        {
            Debug.Log("Bahan kurang.");
            return;
        }

        inputOre.amount -= selectedRecipe.oreNeeded;
        inputCoal.amount -= selectedRecipe.coalNeeded;

        output.icon.sprite = selectedRecipe.outputSprite;
        output.amount += 1;

        Debug.Log("Smelting berhasil!");
    }
}
