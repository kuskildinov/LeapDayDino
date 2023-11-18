using UnityEngine;

public class InputRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraMovment _cameraMovment;   
    public override void Compose()
    {
        DesktopInput input = new DesktopInput();       
        _cameraMovment.Initialize();
        _player.Initialize(input);
    }       
}
