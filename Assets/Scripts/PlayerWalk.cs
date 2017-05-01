using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> nodesOn;
    public GameObject cameraAttached;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(cameraAttached.transform.forward.x, 0, cameraAttached.transform.forward.z) *.03f;
        }   
        if(Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(cameraAttached.transform.forward.x, 0, cameraAttached.transform.forward.z) * -.03f;
        }
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(cameraAttached.transform.right.x, 0, cameraAttached.transform.right.z) * -.03f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(cameraAttached.transform.right.x, 0, cameraAttached.transform.right.z) * .03f;
        }
        
    }
}
