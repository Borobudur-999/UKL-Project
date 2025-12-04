using UnityEngine;

public class TNTBehavior : MonoBehaviour
{
    public float explosionRadius = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        Debug.Log("TNT meledak!");

        PlayerPickaxeManager pick = FindAnyObjectByType<PlayerPickaxeManager>();

        if (pick != null)
        {
            pick.currentDurability = 0;
            pick.CheckPickaxeStatus();
        }

        Destroy(gameObject);
    }
}

}
