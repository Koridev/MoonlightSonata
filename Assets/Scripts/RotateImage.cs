using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RotateImage : MonoBehaviour
{

    private Image image;
    public float speed = 1f;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.rectTransform.Rotate(new Vector3(0,0,speed * Time.deltaTime), Space.Self);
    }
}
