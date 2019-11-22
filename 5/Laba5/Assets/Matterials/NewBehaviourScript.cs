using System;
using Assets.Models;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public MeshRenderer Door;
    public MeshRenderer LightSensor;
    public MeshRenderer WindowProtector;
    public MeshRenderer Signaling;
    public GameObject Dimmer;


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
        LightSensorUpdater();
        DimmerUpdater();
    }



    void LightSensorUpdater()
    {
        var sun = GameObject.FindGameObjectWithTag("SunLightCounter");

        int lightInPercent = sun.GetComponent<StatusUpdater>().LightInPercent;

        if (lightInPercent > 50)
        {
            _room.LightSensor.TurnOff();
        }
        else
        {
            _room.LightSensor.TurnOn();
        }

    }

    void DimmerUpdater()
    {
        if ( _room.Signaling.IsWorking && (_room.WindowProtector.IsWorking || _room.LightSensor.IsWorking))
        {
            Dimmer.GetComponent<Selectable>().interactable = true;
        }
        else
        {
            {
                Dimmer.GetComponent<Selectable>().interactable = false;
            }
        }
    }

    public void Switcher(MeshRenderer obj)
    {
        switch (obj.name)
        {
            case "Cube_10":
                _room.SwitchObject(_room.Door);
                break;
            case "LightSwitcher":
                _room.SwitchObject(_room.LightSwitcher);
                break;
            case "LightSensor":
                _room.SwitchObject(_room.LightSensor);
                break;
            case "windows":
                _room.SwitchObject(_room.WindowProtector);
                break;
            case "Signaling":
                _room.SwitchObject(_room.Signaling);
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
            LightSensor = new LightSensor(LightSensor, Materials),
            WindowProtector = new WindowProtector(WindowProtector, Materials),
            Signaling = new Signalisation(Signaling, Materials)
        };

        _room.Initialize();
    }

}
