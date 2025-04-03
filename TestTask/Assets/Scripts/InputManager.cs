using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    public void SetInput(InputHandler newInput)
    {
        // Просто передаем управление игроку
        newInput.Initialize(_player);
    }
}