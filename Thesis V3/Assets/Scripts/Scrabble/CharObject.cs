using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class CharObject : MonoBehaviour
{

    public char character;
    public TextMeshProUGUI text;
    public Image image;
    public RectTransform rectTransform;
    public int index;

    [Header("Appearance")]
    public Color normalColor;
    public Color selectedColor;

    bool isSelected = false;

    private WordScramble scramble;

    public CharObject Init (char c, WordScramble ws)
    {
        character = c;
        scramble = ws;
        text.text = c.ToString();
        gameObject.SetActive(true);
        return this;
    }

    public CharObject Init(char c)
    {
        return Init(c, null);
    }

    public void Select()
    {
        isSelected = !isSelected;

        image.color = isSelected ? selectedColor : normalColor;
        if (isSelected)
        {
            if (scramble == null)
                WordScrambleSingleton.main.Select(this);
            else
                scramble.Select(this);
        } else
        {
            if (scramble == null)
                WordScrambleSingleton.main.UnSelect();
            else
                scramble.UnSelect();
        }
    }
}
