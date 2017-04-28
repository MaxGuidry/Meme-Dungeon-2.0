using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{

    private Color c;
    private Renderer rend;
    private Color original;
    [HideInInspector]
    public bool stay;
    // Use this for initialization
    void Start()
    {
        rend = GetComponentInParent<Renderer>();
        c = Random.ColorHSV();
        original = rend.material.color;
        stay = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rend.material.color = c;
            other.GetComponentInParent<PlayerWalk>().nodesOn.Add(gameObject);

        }

    }
  
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            if (!stay)
                rend.material.color = original;
            other.GetComponentInParent<PlayerWalk>().nodesOn.Remove(gameObject);

        }

    }
}
