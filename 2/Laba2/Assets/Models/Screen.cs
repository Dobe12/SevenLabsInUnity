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
