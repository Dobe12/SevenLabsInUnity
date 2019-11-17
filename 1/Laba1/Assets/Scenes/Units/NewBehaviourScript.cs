using System;
using System.Linq;
using Assets.Scenes.Units.ParkingLogic;
using UnityEngine;

namespace Assets.Scenes.Units
{
    public class NewBehaviourScript : MonoBehaviour, IParking
    {
        public GameObject[] CarsPrefabs;
        private Parking _parking;
        private void  Start()
        {
            _parking = new Parking(CarsPrefabs.ToList());
            _parking.Initialize();
        }

        public void ParkingPlaceCarGetToRightSideBarrier()
        {
            NotificationHandler(_parking.ParkingPlaceCarGetToRightSideBarrier);
        }

        public void FreeCarGetToLeftSideBarrier()
        {
            NotificationHandler(_parking.FreeCarGetToLeftSideBarrier);
        }

        public void LeftSideBarrierCarGetToParkingPlace()
        {
            NotificationHandler(_parking.LeftSideBarrierCarGetToParkingPlace);
        }

        public void RightSideBarrierCarGetToFreeCars()
        {
            NotificationHandler(_parking.RightSideBarrierCarGetToFreeCars);
        }

        public void RightSideBarrierCarGetBack()
        {
            NotificationHandler(_parking.RightSideBarrierCarGetBack);
        }

        public void LeftSideBarrierCarGetBack()
        {
            NotificationHandler(_parking.LeftSideBarrierCarGetBack);
        }

        public void NotificationHandler(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                GetComponent<Notification>().Show(e.Message);
            }

        }

    }
}
