using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed;

    private Vector2 _targetPoint;

    private void Start()
    {
        _targetPoint = _pointA.position;
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        CheckCurrentMovePoint();
        transform.position = Vector2.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);
    }

    private void CheckCurrentMovePoint()
    {
        if(Vector2.Distance(transform.position,_pointA.position) <= 0.5f)
        {
            _targetPoint = _pointB.position;
        }
        else if(Vector2.Distance(transform.position, _pointB.position) <= 0.5f)
        {
            _targetPoint = _pointA.position;
        }
           
    }
}
