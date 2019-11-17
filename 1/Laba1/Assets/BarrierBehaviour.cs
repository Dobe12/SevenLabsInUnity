using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarrierBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Open");

    }

}
