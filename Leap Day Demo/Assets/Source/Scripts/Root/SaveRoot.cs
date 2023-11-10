using UnityEngine;

public class SaveRoot : CompositeRoot
{
    [SerializeField] private PlayerInteractions _player;
    
    private Vector2 _currentStartPos;   
    private float SpawnPointY = 0;
    public override void Compose()
    {
        ReloadSpawnPoint();
        _currentStartPos = new Vector2(0, PlayerPrefs.GetFloat("SpawnPointY"));
        _player.transform.position = _currentStartPos;
        _player.CheckPoint += SetCheckPoint;
    }

    public void SetCheckPoint()
    {
        _currentStartPos = new Vector2(0f, _player.transform.position.y);       
        SpawnPointY = _currentStartPos.y;       
        PlayerPrefs.SetFloat("SpawnPointY", SpawnPointY);
    }

    public Vector2 GetCheckPoint()
    {
        return _currentStartPos;
    }

    public void ReloadSpawnPoint()
    {
        PlayerPrefs.SetFloat("SpawnPointY", 0);
    }

    private void OnDisable()
    {
        _player.CheckPoint -= SetCheckPoint;
    }

}
