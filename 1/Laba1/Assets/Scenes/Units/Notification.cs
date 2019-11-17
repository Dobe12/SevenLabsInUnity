using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scenes.Units
{
    public class Notification : MonoBehaviour
    {
        public GameObject PopUpPrefab;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public  void Show(string text)
        {
            if (!PopUpPrefab) return;

            var gameObj = Instantiate(PopUpPrefab);
            gameObj.GetComponent<TextMeshPro>().text = text;
        }

        public static void RoadIsBusy()
        {
            throw new Exception("Road is busy");
        }

        public static void AllPlacesIsBusy()
        {
            throw new Exception("All parking place is busy");
        }

    }
}
