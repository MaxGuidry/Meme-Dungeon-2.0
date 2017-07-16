using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    [HideInInspector]
    public Vector2 position;
    public GameObject displayUI;
    // Use this for initialization
    void Start()
    {
        displayUI = GameObject.FindGameObjectWithTag("Grid");
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = other.gameObject.transform.position;
       // Debug.Log("we made it");
        displayUI.GetComponent<PlayerController2>().Nodes[position].GetComponent<Renderer>().material.color = Color.red;
    }
  
    void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.position = other.gameObject.transform.position;

        displayUI.GetComponent<PlayerController2>().Nodes[position].GetComponent<Renderer>().material.color = Color.white;


    }
}
