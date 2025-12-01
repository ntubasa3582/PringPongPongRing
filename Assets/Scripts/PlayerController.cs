using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody _rb;
    private Vector3 _moveVector;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        _moveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.linearVelocity = _moveVector.normalized * speed;
    }
}
