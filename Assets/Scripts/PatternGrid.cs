using Shapes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternGrid : MonoBehaviour
{
    private PatternButton button;
    public List<Rectangle> rectangles;

    private void Awake()
    {
        button = GetComponentInParent<PatternButton>();
    }

    private void Start()
    {
        if(button != null)
        {
            List<bool> values = button.GetPattern();

            if(values != null)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    rectangles[i].Color = values[i] ? Color.black : Color.white;
                }
            }
            
        }
        
    }


}
