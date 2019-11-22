using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using UnityEngine;

namespace Assets.Models
{
    class LightSwitcher : ClassRoomObjects, ISwitcher
    {
        public LightSwitcher(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 0;
        }

        public override void TurnOn()
        {
            GameObject.FindGameObjectWithTag("PointLight").GetComponent<Light>().intensity = 4;

            base.TurnOn();
        }

        public override void TurnOff()
        {
            GameObject.FindGameObjectWithTag("PointLight").GetComponent<Light>().intensity = 0;

            base.TurnOff();
        }
    }
}
