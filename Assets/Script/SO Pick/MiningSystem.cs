using UnityEngine;

public class MiningSystem : MonoBehaviour
{
    public int radiusLevel = 1;       // 1, 2, 3
    public float blockDistance = 1f;  // jarak antar blok
    public LayerMask blockLayer;      // layer ore kamu (6,7,8,...)

    public Transform player;
    public Vector2 facing = Vector2.down; // player mining ke bawah
    public PlayerPickaxeManager pickManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MineBlocks();
        }
    }

    public void MineBlocks()
    {
        int r = pickManager.CurrentRadius;

        switch (r)
        {
            case 1: MineRadius1(); break;
            case 2: MineRadius2(); break;
            case 3: MineRadius3(); break;
        }
    }

    void TryBreak(Vector2 offset)
    {
        Vector2 targetPos = (Vector2)player.position + offset;

        Collider2D hit = Physics2D.OverlapPoint(targetPos, blockLayer);

        if (hit != null)
        {
            Destroy(hit.gameObject);
        }
    }

    // ------------------ RADIUS 1 ------------------
    void MineRadius1()
    {
        TryBreak(new Vector2(0, -blockDistance)); 
    }

    // ------------------ RADIUS 2 ------------------
    void MineRadius2()
    {
        // row tengah (3 blok)
        TryBreak(new Vector2(-blockDistance, -blockDistance));
        TryBreak(new Vector2(0, -blockDistance));
        TryBreak(new Vector2(blockDistance, -blockDistance));

        // blok bawah
        TryBreak(new Vector2(0, -blockDistance * 2));
    }

    // ------------------ RADIUS 3 ------------------
    void MineRadius3()
    {
        // XPX
        TryBreak(new Vector2(-blockDistance, -blockDistance));
        TryBreak(new Vector2(blockDistance, -blockDistance));

        // XXX (row 2)
        TryBreak(new Vector2(-blockDistance, -blockDistance * 2));
        TryBreak(new Vector2(0, -blockDistance * 2));
        TryBreak(new Vector2(blockDistance, -blockDistance * 2));

        // XXX (row 3)
        TryBreak(new Vector2(-blockDistance, -blockDistance * 3));
        TryBreak(new Vector2(0, -blockDistance * 3));
        TryBreak(new Vector2(blockDistance, -blockDistance * 3));
    }
}
