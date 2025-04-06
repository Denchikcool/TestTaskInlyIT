using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float _lerpSpeed = 3f;
    [SerializeField] 
    private float _minX = -6f;
    [SerializeField] 
    private float _maxX = 6f;

    private float _targetX;
    public float CurrentX => transform.position.x;

    private void Update()
    {
        float newX = Mathf.Lerp(transform.position.x, _targetX, _lerpSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    public void MoveTo(float targetX)
    {
        _targetX = Mathf.Clamp(targetX, _minX, _maxX);
    }

    public void ResetToCenter()
    {
        _targetX = 0f;
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    }
}