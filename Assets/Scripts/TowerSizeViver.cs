using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TowerSizeViver : MonoBehaviour
{
   [SerializeField] private TMP_Text _sizeBilder;
   [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.SizeUpdate += OnSizeUpdate;
    }

    private void OnDisable()
    {
        _tower.SizeUpdate -= OnSizeUpdate;
    }

    private void OnSizeUpdate(int size)
    {
        _sizeBilder.text = size.ToString();
    }
}
