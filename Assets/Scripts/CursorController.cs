using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CursorController : MonoBehaviour
{
    public Image cursor;
    public TextMeshProUGUI hintText;
    public Image hintImage;

    public Sprite defaultCursor;
    public Sprite interactionCursor;

    private void Awake()
    {
        SetUI(false, Color.white, "", false);
    }
    
    public void SetUI(bool isit, Color color, string text, bool showCursor)
    {
        cursor.sprite = isit? interactionCursor : defaultCursor;
        cursor.enabled = showCursor;
        hintImage.enabled = isit;
        //hintText.enabled = isit;


        cursor.color = color;
        hintText.text = isit? text: "";
    }
}
