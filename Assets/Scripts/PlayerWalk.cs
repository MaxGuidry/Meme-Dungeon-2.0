using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> nodesOn;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += this.transform.forward * .03f;
        }
        if(Input.GetKey(KeyCode.S))
        {
            this.transform.position += this.transform.forward * -.03f;
        }
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.position += this.transform.right * -.03f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.position += this.transform.right * .03f;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            if(nodesOn.Count !=0)
            {
                foreach(GameObject g in nodesOn)g.GetComponent<Encounter>().stay = true;
            }
            
        }
        if(Input.GetKey(KeyCode.R))
        {
            if(nodesOn.Count !=0)
            {
                foreach (GameObject g in nodesOn) g.GetComponent<Encounter>().stay = false;
            }
        }
    }
}
