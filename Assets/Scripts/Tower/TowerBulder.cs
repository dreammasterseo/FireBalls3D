using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Color[] _colors;
    private List<Block> _blocks;

    public List<Block> Build()
    {
        _blocks = new List<Block>();
        Transform currentPoint = _buildPoint;
        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlok(currentPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        return _blocks;
    }

    private Block BuildBlok(Transform buildCurrentPoint)
    {
        return Instantiate(_block, GetBuilderPoint(buildCurrentPoint), Quaternion.identity, _buildPoint);
      
    }

    private Vector3 GetBuilderPoint(Transform currentSigment)
    {
        return new Vector3(_buildPoint.transform.position.x, currentSigment.transform.position.y + 0.3f, _buildPoint.position.z);
    }
}
