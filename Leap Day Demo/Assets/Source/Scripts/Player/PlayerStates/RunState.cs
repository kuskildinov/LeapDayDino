public class RunState : State
{
    private PlayerMovment _player;
    private bool _canRun;
    public RunState(PlayerMovment player)
    {
        _player = player;
    }
    public override void Enter()
    {
        base.Enter();
        _canRun = true;
    }
    public override void Exit()
    {
        base.Enter();
        _canRun = false;
    }
    public override void Update()
    {
        base.Update();
        if(_canRun)
            _player.Move();
    }
}

