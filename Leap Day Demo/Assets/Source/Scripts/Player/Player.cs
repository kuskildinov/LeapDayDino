using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInteractions _playerInteractions;
    [SerializeField] private PlayerMovment _playerMovment;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private int _maxJumpValue = 2;

    private IInput _input;
    private StateMachine _stateMachine;
    private RunState _runState;
    private JumpState _jumpState;
    private SecondJumpState _secondJumpState;
    private SlideState _slideState;
    private FallState _fallState;
    private DieState _dieState;

    private bool _touchPlatform;
    private bool _touchWall;
    private int _currentJumpValue;
   

    public void Initialize(IInput input)
    {
        _input = input;
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new IdleState());
        _currentJumpValue = _maxJumpValue;
        Time.timeScale = 2;

        _runState = new RunState(_playerMovment);
        _jumpState = new JumpState(_playerMovment, _playerAnimations);
        _secondJumpState = new SecondJumpState(_playerMovment);
        _slideState = new SlideState(_playerMovment, _playerAnimations);
        _fallState = new FallState(_playerAnimations);
        _dieState = new DieState(_playerAnimations);
        _stateMachine.ChangeState(_runState);

        _playerInteractions.TouchPlatform += TouchPlatform;        
        _playerInteractions.TouchWall += WallTouched;       
        _playerInteractions.ExitTouchPlatform += ExitPlatform;
        _playerInteractions.ExitTouchWall += ExitWall;
        _playerInteractions.Die += Die;
    }

    private void Update()
    {
        Debug.Log(_stateMachine.CurrentState);
        _stateMachine.Update();
        if(_input.PlayerTap())
        {
            TryJump();
        }          
    }

    private void TryJump()
    {
        if (_currentJumpValue == 2)
            _stateMachine.ChangeState(_jumpState);
        else if (_currentJumpValue == 1)
            _stateMachine.ChangeState(_secondJumpState);
        _currentJumpValue--;
    }

    private void ReloadJumps()
    {
        _currentJumpValue = _maxJumpValue;
    }

    private void TouchPlatform()
    {
        _touchPlatform = true;
        ReloadJumps();
        if(_touchWall && _stateMachine.CurrentState == _jumpState)
        {
            _playerMovment.ChangeMoveDirection();
        }
        _stateMachine.ChangeState(_runState);
    }
    
    private void WallTouched()
    {
        _touchWall = true;
        ReloadJumps();

        if (_stateMachine.CurrentState == _runState)
        {
            _playerMovment.ChangeMoveDirection();
            if(_touchPlatform == false)
            {
                _stateMachine.ChangeState(_slideState);
            }
        }
            
        else if(_touchPlatform && _stateMachine.CurrentState == _runState)
        {
            _playerMovment.ChangeMoveDirection();
        }

        else if (_stateMachine.CurrentState == _jumpState || _stateMachine.CurrentState == _secondJumpState)
        {
            _playerMovment.ChangeMoveDirection();
            _stateMachine.ChangeState(_slideState);           
        }

        else if (_stateMachine.CurrentState == _fallState)
        {
            _playerMovment.ChangeMoveDirection();
            _stateMachine.ChangeState(_slideState);
        }


    } 

    private void ExitWall()
    {
        _touchWall = false;
        if (_stateMachine.CurrentState == _slideState)
        {
            _stateMachine.ChangeState(_fallState);
        }        
    }

    private void ExitPlatform()
    {
        _touchPlatform = false;
        if (_stateMachine.CurrentState == _runState)
        {
            _stateMachine.ChangeState(_fallState);
        }
    }

    private void Die()
    {
        _stateMachine.ChangeState(_dieState);
    }

    private void OnDisable()
    {
        _playerInteractions.TouchPlatform -= TouchPlatform;
        _playerInteractions.TouchWall -= WallTouched;               
        _playerInteractions.ExitTouchPlatform -= ExitPlatform;
        _playerInteractions.ExitTouchWall -= ExitWall;
        _playerInteractions.Die -= Die;
    }
}
