using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using UnityEngine;

namespace Assets.Models
{
    class Signalisation : ClassRoomObjects, ISwitcher
    {
        public Signalisation(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 0;
        }
    }
}
