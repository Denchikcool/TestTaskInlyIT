using UnityEngine;

public class KeyboardInput : InputHandler
{
    public override void Enable() => enabled = true;
    public override void Disable() => enabled = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) Notify(-1f * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) Notify(1f * Time.deltaTime);
    }
}