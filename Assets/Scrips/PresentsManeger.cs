using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentsManeger : MonoBehaviour
{
    [SerializeField] private Present _presentPrefab;
    [SerializeField] private int _presentCount = 6;
    [SerializeField] private float _randomPositionMax = 10f;
    [SerializeField] private float _randomPositionMin = -10f;
    

    public void Initialize(ColorProvider colorProvider)
    {
       
        for (int i = 0; i < _presentCount; i++)
        {
            var present = Instantiate(_presentPrefab, transform);
            SetPresentPosition(present);
            var color = colorProvider.GetColor();
            present.Initialize(color);
        }
    }
    private void SetPresentPosition(Present present)
    {
        
        var randomPosition = new Vector2(Random.Range(_randomPositionMin,_randomPositionMax),
            Random.Range(_randomPositionMin,_randomPositionMax));
        var presentPosition = present.transform.position;

        presentPosition.x += randomPosition.x;
        presentPosition.z += randomPosition.y;
        present.transform.position = presentPosition;
    }

}
