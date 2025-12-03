using UnityEngine;

public class DestroyChamber : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(collision.gameObject);
        }
    }
}
