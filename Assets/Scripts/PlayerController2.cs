using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController2 : MonoBehaviour {

    private Vector2 position;
    public Text text;
	// Use this for initialization
	void Start ()
    {
        position = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.W))
        {
            position += new Vector2(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            position += new Vector2(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            position += new Vector2(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            position += new Vector2(0, -1);
        }
        text.text = position.ToString();
    }
}
