using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Models;
using TMPro;
using UnityEngine;

namespace Models
{
    internal class Room : MonoBehaviour
    {
        public static TextMeshPro CountWorkingObjects;

        public LightSwitcher LightSwitcher { get; set; }
        public LightSensor LightSensor { get; set; }
        public Door Door { get; set; }
        public VotingSystem VotingSystem { get; set; }
        public MotionSensor MotionSensor { get; set; }

        public Room(TextMeshPro countWorkingObjects)
        {
            CountWorkingObjects = countWorkingObjects;
        }

        public void Initialize()
        {
            LightSwitcher.TurnOff();
            Door.TurnOff();
            LightSensor.TurnOff();
            MotionSensor.TurnOff();

            ClassRoomObjects.Counter = 0;
        }

        public void SwitchObject(ClassRoomObjects obj)
        {
            if (obj.IsWorking && CheckTurnOffСonditions(obj))
            {
                obj.TurnOff();
            }
            else if (!obj.IsWorking && CheckTurnOnСonditions(obj))
            {
                Debug.Log(2);
                obj.TurnOn();
            }
        }

        private bool CheckTurnOffСonditions(ClassRoomObjects obj)
        {
            return obj.GetType() == typeof(LightSwitcher) && MotionSensor.IsWorking && !LightSensor.IsWorking 
                   || obj.GetType() == typeof(Door);
        }

        private bool CheckTurnOnСonditions(ClassRoomObjects obj)
        {
            return obj.GetType() == typeof(LightSwitcher) && MotionSensor.IsWorking && !LightSensor.IsWorking
                   || obj.GetType() == typeof(Door)
                || obj.GetType() == typeof(Door);
        }

    }
}
