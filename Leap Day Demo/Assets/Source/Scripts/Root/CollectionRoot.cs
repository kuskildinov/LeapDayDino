using UnityEngine;

public class CollectionRoot : CompositeRoot
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _takedAudioSource;

    private int TotalScore;
    public override void Compose()
    {
        TotalScore = 0;
    }
    
    public void AddScore()
    {
        TotalScore++;
        _audioSource.PlayOneShot(_takedAudioSource);
    }

    public int GetScore()
    {
        return TotalScore;
    }

    public string GetScoreString()
    {
        return TotalScore.ToString();
    }
        
}
