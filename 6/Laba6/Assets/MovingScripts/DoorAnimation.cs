using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorAnimation : MonoBehaviour
{
    public Transform ClosingDoor;
    public Transform OpeningDoor;

    void Start()
    {
        Open();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        AnimationMoving(OpeningDoor);
    }

    public void Close()
    {
        AnimationMoving(ClosingDoor);
    }

    private void AnimationMoving(Transform target)
    {
        Debug.Log("ok");
        target.GetOrAddComponent<Transform, ObsObserverableTransform>().OnChangePosition += (t) =>
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(t.position);
        };
        gameObject.GetComponent<NavMeshAgent>().SetDestination(target.position);
    }
}
