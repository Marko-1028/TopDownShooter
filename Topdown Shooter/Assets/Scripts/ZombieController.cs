using UnityEngine;

public class ZombieController : MonoBehaviour
{
    Rigidbody2D zombieRb;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform playerTransform;

    void Start()
    {
        zombieRb = GetComponent<Rigidbody2D>();
        playerTransform = FindAnyObjectByType<PlayerController>().transform;
        
    }

    void Update()
    {
        Vector2 direction = playerTransform.position - transform.position;
        transform.right = direction;
        zombieRb.linearVelocity = direction * moveSpeed;
    }


}
