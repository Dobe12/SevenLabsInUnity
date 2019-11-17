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
            DisableChangeMaterials = true;
        }

        public override void TurnOn()
        {
            var status = GameObject.FindGameObjectWithTag("Window").GetComponent<Animator>();

            if (!status.GetBool("Status"))
            {
                status.SetBool("Status", true);
            }

            base.TurnOn();
        }

        public override void TurnOff()
        {
            var status = GameObject.FindGameObjectWithTag("Window").GetComponent<Animator>();

            if (status.GetBool("Status"))
            {
                status.SetBool("Status", false);
            }

            base.TurnOff();
        }
    }
}