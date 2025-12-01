using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody _rb;
    Camera _camera;
    private Vector3 _moveVector;
    void Start()
    {
        _camera = GetComponent<Camera>();
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _camera = Camera.main;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _moveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _moveVector = _camera.transform.TransformDirection(_moveVector);
        _rb.linearVelocity = _moveVector * speed;
        transform.rotation = new Quaternion(0, _camera.transform.rotation.y, 0, _camera.transform.rotation.w);
    }
}
