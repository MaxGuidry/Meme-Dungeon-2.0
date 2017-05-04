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
        this.transform.rotation = new Quaternion(0, 0, 0, 1);




        prevMousePos = currentMousePos;
        currentMousePos = Input.mousePosition;
        Vector3 dif = currentMousePos - prevMousePos;

        Quaternion combineRot = new Quaternion(0, Mathf.Sin(((dif.x / 150f) + ((originRot.eulerAngles.y * Mathf.PI) / 180)) / 2f), 0, Mathf.Cos(((dif.x / 150f)
            + ((originRot.eulerAngles.y * Mathf.PI) / 180)) / 2)) * 
            new Quaternion(Mathf.Sin(((-dif.y / 100f) + ((originRot.eulerAngles.x * Mathf.PI) / 180)) / 2f), 0, 0, Mathf.Cos(((-dif.y / 100f) + 
            ((originRot.eulerAngles.x * Mathf.PI) / 180)) / 2));

        this.transform.rotation = this.transform.rotation * combineRot;
        if ((this.transform.eulerAngles.x > 265 && this.transform.eulerAngles.x < 275) || (this.transform.eulerAngles.x > 85 && this.transform.eulerAngles.x < 95))
            this.transform.rotation = originRot;
            
        this.transform.position = follow.transform.position;
    }


}
