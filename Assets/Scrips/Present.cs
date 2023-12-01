using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Present : MonoBehaviour
{
     [SerializeField] private Renderer _lidRenderer;

     private Color _color;
     public void Initialize(Color color)
     {
          _lidRenderer.materials[1].color = color;
          _color = color;
     }

     private void OnCollisionEnter(Collision collision)
     {
          var playerRenderer = collision.collider.GetComponent<Renderer>();
          if (collision.collider.CompareTag("Player"))
          {
               if (playerRenderer.materials[0].color == _color )
               {
                    Destroy(gameObject);
               }
               
          }
     }
}
