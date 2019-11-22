using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using UnityEngine;

namespace Assets.Models
{
    class WindowProtector : ClassRoomObjects, ISwitcher
    {
        public WindowProtector(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 0;
        }

        public override void TurnOn()
        {
            GameObject.FindGameObjectWithTag("Window").GetComponent<Animator>().SetBool("Status", true);

            base.TurnOn();
        }

        public override void TurnOff()
        {
            GameObject.FindGameObjectWithTag("Window").GetComponent<Animator>().SetBool("Status", false);

            base.TurnOff();
        }
    }
}
