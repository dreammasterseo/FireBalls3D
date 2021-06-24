using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _seconds;
    [SerializeField] private float _recoil;
    private float currentTime = 0;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > _seconds)
        {
            if(Input.GetMouseButton(0))
            {
                currentTime = 0;
                transform.DOMoveZ(transform.position.z - _recoil, _seconds / 2).SetLoops(2, LoopType.Yoyo);
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        
    }
}
