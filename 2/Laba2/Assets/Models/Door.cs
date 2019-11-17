using UnityEngine;

namespace Models
{
    public class Door : ClassRoomObjects, ISwitcher
    {
        public Door(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 2;
        }


    }
}
