using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Models
{
    internal class Room : MonoBehaviour
    {
        public static TextMeshPro CountWorkingObjects;

        public Door Door { get; set; }
        public Screen Screen { get; set; }
        public VotingSystem VotingSystem { get; set; }
        public MotionSensor MotionSensor { get; set; }

        public Room(TextMeshPro countWorkingObjects)
        {
            CountWorkingObjects = countWorkingObjects;
        }

        public void Initialize()
        {
            Door.TurnOff();
            Screen.TurnOff();
            VotingSystem.TurnOff();
            MotionSensor.TurnOff();

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
            return obj.GetType() != typeof(Door) || (!VotingSystem.IsWorking && !MotionSensor.IsWorking && !Screen.IsWorking);
        }

        private bool CheckTurnOnСonditions(ClassRoomObjects obj)
        {
            return (obj.GetType() != typeof(MotionSensor) && obj.GetType() != typeof(VotingSystem) && obj.GetType() != typeof(Screen)) || Door.IsWorking;
        }

    }
}
