using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject pickUpPrefab;
    [SerializeField] Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= collision.gameObject.GetComponent<Bullet>().damageAmount;
            anim.SetTrigger("Damage");
            if (hp <= 0)
            {
                Destroy(gameObject);
                if (Random.Range(1, 3) == 1)
                {
                    Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
