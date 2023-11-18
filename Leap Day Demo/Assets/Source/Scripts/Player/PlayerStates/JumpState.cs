public class JumpState:State
{
    private PlayerMovment _playerMovment;
    private PlayerAnimations _playerAnimations;

    public JumpState(PlayerMovment playerMovment,PlayerAnimations playerAnimations)
    {
        _playerMovment = playerMovment;
        _playerAnimations = playerAnimations;
    }
    public override void Enter()
    {
        base.Enter();
        _playerMovment.Jump();
        _playerAnimations.Jump();
    }
    public override void Exit()
    {
        base.Exit();
        _playerAnimations.Land();
    }
}