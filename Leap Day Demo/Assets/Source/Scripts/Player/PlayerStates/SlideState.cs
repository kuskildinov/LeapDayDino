public class SlideState:State
{    private PlayerMovment _playerMovment;
    private PlayerAnimations _playerAnimations;
   
    public SlideState(PlayerMovment playerMovment, PlayerAnimations playerAnimations)
    {        
        _playerMovment = playerMovment;
        _playerAnimations = playerAnimations;
    }
    public override void Enter()
    {        
        base.Enter();
        _playerMovment.DeactivateGravity();
        _playerAnimations.OnWall();
    }
    public override void Exit()
    {        
        base.Enter();
        _playerMovment.ActivateGravity();
        _playerAnimations.ExitWall();
    }

    public override void Update()
    {
        base.Update();
        _playerMovment.SlipDownToWall();
    }
}