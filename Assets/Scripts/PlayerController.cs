using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private Vector3 prevMousePos;
    private Vector3 currentMousePos;
    public GameObject follow;

    void Start()
    {
        currentMousePos = Input.mousePosition;

    }
    // Update is called once per frame
    void Update()
    {
        Quaternion originRot = this.transform.rotation;
        prevMousePos = currentMousePos;
        currentMousePos = Input.mousePosition;
        Vector3 dif = currentMousePos - prevMousePos;
        float angle = Mathf.Acos(Vector3.Dot(prevMousePos, currentMousePos) / (prevMousePos.magnitude * currentMousePos.magnitude));
        Quaternion combineRot = new Quaternion(0, Mathf.Sin(dif.x / 200), 0, Mathf.Cos(dif.x / 200)) * new Quaternion(Mathf.Sin(-dif.y / 200), 0, 0, Mathf.Cos(-dif.y / 200));
        Quaternion q = new Quaternion(0,0,0,1.0f) *  combineRot ;
        this.transform.rotation = this.transform.rotation * q;
        this.transform.position = follow.transform.position;
    }


}
