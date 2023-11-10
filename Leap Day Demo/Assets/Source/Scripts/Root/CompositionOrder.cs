using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositionOrder : MonoBehaviour
{
    [SerializeField] private List<CompositeRoot> _compositeRoots;

    private void Awake()
    {
        foreach(CompositeRoot order in _compositeRoots)
        {
            order.Compose();
        }
    }
}
