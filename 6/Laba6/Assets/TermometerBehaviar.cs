using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TermometerBehaviar : MonoBehaviour
{
    public GameObject Display;

    public int Temperature;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Display.GetComponent<TextMeshProUGUI>().text = Temperature.ToString() + " C°";
    }

    public void Up()
    {
        Temperature++;
    }

    public void Down()
    {
        Temperature--;
    }


}
