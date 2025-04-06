public interface IControlHandler
{
    void HandleInput();
    bool IsActive { get; }
}