using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Indicator))]
public class IndicatorBlink : MonoBehaviour
{
    public float period = 1;

    private bool state = false;
    private Indicator indicator;

    private IEnumerator blinkCoroutine;

    private void Awake()
    {
        blinkCoroutine = Blink();
    }

    // Start is called before the first frame update
    void Start()
    {
        indicator = GetComponent<Indicator>();

    }

    private void OnEnable()
    {
        StartCoroutine(blinkCoroutine);
    }

    private void OnDisable()
    {
        StopCoroutine(blinkCoroutine);
    }

    IEnumerator Blink()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(period);
            state = !state;
            indicator.on = state;
        }
    }
}
