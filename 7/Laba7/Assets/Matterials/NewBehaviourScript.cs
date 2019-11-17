using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Models;
using JetBrains.Annotations;
using Models;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public MeshRenderer WindowProtector;
    public MeshRenderer Door;
    public MeshRenderer MotionSensor;
    public GameObject Thermometer;

    public Material[] Materials;

    public TextMeshPro CountAvailable;

    private Room _room;

    public Transform People;


    // Start is called before the first frame update
    void Start()
    {

        StartRoom();
        

    }

    void Update()
    {
        MotionSensorUpdater();
        WindowUpdater();
    }

    void MotionSensorUpdater()
    {
        if (People.position.z > 1.8)
        {
            _room.MotionSensor.TurnOff();
        }
        else if (People.position.z < 1.5)
        {
            _room.MotionSensor.TurnOn();
        }

    }

    void WindowUpdater()
    {
        int temperature = Thermometer.GetComponent<TermometerBehaviar>().Temperature;
        if (!_room.MotionSensor.IsWorking || _room.MotionSensor.IsWorking && temperature > 20)
        {
            _room.WindowProtector.TurnOff();
        }
        else 
        {
            _room.WindowProtector.TurnOn();
        } 

    }



    public void Switcher(MeshRenderer obj)
    {
        switch (obj.name)
        {
            case "Door":
                _room.SwitchObject(_room.Door);
                break;

        }
    }

    public void StartRoom()
    {
        _room = new Room(CountAvailable);
        _room.WindowProtector = new WindowProtector(WindowProtector, Materials);
        _room.Door = new Door(Door, Materials);
        _room.MotionSensor = new MotionSensor(MotionSensor, Materials);


        _room.Initialize();
    }

}
