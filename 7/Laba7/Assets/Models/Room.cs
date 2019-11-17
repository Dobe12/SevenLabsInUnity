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

        public WindowProtector WindowProtector { get; set; }
        public Door Door { get; set; }
        public MotionSensor MotionSensor { get; set; }

        public Room(TextMeshPro countWorkingObjects)
        {
            CountWorkingObjects = countWorkingObjects;
        }

        public void Initialize()
        {
            Door.TurnOn();
            MotionSensor.TurnOff();

            ClassRoomObjects.Counter = 0;
        }

        public void SwitchObject(ClassRoomObjects obj)
        {
            if (obj.IsWorking )
            {
                obj.TurnOff();
            }
            else if (!obj.IsWorking )
            {
                Debug.Log(2);
                obj.TurnOn();
            }
        }
            
    }
}
