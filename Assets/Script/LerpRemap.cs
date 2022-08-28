using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpRemap : MonoBehaviour
{
    public LerpBase fill;
    public Slider slider;

    public Text hpText;

    public Text percentText;
    // Start is called before the first frame update
    void Start()
    {       
        slider.onValueChanged.AddListener(this.OnChange);
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveAllListeners();
    }


    private void OnChange(float _t)
    {
        fill.percent = Mathf.InverseLerp(slider.minValue, slider.maxValue, slider.value);

        percentText.text = $"{fill.percent}";

        hpText.text = $"{slider.value}/{slider.maxValue}";
    }
}
