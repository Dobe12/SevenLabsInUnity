using UnityEngine;

namespace Models
{
    public class Conditioner : ClassRoomObjects, ISwitcher
    {
        public Conditioner(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 0;
        }

    }
}
