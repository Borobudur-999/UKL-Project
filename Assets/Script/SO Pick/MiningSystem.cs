using UnityEngine;

public class MiningSystem : MonoBehaviour
{
    public PlayerPickaxeManager pickManager;

    public void MineBlock(Vector2 position)
    {
        var pick = pickManager.Current;
        float radius = pick.radius;

        // Hancurkan blok dalam radius lingkaran
        for (float x = -radius; x <= radius; x++)
        {
            for (float y = -radius; y <= radius; y++)
            {
                Vector2 target = position + new Vector2(x, y);

                if (Vector2.Distance(position, target) <= radius)
                {
                    DestroyBlockAt(target);
                }
            }
        }

        pickManager.ReduceDurability(1);
    }

    void DestroyBlockAt(Vector2 pos)
    {
        // logika hancurin block sesuai sistem kamu
        Debug.Log($"Destroy block at {pos}");
    }
}
