using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerSpeedUpItem : ItemBase
{
    [SerializeField] private float _speedUpAmount = 10;
    public override void GetItem()
    {
        _playerController.SpeedChange(_speedUpAmount);
        Destroy(this.gameObject);
        Debug.Log("Speed Up Item Acquired!");
    }
}
