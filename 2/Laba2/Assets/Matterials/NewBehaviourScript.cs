using System;
using Models;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public MeshRenderer Door;    
    public MeshRenderer Projector;
    public MeshRenderer Conditioner;
    public MeshRenderer Screen;
    private Room _room;

    public Material[] Materials;

    public TextMeshPro CountAvailable;

    // Start is called before the first frame update
    void Start()
    {
        StartRoom();
    }



    public void Switcher(MeshRenderer obj)
    {
        switch (obj.name)
        {
            case "Conditioner":
                _room.SwitchObject(_room.Conditioner);
                break;
            case "Door":
                _room.SwitchObject(_room.Door);
                break;
            case "Projector":
                _room.SwitchObject(_room.Projector);
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
            Projector = new Models.Projector(Projector, Materials),
            Screen = new Models.Screen(Screen, Materials),
            Conditioner = new Conditioner(Conditioner, Materials)
        };

        _room.Initialize();
    }

}
