using UnityEngine;

namespace Models
{
    public class Projector : ClassRoomObjects, ISwitcher
    {

        public Projector(MeshRenderer obj, Material[] materials) : base(obj, materials)
        {
            NumberOfMaterial = 3;
        }

    }
}
