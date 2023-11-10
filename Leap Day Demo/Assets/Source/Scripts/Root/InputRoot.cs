using UnityEngine;

public class InputRoot : CompositeRoot
{
    [SerializeField] private PlayerMovment _playerMovment;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private PlayerSound _playerSound;
    [SerializeField] private CameraMovment _cameraMovment;
    public override void Compose()
    {
        DesktopInput input = new DesktopInput();
        _playerMovment.Initialize(input);
        _playerRotation.Initialize();
        _cameraMovment.Initialize();
        _playerAnimations.Initialize();
        _playerSound.Initialize();
    }       
}
