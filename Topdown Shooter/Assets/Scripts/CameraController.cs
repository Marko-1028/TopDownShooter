using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] Vector3 offset;
    void Start()
    {
        playerTransform = FindAnyObjectByType<PlayerController>().transform;
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
