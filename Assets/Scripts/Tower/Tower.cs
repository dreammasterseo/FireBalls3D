using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBulder))]
public class Tower : MonoBehaviour
{
    private TowerBulder _towerBulder;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdate;
    private void Start()
    {
        _towerBulder = GetComponent<TowerBulder>();
      _blocks = _towerBulder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        SizeUpdate?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block hitBlock)
    {
        hitBlock.BulletHit -= OnBulletHit;
        _blocks.Remove(hitBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - 0.3f, block.transform.position.z);
        }

        SizeUpdate?.Invoke(_blocks.Count);
    }
}
