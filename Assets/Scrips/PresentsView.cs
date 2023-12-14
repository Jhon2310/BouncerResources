using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PresentsView : MonoBehaviour
{
    [SerializeField] private Image[] _presentsColors;
    [SerializeField] private TextMeshProUGUI[] _presentsCountLabel;

    public void Initialize(ColorProvider colorProvider)
    {
        var colors = colorProvider.GetAllColors();

        for (int i = 0; i < colors.Length; i++)
        {
            var color = colors[i];
            _presentsColors[i].color = color;
            _presentsCountLabel[i].color = color;
        }
    }
    public void SetCountOfPresentsWithColor(Color color, int count)
    {
        for (int i = 0; i < _presentsColors.Length; i++)
        {
            if (color == _presentsColors[i].color)
            {
                
                _presentsCountLabel[i].text = count.ToString();
                break;
            }
        }
    }
}
