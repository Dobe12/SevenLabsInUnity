using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Models
{
    public class Door : ClassRoomObjects, ISwitcher
    {
        public Door(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 2;
        }

        public override void TurnOn()
        {
            GameObject.FindGameObjectWithTag("Door").GetComponent<Animator>().SetTrigger("Open");

            IsWorking = true;
        }

        public override void TurnOff()
        {
            GameObject.FindGameObjectWithTag("Door").GetComponent<Animator>().SetTrigger("Close");

            IsWorking = false;
        }
    }
}
