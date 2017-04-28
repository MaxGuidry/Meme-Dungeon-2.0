using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector3 prevMousePos;
    private Vector3 currentMousePos;
    void Start()
    {
        currentMousePos = Input.mousePosition;

    }
    // Update is called once per frame
    void Update()
    {
        prevMousePos = currentMousePos;
        currentMousePos = Input.mousePosition;

        float angle = Mathf.Acos(Vector3.Dot(prevMousePos, currentMousePos) / (prevMousePos.magnitude * currentMousePos.magnitude));
        this.transform.rotation = this.transform.rotation * new Quaternion(0, Mathf.Sin(angle / 2), 0, Mathf.Cos(angle / 2));
    }

  
}
