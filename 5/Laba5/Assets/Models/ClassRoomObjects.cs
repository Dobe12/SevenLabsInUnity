using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Models
{
    public abstract class ClassRoomObjects : MonoBehaviour
    {
        public MeshRenderer Object;
        public bool IsWorking;

        public static int Counter;

        public int NumberOfMaterial;

        public Material[] Materials;

        protected ClassRoomObjects(MeshRenderer obj, Material[] materials)
        {
            this.Object = obj;
            IsWorking = false;
            Materials = materials;
        }

        public virtual void TurnOn()
        {
            var matArray = Object.materials;

            if (!matArray[NumberOfMaterial].name.Contains(Materials[1].name)) return;

            matArray[NumberOfMaterial] = Materials[0];
            Object.materials = matArray;

            Counter++;
            SwitchCountWorkingObjects();

            IsWorking = true;

        }

        public virtual  void TurnOff()
        {
            var matArray = Object.materials;

            if (matArray[NumberOfMaterial].name.Contains(Materials[1].name)) return;

            matArray[NumberOfMaterial] = Materials[1];

            Object.materials = matArray;

            Counter--;
            SwitchCountWorkingObjects();

            IsWorking = false;
        }

        private static void SwitchCountWorkingObjects()
        {
            if (Counter >= 0)
            {
                Room.CountWorkingObjects.text = Counter.ToString();
            }
        }

    }
}
