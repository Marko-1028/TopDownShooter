using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody2D bulletRb;
    public int damageAmount;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = transform.right * bulletSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Destroy(gameObject);
    }
}
