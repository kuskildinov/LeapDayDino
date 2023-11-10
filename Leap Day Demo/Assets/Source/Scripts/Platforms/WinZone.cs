using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    public void Win()
    {
        _particle.Play();
    }
}
