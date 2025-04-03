using UnityEngine;

public abstract class BaseInputHandler : MonoBehaviour
{
    protected PlayerController Player;

    public void Initialize(PlayerController player)
    {
        Player = player;
    }

    public abstract void Enable();
    public abstract void Disable();
    public abstract void HandleInput();
}