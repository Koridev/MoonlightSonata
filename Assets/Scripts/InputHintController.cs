using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InputHintController : MonoBehaviour
{
    public RectTransform container;
    public GameObject hintPrefab;

    public Sprite Qsprite;
    public Sprite Esprite;
    public Sprite lmbSprite;
    public Sprite rmbSprite;

    public void SetHints(List<(HintInputType, string)> hints)
    {
        List<GameObject> children = new List<GameObject>();
        for(int i=0; i<container.childCount; i++)
        {
            children.Add(container.GetChild(i).gameObject);
        }

        children.ForEach(child => GameObject.Destroy(child));

        foreach (var hint in hints)
        {
            GameObject newHintObj = GameObject.Instantiate(hintPrefab, transform);

            newHintObj.GetComponentInChildren<Image>().sprite = GetHintSprite(hint.Item1);
            newHintObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hint.Item2;
        }


        LayoutRebuilder.ForceRebuildLayoutImmediate(container);
        //container.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
    }

    private Sprite GetHintSprite(HintInputType type)
    {
        switch (type)
        {
            case HintInputType.E:
                return Esprite;
            case HintInputType.Q:
                return Qsprite;
            case HintInputType.LMB:
                return lmbSprite;
            case HintInputType.RMB:
                return rmbSprite;
            default:
                return null;
        }
    }
}

public enum HintInputType { 
    LMB, RMB, Q, E
}
