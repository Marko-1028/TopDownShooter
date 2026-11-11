using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject pickUpPrefab;
    [SerializeField] Animator anim;

    public GameManager GameManager { get; private set; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        GameManager = FindAnyObjectByType<GameManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= collision.gameObject.GetComponent<Bullet>().damageAmount;
            anim.SetTrigger("Damage");
            if (hp <= 0)
            {
                GameManager.AddScore(1);
                Destroy(gameObject);
                if (Random.Range(1, 3) == 1)
                {
                    Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
