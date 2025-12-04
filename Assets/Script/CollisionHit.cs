using UnityEngine;

public class CollisionHit : MonoBehaviour
{
    public float _boundForce = 10;
    private Rigidbody2D _rb;
    public CoinManager coinManager;

    [Header("Player Movement")]
    public float moveSpeed = 5f;  // kecepatan geser kiri/kanan

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

       if (collision.gameObject.CompareTag("Obstacle"))
    {
        Vector2 blockPos = collision.gameObject.transform.position;


        // PANGGIL MINING SYSTEM
        miningSystem.MineBlock(blockPos);

        return;
    }
    
    if (collision.gameObject.CompareTag("TNT"))
{
    PlayerPickaxeManager pick = FindAnyObjectByType<PlayerPickaxeManager>();
    pick.currentDurability = 0;
    pick.CheckPickaxeStatus();

    Destroy(collision.gameObject);
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