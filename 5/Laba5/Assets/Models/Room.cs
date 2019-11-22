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
        public WindowProtector WindowProtector { get; set; }
        public Signalisation Signaling { get; set; }

        public Room(TextMeshPro countWorkingObjects)
        {
            CountWorkingObjects = countWorkingObjects;
        }

        public void Initialize()
        {
            Door.TurnOff();
            LightSensor.TurnOff();
            WindowProtector.TurnOff();
            Signaling.TurnOff();

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
                obj.TurnOn();
            }
        }

        private bool CheckTurnOffСonditions(ClassRoomObjects obj)
        {
            return true;
        }

        private bool CheckTurnOnСonditions(ClassRoomObjects obj)
        {
            return true;
        }

    }
}
