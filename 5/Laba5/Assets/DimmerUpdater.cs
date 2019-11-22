using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DimmerUpdater : MonoBehaviour
{
    public Light LightPoint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int LightRangeInPercent = (int) (LightPoint.range / 2) * 10;

        gameObject.GetComponent<TextMeshPro>().text = LightRangeInPercent.ToString() + "%";
    }
}