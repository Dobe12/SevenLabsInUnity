using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Models
{
    public class Screen : ClassRoomObjects, ISwitcher
    {
        public Screen(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 5;
        }

    }
}
