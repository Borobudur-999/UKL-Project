using UnityEngine;

public class MiningSystem : MonoBehaviour
{
    public PlayerPickaxeManager pickManager;

    public void MineBlock(Vector2 position)
    {
        // Cek durability sebelum mining
        if (!pickManager.CanMine())
        {
            Debug.Log("Pickaxe sudah rusak!");
            return;
        }

        var pick = pickManager.Current;
        float radius = pick.radius;

        bool hitAnything = false; // track apakah ada block yang kena

        // Hancurkan blok dalam radius lingkaran
        for (float x = -radius; x <= radius; x++)
        {
            for (float y = -radius; y <= radius; y++)
            {
                Vector2 target = position + new Vector2(x, y);

                if (Vector2.Distance(position, target) <= radius)
                {
                    // jika ada block yang kena hit
                    if (DestroyBlockAt(target))
                    {
                        hitAnything = true;
                    }
                }
            }
        }

        // kalau beneran mukul block, baru kurangi durability
        if (hitAnything)
        {
            pickManager.ReduceDurability(1);
        }
    }

    // return true = block kena hit
    bool DestroyBlockAt(Vector2 pos)
    {
        Collider2D hit = Physics2D.OverlapCircle(pos, 0.25f);

        if (hit == null) return false;

        OreBlock block = hit.GetComponent<OreBlock>();
        if (block == null) return false;

        var pick = pickManager.Current;

        // cek damage
        if (pick.damage < block.maxHP)
        {
            Debug.Log("Pickaxe terlalu lemah untuk ore ini!");
            return false;
        }

        // serang block
        block.Hit(pick.damage);

        return true;
    }
}
