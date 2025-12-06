using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;
public class ItemBase : MonoBehaviour
{
    protected PlayerController _playerController;
    /// <summary>
    /// // ƒAƒCƒeƒ€æ“¾‚Ìˆ—
    /// </summary>
    public virtual void GetItem()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerController = other.gameObject.GetComponent<PlayerController>();
            GetItem();
        }
    }
}
