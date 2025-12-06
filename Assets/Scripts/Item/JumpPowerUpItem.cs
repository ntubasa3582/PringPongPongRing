using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;


public class JumpPowerUpItem : ItemBase
{
    [SerializeField] private float _jumpPowerUpAmount = default;
    [SerializeField] private int _destroyDuration = default;
    public override void GetItem()
    {
        Debug.Log("Jump Power Up Item Get");
        _playerController.JumpPowerChange(_jumpPowerUpAmount);
        ItemDestroy();
    }
    public async Task ItemDestroy()
    {
        gameObject.SetActive(false);
        await UniTask.Delay(TimeSpan.FromSeconds(_destroyDuration));
        _playerController.JumpPowerChange(-_jumpPowerUpAmount);
        Destroy(this.gameObject);
    }
}
