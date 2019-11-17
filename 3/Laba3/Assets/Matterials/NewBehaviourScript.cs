using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public MeshRenderer Door;  
    public MeshRenderer VotingSystem;
    public MeshRenderer MotionSensor;
    public MeshRenderer Screen;
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
        if (People.position.z > 1.8)
        {
            _room.MotionSensor.TurnOff();
        } else if (People.position.z < 1.5)
        {
            _room.MotionSensor.TurnOn();
        }
    }



    public void Switcher(MeshRenderer obj)
    {
        switch (obj.name)
        {
            case "MotionSensor":
                _room.SwitchObject(_room.MotionSensor);
                break;
            case "Door":
                _room.SwitchObject(_room.Door);
                break;
            case "VotingSystem":
                _room.SwitchObject(_room.VotingSystem);
                break;
            case "Screen":
                _room.SwitchObject(_room.Screen);
                break;
            default:
                throw new Exception("object not found");
        }
    }

    public void StartRoom()
    {
        _room = new Room(CountAvailable)
        {
            Door = new Door(Door, Materials),
            VotingSystem = new Models.VotingSystem(VotingSystem, Materials),
            Screen = new Models.Screen(Screen, Materials),
            MotionSensor = new MotionSensor(MotionSensor, Materials)
        };

        _room.Initialize();
    }

}
