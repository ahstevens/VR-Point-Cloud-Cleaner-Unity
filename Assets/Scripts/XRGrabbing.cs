using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRGrabbing : MonoBehaviour
{

    public InputAction grab;

    public GameObject grabbableObject;

    private Matrix4x4 controllerToGrabbed;

    private bool grabbing;

    // Start is called before the first frame update
    void Start()
    {
        grab.started += ctx => OnBeginGrab();
        grab.canceled += ctx => OnEndGrab();
    }

    void OnEnable()
    {
        grab.Enable();
    }

    void OnDisable()
    {
        grab.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbing)
        {
            // Get object transform from new controller transform
            var newTransform = this.transform.localToWorldMatrix * controllerToGrabbed;

            // Apply position and rotation since scaling interactions may occur simultaneously
            grabbableObject.transform.position = newTransform.MultiplyPoint3x4(Vector3.zero);
            grabbableObject.transform.rotation = Quaternion.LookRotation(newTransform.GetColumn(2), newTransform.GetColumn(1));
        }
    }

    private void OnBeginGrab()
    {
        grabbing = true;
        
        // Get the transformation matrix representing the object's transform in local controller space
        controllerToGrabbed = this.transform.worldToLocalMatrix * grabbableObject.transform.localToWorldMatrix;
    }

    private void OnEndGrab()
    {
        grabbing = false;
    }
}