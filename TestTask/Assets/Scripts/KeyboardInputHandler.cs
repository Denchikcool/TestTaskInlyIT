using UnityEngine;

public class KeyboardInputHandler : BaseInputHandler
{
    private bool _isEnabled;

    public override void Enable() => _isEnabled = true;
    public override void Disable() => _isEnabled = false;

    public override void HandleInput()
    {
        if (!_isEnabled) return;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Player.MoveContinuous(-1f); // Движение влево пока зажата клавиша
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Player.MoveContinuous(1f); // Движение вправо пока зажата клавиша
        }
    }
}