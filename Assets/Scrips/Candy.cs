using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Candy : MonoBehaviour
{
   public event Action ChangeTheColorOfTheCandy;
   
   [SerializeField] private Renderer _renderer;
   [SerializeField] private float _randomPositionMax = 5f;
   [SerializeField] private float _randomPositionMin = -5f;
   

   public void Initialize(ColorProvider colorProvider)
   {
      _renderer.material.color = colorProvider.GetColor();
   }

   private void OnTriggerEnter(Collider other)
   {
      var playerRenderer = other.GetComponent<Renderer>();
      if (other.CompareTag("Player") && playerRenderer != null)
      {
         SetCandyPosition();
         playerRenderer.materials[0].color = _renderer.material.color;
         ChangeTheColorOfTheCandy?.Invoke();
      }
   }
   
   private void SetCandyPosition()
   {
      transform.position = new Vector3();
      var randomPosition = new Vector2(Random.Range(_randomPositionMin,_randomPositionMax),
         Random.Range(_randomPositionMin,_randomPositionMax));
      var presentPosition = transform.position;

      presentPosition.x += randomPosition.x;
      presentPosition.z += randomPosition.y;
      transform.position = presentPosition;
   }
   
}
