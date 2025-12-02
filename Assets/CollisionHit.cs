using UnityEngine;

public class CollisionHit : MonoBehaviour
{
    public float _boundForce = 10;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = FindAnyObjectByType<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);

            _rb.velocity = new Vector2(_rb.velocity.x, 0);

            _rb.AddForce(Vector2.up * _boundForce, ForceMode2D.Impulse);
        }
    }
}
