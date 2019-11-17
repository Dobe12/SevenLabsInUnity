using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }



    public void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<NewBehaviourScript>().Switcher(this.gameObject.GetComponent<MeshRenderer>());
    }

}
