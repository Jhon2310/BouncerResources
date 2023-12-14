using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovementView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerMeshProUGUI;

    public void SetPlayerMovementCount(int count)
    {
        _playerMeshProUGUI.text = count.ToString();
    }
}
