using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;
    public event UnityAction<Block> BulletHit;

    private MeshRenderer _blockColor;
    private void Awake()
    {
        _blockColor = GetComponent<MeshRenderer>();
    }
    public void SetColor(Color color)
    {
        _blockColor.material.color = color;
    }
    public void Break()
    {
        BulletHit?.Invoke(this);
       var renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = _blockColor.material.color;
        Destroy(gameObject);
    }
}
