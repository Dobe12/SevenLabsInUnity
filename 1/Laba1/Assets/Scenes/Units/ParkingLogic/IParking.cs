using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scenes.Units.ParkingLogic
{
    public interface IParking
    {
         void FreeCarGetToLeftSideBarrier();
         void LeftSideBarrierCarGetToParkingPlace();
         void ParkingPlaceCarGetToRightSideBarrier();
         void RightSideBarrierCarGetToFreeCars();
         void RightSideBarrierCarGetBack();
         void LeftSideBarrierCarGetBack();
    }
}
