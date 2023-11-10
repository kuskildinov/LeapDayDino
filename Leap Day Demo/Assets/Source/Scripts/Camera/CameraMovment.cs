using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;

    private Vector3 _offset;

    public void Initialize()
    {
        _offset = _camera.position - _player.position;
    }

    private void FixedUpdate()
    {
        _camera.position = new Vector3(_camera.position.x,_player.position.y + _offset.y, _player.position.z + _offset.z);
    }
}
