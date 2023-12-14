using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PresentsManeger : MonoBehaviour
{
    public UnityEvent<Color, int> ChangePresentsCountWithColor;
    
    [SerializeField] private Present _presentPrefab;
    [SerializeField] private int _presentCount = 6;
    [SerializeField] private float _randomPositionMax = 10f;
    [SerializeField] private float _randomPositionMin = -10f;

    
    private ColorProvider _colorProvider;
    private Dictionary<Color, int> _presentsCountsByColor = new();
    private List<Present> _presents = new();
    
    public void Initialize(ColorProvider colorProvider)
    {
        _colorProvider = colorProvider;
        var colors = _colorProvider.GetAllColors();
        
        foreach (var color in colors)
        {
            _presentsCountsByColor.Add(color,0);
        }
        CreatePresents();
        
    }

    private void CreatePresents()
    {
        for (int i = 0; i < _presentCount; i++)
        {
            var present = Instantiate(_presentPrefab, transform);
            SetPresentPosition(present);
            var color = _colorProvider.GetColor();
            present.Initialize(color);
            
            _presentsCountsByColor[color]++;
            
            ChangePresentsCountWithColor.Invoke(color,_presentsCountsByColor[color]);

            present.PickUpAGift += ChangePresentsCount;
            
            _presents.Add(present);
        }
    }

    private void ChangePresentsCount(Present present)
    {
        _presentsCountsByColor[present.Color]--;
        _presents.Remove(present);
        
        ChangePresentsCountWithColor.Invoke(present.Color,_presentsCountsByColor[present.Color]);
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

    public void OnDestroy()
    {
        foreach (var present in _presents)
        {
            if (present)
            {
                present.PickUpAGift -= ChangePresentsCount;
            }
        }
    }
}
