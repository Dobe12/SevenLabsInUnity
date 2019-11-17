using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsObserverableTransform : MonoBehaviour
{
    public event Action<Transform> OnChangePosition;
    private Vector3 _lastPosition;
    private Transform _transform;


    private void Start()
    {
        _transform = GetComponent<Transform>();
        _lastPosition = _transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_lastPosition != transform.position)
        {
            if (OnChangePosition != null)
            {
                OnChangePosition.Invoke(_transform);
            }
        }

        _lastPosition = _transform.position;
    }
}
