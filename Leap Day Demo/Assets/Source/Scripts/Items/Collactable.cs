using UnityEngine;

public class Collactable : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CollectionRoot _collectionRoot;

    public void Taked()
    {
        _collectionRoot.AddScore();        
        gameObject.SetActive(false);
    }
}
