using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private CollectionRoot _collectionRoot;

    private void Update()
    {
        _scoreText.text = _collectionRoot.GetScoreString();
    }
}
