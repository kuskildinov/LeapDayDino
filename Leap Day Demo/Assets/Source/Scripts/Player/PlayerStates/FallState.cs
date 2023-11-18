public class FallState : State
{
    private PlayerAnimations _playerAnimations;
    public FallState(PlayerAnimations playerAnimations)
    {
        _playerAnimations = playerAnimations;
    }
    public override void Enter()
    {
        base.Enter();
        _playerAnimations.Fall();
    }
    public override void Exit()
    {
        base.Enter();
        _playerAnimations.Land();
    }
}
