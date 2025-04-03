using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 5f;
    private float _targetPositionX;
    private const float _minX = -6f;
    private const float _maxX = 6f;

    private void OnEnable()
    {
        // Подписываемся на события ввода
        FindObjectOfType<KeyboardInput>().OnMoveEvent += HandleMove;
        FindObjectOfType<DragInput>().OnMoveEvent += HandleMove;
        FindObjectOfType<SwipeInput>().OnMoveEvent += HandleMove;
    }

    private void OnDisable()
    {
        // Отписываемся при выключении
        var inputs = FindObjectsOfType<InputHandler>();
        foreach (var input in inputs)
        {
            input.OnMoveEvent -= HandleMove;
        }
    }

    private void HandleMove(float direction)
    {
        _targetPositionX = Mathf.Clamp(_targetPositionX + direction, _minX, _maxX);
    }

    private void Update()
    {
        float newX = Mathf.Lerp(transform.position.x, _targetPositionX, _lerpSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}