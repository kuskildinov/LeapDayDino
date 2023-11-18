using UnityEngine;

public class SaveRoot : CompositeRoot
{       
    private Vector2 _currentStartPos;   
    private float SpawnPointY = 0;
    public override void Compose()
    {
        ReloadSpawnPoint();
        _currentStartPos = new Vector2(0, PlayerPrefs.GetFloat("SpawnPointY"));       
    }

    public void SetCheckPoint()
    {       
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
        
    }

}
