using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandysManeger : MonoBehaviour
{
   
    
    [SerializeField] private Candy _candy;
    [SerializeField] private float _randomPositionMax = 5f;
    [SerializeField] private float _randomPositionMin = -5f;

    public void Initialize(ColorProvider colorProvider, Player player)
    {
        var candy = Instantiate(_candy, transform);
        SetCandyPosition(candy);
        var color = colorProvider.GetColor();
        

    }
    
    private void SetCandyPosition(Candy candy)
    {
        
        var randomPosition = new Vector2(Random.Range(_randomPositionMin,_randomPositionMax),
            Random.Range(_randomPositionMin,_randomPositionMax));
        var presentPosition = candy.transform.position;

        presentPosition.x += randomPosition.x;
        presentPosition.z += randomPosition.y;
        candy.transform.position = presentPosition;
    }
    
}
