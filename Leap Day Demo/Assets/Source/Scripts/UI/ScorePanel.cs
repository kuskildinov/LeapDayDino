using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _finalScoreText;
    [SerializeField] private CollectionRoot _collectionRoot;
    

    private void Update()
    {
        _scoreText.text = _finalScoreText.text = _collectionRoot.GetScoreString();
    }
}
