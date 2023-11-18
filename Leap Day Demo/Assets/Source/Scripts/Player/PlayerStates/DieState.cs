public class DieState : State
{
    private PlayerAnimations _playerAnimations;
    public DieState(PlayerAnimations playerAnimations)
    {
        _playerAnimations = playerAnimations;
    }
    public override void Enter()
    {
        base.Enter();
        _playerAnimations.Die();
    }
    public override void Exit()
    {
        base.Enter();
        _playerAnimations.NewLive();
    }
}

