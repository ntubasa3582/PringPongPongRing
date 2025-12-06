using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerSpeedUpItem : ItemBase
{
    [SerializeField] private float _speedUpAmount = default;
    [SerializeField] private int _destroyDuration = default;
    public override void GetItem()
    {
        Debug.Log("Speed Up Item Get");
        _playerController.SpeedChange(_speedUpAmount);
        ItemDestroy();
    }
    public async Task ItemDestroy()
    {
        gameObject.SetActive(false);
        await UniTask.Delay(TimeSpan.FromSeconds(_destroyDuration));
        _playerController.SpeedChange(-_speedUpAmount);
        Destroy(this.gameObject);
    }
}
