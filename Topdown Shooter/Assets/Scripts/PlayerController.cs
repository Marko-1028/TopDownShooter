using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 moveVector;

    [Header("Mouse visibility")]
    
    [Header("Player Components")]
    Rigidbody2D playerRb;

    [Header("Aim")]
    [SerializeField] Transform crosshair;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject crosshairOnMouse;
    AudioSource audioSource;
    [SerializeField] AudioClip Gun;

    void Update()
    {
        //Hämta muspositionen i världen
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0;
        crosshair.transform.position = mouseWorldPos;

        //Rotera spelaren mot musen
        Vector2 direction = mouseWorldPos - transform.position;
        transform.right = direction;

        crosshairOnMouse.transform.position = mouseWorldPos;

        
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            audioSource.PlayOneShot(Gun);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        playerRb.linearVelocity = moveVector * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ZombieController>())
        {
            Cursor.visible = true;
            SceneManager.LoadScene(1);
        }
    }
}
