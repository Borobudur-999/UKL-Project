using UnityEngine;

[CreateAssetMenu(menuName = "SO/Smelt Recipe")]
public class SOSmeltRecipe : ScriptableObject
{
    public Sprite oreSprite;
    public Sprite outputSprite;

    public int oreNeeded = 1;
    public int coalNeeded = 1;
}
