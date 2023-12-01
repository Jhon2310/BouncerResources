using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private ColorProvider _colorProvider;
    [SerializeField] private PresentsManeger _presentsManeger;
    [SerializeField] private Candy _candy;
    [SerializeField] private Player _player;
    
    private void Awake()
    {
        _presentsManeger.Initialize(_colorProvider);
        _candy.Initialize(_colorProvider);
        _candy.ChangeTheColorOfTheCandy += HandleChangeTheColorOfTheCandy;
        _player.Initialize();
    }

    private void HandleChangeTheColorOfTheCandy()
    {
       var  newColor = _colorProvider.GetColor();
        _candy.GetComponentInChildren<Renderer>().materials[0].color = newColor;
    }
}
