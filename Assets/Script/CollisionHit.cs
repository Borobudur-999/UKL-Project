using UnityEngine;

public class CollisionHit : MonoBehaviour
{
    public float _boundForce = 10;
    private Rigidbody2D _rb;
    public CoinManager coinManager;

    [Header("Player Movement")]
    public float moveSpeed = 5f;  // kecepatan geser kiri/kanan

    [Header("Fungcion")]
    public MiningSystem miningSystem;   // drag dari inspector
    public PlayerPickaxeManager pickManager; // drag juga

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // ambil input kiri-kanan (A/D atau arrow)
        float xInput = Input.GetAxisRaw("Horizontal");

        // ubah kecepatan sumbu X saja → sumbu Y tidak diganggu
        _rb.velocity = new Vector2(xInput * moveSpeed, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;

        if (coinManager != null)
        {
            switch (layer)
            {
                case 6: coinManager.AddCoin(1); break;    // Stone
                case 7: coinManager.AddCoin(3); break;    // Copper
                case 8: coinManager.AddCoin(7); break;    // Iron
                case 9: coinManager.AddCoin(15); break;   // Silver
                case 10: coinManager.AddCoin(30); break;  // Gold
                case 11: coinManager.AddCoin(80); break;  // Crystal
                case 12: coinManager.AddCoin(150); break; // Mythril
            }
        }

       if (collision.gameObject.CompareTag("Obstacle"))
    {
        Vector2 blockPos = collision.gameObject.transform.position;


        // PANGGIL MINING SYSTEM
        miningSystem.MineBlock(blockPos);

        return;
    }

    // bounce
    _rb.velocity = new Vector2(_rb.velocity.x, 0);
    _rb.AddForce(Vector2.up * _boundForce, ForceMode2D.Impulse);

    // bounce effect
    _rb.velocity = new Vector2(_rb.velocity.x, 0);
    _rb.AddForce(Vector2.up * _boundForce, ForceMode2D.Impulse);


        // bounce effect
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _boundForce, ForceMode2D.Impulse);
    }
}
