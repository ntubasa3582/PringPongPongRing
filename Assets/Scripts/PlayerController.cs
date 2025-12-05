using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpPower = 30f;
    private Rigidbody _rb;
    Camera _camera;
    private Vector3 _moveVector;
    private Vector3 _moveVelocity;
    private bool _isGrounded = false;

    void Start()
    {
        _camera = GetComponent<Camera>();
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerJump()
    {
        _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        _isGrounded = false;
    }

    void PlayerMove()
    {
        _camera = Camera.main;
        //上下左右の入力を取得
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        _moveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //カメラの向きを取得
        _moveVector = _camera.transform.TransformDirection(_moveVector);
        _moveVector.Normalize();
        //移動速度を計算
        _moveVelocity = _moveVector * _moveSpeed;
        //Rigidbodyの速度を設定
        _rb.linearVelocity = new Vector3(_moveVelocity.x, _rb.linearVelocity.y, _moveVelocity.z);
        //プレイヤーの向きをカメラの向きに合わせる
        transform.rotation = new Quaternion(0, _camera.transform.rotation.y, 0, _camera.transform.rotation.w);
    }
    void OnCollisionEnter(Collision collision)
    {
        //地面に接触したらジャンプ可能にする
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            PlayerJump();
            Debug.Log(_jumpPower);
        }
    }
    //ジャンプ力を変更するメソッド
    public void JumpPowerChange(float value)
    {
        _jumpPower += value;
    }
}
