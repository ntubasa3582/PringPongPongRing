using UnityEngine;

public class JustJump : MonoBehaviour
{
    PlayerController _playerController;
    [SerializeField] private float _jumpBoostAmount = 20f;
    bool _isJumpingBoost = false;

    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetAxisRaw("Jump") != 0)
        {
            if (_playerController != null && !_isJumpingBoost)
            {
                _playerController.JumpPowerChange(_jumpBoostAmount);
                _isJumpingBoost = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //_isJumpingBoost‚ªtrue‚ÌŽž’n–Ê‚©‚ç—£‚ê‚½‚çƒWƒƒƒ“ƒv—Í‚ðŒ³‚É–ß‚·
        if (_isJumpingBoost)
        { 
            if (other.gameObject.CompareTag("Ground"))
            {
                _playerController.JumpPowerChange(-_jumpBoostAmount);
                _isJumpingBoost = false;
            }
        }
    }
}
