using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using UnityEngine;

namespace Assets.Models
{
    class LightSensor : ClassRoomObjects, ISwitcher
    {
        public LightSensor(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 0;
        }
    }
}
