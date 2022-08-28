using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpDemo : MonoBehaviour
{
    public LerpBase[] lerpList;
    public Slider slider;
    public Text percentText;

    private bool isUpdate;
    // Start is called before the first frame update
    void Start()
    {
        lerpList = GetComponentsInChildren<LerpBase>();
        slider.onValueChanged.AddListener(this.OnChange);
        isUpdate = true;
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveAllListeners();
    }

    private void OnChange(float _t)
    {
        foreach (var i in lerpList)
        {
            i.percent = slider.value;
        }

        percentText.text = $"{slider.value}";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isUpdate = !isUpdate;
        }

        if (isUpdate)
        {
            slider.value = Mathf.PingPong(Time.time, slider.maxValue);
        }
    }
}
