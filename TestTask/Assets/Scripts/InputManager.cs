using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    public void SetInput(InputHandler newInput)
    {
        // ������ �������� ���������� ������
        newInput.Initialize(_player);
    }
}