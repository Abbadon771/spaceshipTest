using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour {

    public Transform target;
    private Vector3 defaultDist = new Vector3(0.5f, 4f, -15f);
    private float distanceDamp = 10;
    private float rotationalDamp = 10f;
    Transform myT;

    void Awake()
    {
        myT = transform;
    }

    void LateUpdate()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDist);
        Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);
        myT.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
        Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationalDamp * Time.deltaTime);
        myT.rotation = curRot;
    }
}
