using UnityEngine;
using UnityEngine.InputSystem;

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
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
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
}
