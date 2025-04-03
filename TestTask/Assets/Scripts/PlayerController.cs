using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float _moveSpeed = 5f;
    [SerializeField] 
    private float _lerpSpeed = 3f;
    private float _targetPositionX;
    private const float _minX = -6f;
    private const float _maxX = 6f;

    private void Start()
    {
        _targetPositionX = transform.position.x;
    }

    private void Update()
    {
        float newX = Mathf.Lerp(transform.position.x, _targetPositionX, _lerpSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    public void MoveTo(float direction)
    {
        _targetPositionX = Mathf.Clamp(_targetPositionX + direction, _minX, _maxX);
    }

    public void SetTargetPosition(float targetX)
    {
        _targetPositionX = Mathf.Clamp(targetX, _minX, _maxX);
    }
}
