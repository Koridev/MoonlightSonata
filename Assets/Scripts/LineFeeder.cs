using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(WallSlidingObject))]
public class LineFeeder : MonoBehaviour
{

    WallSlidingObject obj;
    public List<LineFeed> feed;
    private List<LineFeed> previousFeed;

    private void Awake()
    {
        if (!Application.IsPlaying(gameObject))
        {
            obj = GetComponent<WallSlidingObject>();
            previousFeed = new List<LineFeed>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Application.IsPlaying(gameObject))
        {
            Debug.Log("Update from LineFeeder");
            if (feed != previousFeed)
            {
                obj.rails = new List<Line>();

                foreach (LineFeed f in feed)
                {
                    if (f.parent.childCount > 1)
                    {
                        for (int i = 1; i < f.parent.childCount; i++)
                        {
                            obj.rails.Add(new Line(f.parent.GetChild(i - 1), f.parent.GetChild(i)));
                        }

                        if (f.loop)
                        {
                            obj.rails.Add(new Line(f.parent.GetChild(f.parent.childCount - 1), f.parent.GetChild(0)));
                        }
                    }

                }
                previousFeed = feed;
            }
        }
        
    }
}

[System.Serializable]
public struct LineFeed
{
    public Transform parent;
    public bool loop;

    public LineFeed(Transform parent, bool loop)
    {
        this.parent = parent;
        this.loop = loop;
    }
}