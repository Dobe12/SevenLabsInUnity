using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUpdater : MonoBehaviour
{
    public Light Sun;
    public int LightInPercent = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var onePercent = 200f;
        var fullGap = Sun.GetComponent<DayNight>().time - 54000f;

        LightInPercent = (((int) (100 - fullGap / onePercent) / 10) * 10);

        gameObject.GetComponent<TextMeshPro>().text = LightInPercent.ToString() + "%";
    }
}
