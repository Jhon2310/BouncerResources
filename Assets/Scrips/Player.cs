using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    [SerializeField] private float _speed = 100f;
    [SerializeField] private Rigidbody _rigidbody;
    
    
    private Camera _camera;
    

    private void Start()
    {
        _camera = Camera.main;
        
    }

   
    private void Update()
    {
        var mousePosition = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(mousePosition);
        
        if (Physics.Raycast(ray,out var info,50f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                var point = info.point;
                point.y = 0;
                var newPosition = point - transform.position;
                newPosition.Normalize();
                _rigidbody.AddForce(newPosition*_speed);
            }
        }
    }

    public void Initialize()
    {
        Instantiate(gameObject);
    }
}
