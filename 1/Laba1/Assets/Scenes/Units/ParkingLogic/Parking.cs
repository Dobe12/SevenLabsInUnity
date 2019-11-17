using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

namespace Assets.Scenes.Units.ParkingLogic
{
    public class Parking : MonoBehaviour
    {
        public Place LeftSideBarrier { get; set; } = new Place();
        public Place RightSideBarrier { get; set; } = new Place();

        public List<Place> ParkingPlaceCars { get; set; } = new List<Place>();
        public List<Place> FreeCars { get; set; } = new List<Place>();

        public List<GameObject> CarPrefabs { get; set; }

        public BarrierBehaviour Barrier { get; set; }

        private int _countPlaces = 40;

        public Parking(List<GameObject> carPrefabs)
        {
            CarPrefabs = carPrefabs;
        }



        public void Initialize()
        {
            ParkingPlaceInitialize();
            FreeCarsInitialize();
            BarrierInitialize();
            CarCountUpdater();
        }

        private void BarrierInitialize()
        {
            LeftSideBarrier.Transform = GameObject.FindGameObjectWithTag("LeftSideBarrier").transform;
            RightSideBarrier.Transform = GameObject.FindGameObjectWithTag("RightSideBarrier").transform;

            Barrier = GameObject.FindGameObjectWithTag("Barrier").GetComponent<BarrierBehaviour>();
        }
        private void ParkingPlaceInitialize()
        {
            var allParkingPlaces = GameObject.FindGameObjectsWithTag("ParkingPlace").ToList();

            foreach (var parkingPlace in allParkingPlaces)
            {
                if (_countPlaces-- > 0)
                {
                    ParkingPlaceCars.Add(new Place 
                    {
                        Transform = parkingPlace.transform,
                        Car = Instantiate(GetRandomCar(), parkingPlace.transform.position, Quaternion.identity).GetComponent<NavMeshAgent>()
                    });
                } else
                {
                    ParkingPlaceCars.Add(new Place { Transform = parkingPlace.transform });
                }          
            }
        }

        private void FreeCarsInitialize()
        {
            var freeCarsTransform = GameObject.FindGameObjectWithTag("FreeCarsPosition").transform;
            for (var i = 0; i < 15; i++)
            {
                FreeCars.Add(new Place
                {
                    Transform = freeCarsTransform,
                    Car = Instantiate(GetRandomCar(), freeCarsTransform.position, Quaternion.identity).GetComponent<NavMeshAgent>()
                });
            }            
        }

        private static void Move(Place currentPlace, Place targetPlace)
        {
            AnimationMoving(currentPlace.Car, targetPlace.Transform);
            
            targetPlace.Car = currentPlace.Car;
            currentPlace.Car = null;           
        }

        public void FreeCarGetToLeftSideBarrier()
        {
            if (FreeCars.All(fc => fc.Car == null) || LeftSideBarrier.Car != null) 
            {
                Notification.RoadIsBusy();
            }

            Move(FreeCars.First(fc => fc.Car != null), LeftSideBarrier);
        }

        public void LeftSideBarrierCarGetToParkingPlace()
        {
            if (LeftSideBarrier.Car == null || RightSideBarrier.Car != null)
            {
                Notification.RoadIsBusy();
            }

            Barrier.Open();

            Move(LeftSideBarrier, ParkingPlaceCars.First(ppc => ppc.Car == null));

            CarCountUpdater();
        }

        public void ParkingPlaceCarGetToRightSideBarrier()
        {

            if ( ParkingPlaceCars.All(ppc => ppc.Car == null) || RightSideBarrier.Car != null)
            {
                Notification.RoadIsBusy();
            }

            Move(ParkingPlaceCars.Last(ppc => ppc.Car != null), RightSideBarrier);
        }

        public void RightSideBarrierCarGetToFreeCars()
        {
            if (RightSideBarrier.Car == null  || LeftSideBarrier.Car != null)
            {
                Notification.RoadIsBusy();
            }

            Barrier.Open();

            Move(RightSideBarrier, FreeCars.Last());

            CarCountUpdater();
        }


        public void RightSideBarrierCarGetBack()
        {
            if (RightSideBarrier.Car == null || ParkingPlaceCars.All(ppc => ppc.Car == null))
            {
               Notification.AllPlacesIsBusy();
            }

            Move(RightSideBarrier, ParkingPlaceCars.Last(ppc => ppc.Car == null));
        }

        public void LeftSideBarrierCarGetBack()
        {
            if (LeftSideBarrier.Car == null)
            {
                Notification.AllPlacesIsBusy();
            }

            Move(LeftSideBarrier, FreeCars.Last());
        }

        private GameObject GetRandomCar()
        {
            int rand = UnityEngine.Random.Range(0, CarPrefabs.Count);

            return CarPrefabs[rand];
        }

        private static void AnimationMoving(NavMeshAgent movingObj, Transform target)
        {
            target.GetOrAddComponent<Transform, ObserverableTransform>().OnChangePosition += (t) =>
            {
                movingObj.SetDestination(t.position);
            };
            movingObj.SetDestination(target.position);
        }



        public void CarCountUpdater()
        {
            GameObject.FindGameObjectWithTag("CarCount").GetComponent<TextMeshPro>().text =
                "Машин: " + ParkingPlaceCars.Count(ppc => ppc.Car == true).ToString();
        }
    }
}
