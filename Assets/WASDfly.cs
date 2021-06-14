﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class WASDfly : MonoBehaviour
{
    public float mainSpeed = 10.0f;
    public float camSens = 0.05f;

    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/

    bool flyingEnabled = true;

    ///float mainSpeed = turnSpeed; //100.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    //float camSens = mouseSensitivity; //0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    flyingEnabled = !flyingEnabled;
        //    if (flyingEnabled)
        //    {
        //        lastMouse = Input.mousePosition;
        //    }
        //}
        //if (!flyingEnabled)
        //{
        //    return;
        //}

        //lastMouse = Input.mousePosition - lastMouse;
        //lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        //lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        //transform.eulerAngles = lastMouse;
        //lastMouse = Input.mousePosition;
        ////Mouse  camera angle done.  

        ////Keyboard commands
        //float f = 0.0f;
        //Vector3 p = GetBaseInput();
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    totalRun += Time.deltaTime;
        //    p = p * totalRun * shiftAdd;
        //    p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
        //    p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
        //    p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        //}
        //else
        //{
        //    totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
        //    p = p * mainSpeed;
        //}

        //p = p * Time.deltaTime;
        //Vector3 newPosition = transform.position;
        //if (Input.GetKey(KeyCode.Space))
        //{ //If player wants to move on X and Z axis only
        //    transform.Translate(p);
        //    newPosition.x = transform.position.x;
        //    newPosition.z = transform.position.z;
        //    transform.position = newPosition;
        //}
        //else
        //{
        //    transform.Translate(p);
        //}
    }

    //void OnPostRender()
    //{
    //    Matrix4x4 cameraToWorld = Camera.main.cameraToWorldMatrix;
    //    cameraToWorld = cameraToWorld.inverse;
    //    float[] cameraToWorldArray = new float[16];
    //    for (int i = 0; i < 4; i++)
    //    {
    //        for (int j = 0; j < 4; j++)
    //        {
    //            cameraToWorldArray[i * 4 + j] = cameraToWorld[i, j];
    //        }
    //    }
    //    GCHandle pointerTocameraToWorld = GCHandle.Alloc(cameraToWorldArray, GCHandleType.Pinned);

    //    Camera.main.enabled = true;

    //    //Matrix4x4 projection = Camera.main.nonJitteredProjectionMatrix;
    //    Matrix4x4 projection = GL.GetGPUProjectionMatrix(Camera.main.projectionMatrix, true);

    //    float[] projectionArray = new float[16];
    //    for (int i = 0; i < 4; i++)
    //    {
    //        for (int j = 0; j < 4; j++)
    //        {
    //            projectionArray[i * 4 + j] = projection[i, j];
    //        }
    //    }
    //    GCHandle pointerProjection = GCHandle.Alloc(projectionArray, GCHandleType.Pinned);

    //    updateCamera(pointerTocameraToWorld.AddrOfPinnedObject(), pointerProjection.AddrOfPinnedObject());

    //    pointerTocameraToWorld.Free();
    //    pointerProjection.Free();

    //    Matrix4x4 world;
    //    float[] worldArray = new float[16];
    //    GCHandle pointerWorld;

    //    for (int i = 0; i < pointCloudManager.pointClouds.Count; i++)
    //    {
    //        world = pointCloudManager.pointClouds[i].inSceneRepresentation.transform.localToWorldMatrix;
    //        for (int j = 0; j < 4; j++)
    //        {
    //            for (int k = 0; k < 4; k++)
    //            {
    //                worldArray[j * 4 + k] = world[j, k];
    //            }
    //        }

    //        pointerWorld = GCHandle.Alloc(worldArray, GCHandleType.Pinned);
    //        updateWorldMatrix(pointerWorld.AddrOfPinnedObject(), i);
    //        pointerWorld.Free();
    //    }

    //    GL.IssuePluginEvent(GetRenderEventFunc(), 1);
    //}

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.X))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        return p_Velocity;
    }
}