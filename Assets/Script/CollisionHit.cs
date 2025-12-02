using UnityEngine;

public class CollisionHit : MonoBehaviour
{
    public float _boundForce = 10;
    private Rigidbody2D _rb;
    public CoinManager coinManager;

    void Start()
    {
        _rb = FindAnyObjectByType<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;

        if (coinManager != null)
        {
            // cek layer → kasih coin sesuai tabel
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

        // destroy obstacle
        Destroy(collision.gameObject);

        // bounce effect
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _boundForce, ForceMode2D.Impulse);
    }
}
