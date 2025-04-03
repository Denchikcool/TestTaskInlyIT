using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRunner : MonoBehaviour
{
    [SerializeField] 
    private Transform[] _blocks;
    [SerializeField] 
    private float _blockLength = 10f;
    [SerializeField] 
    private float _playerSpeed = 5f;

    private void Update()
    {
        foreach (var block in _blocks)
        {
            block.Translate(Vector3.back * _playerSpeed * Time.deltaTime);

            if (block.position.z < -_blockLength)
            {
                block.position += Vector3.forward * (_blocks.Length * _blockLength);
            }
        }
    }
}
