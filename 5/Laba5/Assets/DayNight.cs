using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class DayNight : MonoBehaviour
{

    public float time;

    private float intensity;
    public Color fogday = Color.gray;
    public Color fognight = Color.black;

    private int speed = 0;

    void Update()
    {
        ChangeTime();
    }

    public void ChangeTime()
    {
        time += Time.deltaTime * speed;
        if (time > 86400)
        {
            time = 0;
        }

        gameObject.transform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 0, 0));
        if (time > 43200)
            intensity = 1 - (43200 - time) / 43200;
        else
            intensity = 1 - ((43200 - time) / 43200 * -1);

        RenderSettings.fogColor = Color.Lerp(fognight, fogday, intensity * intensity);

        gameObject.GetComponent<Light>().intensity = intensity;

    }

    public void ChangeTimeFromSlider(float value)
    {
        time = value;
    }

}