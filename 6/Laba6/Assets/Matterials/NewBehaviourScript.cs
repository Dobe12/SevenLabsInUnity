using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Models;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
   

    public MeshRenderer Conditioner;
    public MeshRenderer Radiator;
    public GameObject Thermometer;


    public Material[] Materials;

    public TextMeshPro CountAvailable;

    private Room _room;


    // Start is called before the first frame update
    void Start()
    {
        StartRoom();
    }

    void Update()
    {
        ConditionerUpdater();
        RadiatorUpdater();
    }

    private void ConditionerUpdater()
    {
        if (Thermometer.GetComponent<TermometerBehaviar>().Temperature > 27)
        {
            _room.Conditioner.TurnOn();
        }
        else
        {
            _room.Conditioner.TurnOff();
        }
    }

    private void RadiatorUpdater()
    {
        if (Thermometer.GetComponent<TermometerBehaviar>().Temperature < 23)
        {
            _room.Radiator.TurnOn();
        }
        else
        {
            _room.Radiator.TurnOff();
        }
    }


    public void StartRoom()
    {
        _room = new Room(CountAvailable);
        _room.Conditioner = new Conditioner(Conditioner, Materials);
        _room.Radiator = new Radiator(Radiator, Materials);

        _room.Initialize();
    }

}
