using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Models;
using Models;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public MeshRenderer LightSwitcher;
    public MeshRenderer Door;
    public MeshRenderer LightSensor;
    public MeshRenderer VotingSystem;
    public MeshRenderer MotionSensor;
    private Room _room;
    public Transform People;

    public Material[] Materials;

    public TextMeshPro CountAvailable;


    // Start is called before the first frame update
    void Start()
    {
        StartRoom();
    }

    void Update()
    {
        MotionSensorUpdater();
        LightSensorUpdater();
    }

    void MotionSensorUpdater()
    {
        if (People.position.z > 1.8)
        {
            _room.MotionSensor.TurnOff();
            //if (_room.LightSensor.IsWorking)
            //{
            //    _room.LightSwitcher.TurnOff();
            //}
        }
        else if (People.position.z < 1.5)
        {
            _room.MotionSensor.TurnOn();
            if (_room.LightSensor.IsWorking)
            {
                _room.LightSwitcher.TurnOn();
            }
        }


    }

    void LightSensorUpdater()
    {
        var sun = GameObject.FindGameObjectWithTag("SunLightCounter");

        int lightInPercent = sun.GetComponent<StatusUpdater>().LightInPercent;

        if (lightInPercent > 50)
        {
            _room.LightSensor.TurnOff();
            //if (_room.MotionSensor.IsWorking)
            //{
            //    _room.LightSwitcher.TurnOff();
            //}
        }
        else
        {
            _room.LightSensor.TurnOn();
            if (_room.MotionSensor.IsWorking)
            {
                _room.LightSwitcher.TurnOn();
            }
        }

    }

    public void Switcher(MeshRenderer obj)
    {
        switch (obj.name)
        {
            case "computer2":
                _room.SwitchObject(_room.MotionSensor);
                break;
            case "Cube_10":
                _room.SwitchObject(_room.Door);
                break;
            case "VoiceControl":
                _room.SwitchObject(_room.LightSwitcher);
                break;
            case "LightSwitcher":
                _room.SwitchObject(_room.LightSwitcher);
                break;
            case "LightSensor":
                _room.SwitchObject(_room.LightSensor);
                break;
            default:
                throw new Exception("object not found");
        }
    }

    public void StartRoom()
    {
        _room = new Room(CountAvailable)
        {
            LightSwitcher = new LightSwitcher(LightSwitcher, Materials),
            Door = new Door(Door, Materials),
            VotingSystem = new Models.VotingSystem(VotingSystem, Materials),
            MotionSensor = new MotionSensor(MotionSensor, Materials),
            LightSensor = new LightSensor(LightSensor, Materials)
        };

        _room.Initialize();
    }

}
