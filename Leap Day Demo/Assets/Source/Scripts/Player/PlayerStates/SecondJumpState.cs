public class SecondJumpState : State
{
    private PlayerMovment _playerMovment;
    public SecondJumpState(PlayerMovment playerMovment)
    {
        _playerMovment = playerMovment;
    }
    public override void Enter()
    {
        base.Enter(); 
        _playerMovment.SecondJump();
    }   
}