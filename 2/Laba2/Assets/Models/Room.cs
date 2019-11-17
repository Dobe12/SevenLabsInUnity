using TMPro;
using UnityEngine;

namespace Models
{
    internal class Room : MonoBehaviour
    {
        public static TextMeshPro CountWorkingObjects;

        public Door Door { get; set; }
        public Screen Screen { get; set; }
        public Projector Projector { get; set; }
        public Conditioner Conditioner { get; set; }

        public Room(TextMeshPro countWorkingObjects)
        {
            CountWorkingObjects = countWorkingObjects;
        }

        public void Initialize()
        {
            Door.TurnOff();
            Screen.TurnOff();
            Projector.TurnOff();
            Conditioner.TurnOff();

            ClassRoomObjects.Counter = 0;
        }

        public void SwitchObject(ClassRoomObjects obj)
        {
            if (obj.CheckOnWorking() && CheckTurnOffСonditions(obj))
            {
                obj.TurnOff();
            }
            else if (!obj.CheckOnWorking() && CheckTurnOnСonditions(obj))
            {
                obj.TurnOn();
            }
        }

        private bool CheckTurnOffСonditions(ClassRoomObjects obj)
        {
            return obj.GetType() != typeof(Door) || (!Projector.IsWorking && !Conditioner.IsWorking && !Screen.IsWorking);
        }

        private bool CheckTurnOnСonditions(ClassRoomObjects obj)
        {
            return (obj.GetType() != typeof(Conditioner) && obj.GetType() != typeof(Projector) && obj.GetType() != typeof(Screen)) || Door.IsWorking;
        }

    }
}
