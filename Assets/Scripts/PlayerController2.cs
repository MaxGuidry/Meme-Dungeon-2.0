using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController2 : MonoBehaviour
{
    public Canvas UI;
    private Vector2 position;
    public Text text;
    private Dictionary<Vector2, GameObject> Nodes = new Dictionary<Vector2, GameObject>();
    private List<string> inventory = new List<string>();
    // Use this for initialization
    void Start()
    {
        position = Vector2.zero;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Vector2 v = new Vector2(i, j);
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                go.transform.position = new Vector3(v.x - 14, v.y, go.transform.position.z);
                Nodes.Add(v, go);
            }
        }
        Nodes[position].GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        inputManager();
    }

    void inputManager()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            if (Nodes.ContainsKey(position + new Vector2(-1, 0)))
            {
                Nodes[position].GetComponent<Renderer>().material.color = Color.white;
                position += new Vector2(-1, 0);
                Nodes[position].GetComponent<Renderer>().material.color = Color.red;
                text.fontSize = 20;
                text.text = "You are at postion: " + position.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (Nodes.ContainsKey(position + new Vector2(1, 0)))
            {
                Nodes[position].GetComponent<Renderer>().material.color = Color.white;
                position += new Vector2(1, 0);
                Nodes[position].GetComponent<Renderer>().material.color = Color.red;
                text.fontSize = 20;
                text.text = "You are at postion: " + position.ToString();
            }

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (Nodes.ContainsKey(position + new Vector2(0, 1)))
            {
                Nodes[position].GetComponent<Renderer>().material.color = Color.white;
                position += new Vector2(0, 1);
                Nodes[position].GetComponent<Renderer>().material.color = Color.red;
                text.fontSize = 20;
                text.text = "You are at postion: " + position.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Nodes.ContainsKey(position + new Vector2(0, -1)))
            {
                Nodes[position].GetComponent<Renderer>().material.color = Color.white;
                position += new Vector2(0, -1);
                Nodes[position].GetComponent<Renderer>().material.color = Color.red;
                text.fontSize = 20;
                text.text = "You are at postion: " + position.ToString();
            }
        }
        if (position == new Vector2(4, 5))
        {
            inventory.Add("sword");

        }
        if (position == new Vector2(6, 3))
        {
            if (!inventory.Contains("sword"))
            {
                text.text = "Are you sure you want to enter the boss room with no sword?\nIf you enter there is a 95% chance of death."
                    + "\nPress Space to enter the room or move away from the room to search for a weapon.";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    int rng = Random.Range(0, 101);
                    if (rng >= 0 && rng <= 4)
                    {
                        GameObject g = new GameObject();
                        g.transform.parent = UI.transform;
                        Text gt = g.AddComponent<Text>();
                        gt = text;
                        gt.font = text.font;
                        gt.color = text.color;
                        RectTransform grt = g.AddComponent<RectTransform>();
                        grt = text.gameObject.GetComponent<RectTransform>();
                        gt.text = "You Defeated the Dragon barehanded.....\nLucky...";
                       

                    }
                    else
                    {
                        GameObject g = new GameObject();
                        g.transform.parent = UI.transform;
                        Text gt = g.AddComponent<Text>();
                        gt = text;
                        gt.font = text.font;
                        gt.color = text.color;
                        RectTransform grt = g.AddComponent<RectTransform>();
                        grt = text.gameObject.GetComponent<RectTransform>();
                        gt.text = "You died a horrible and painful death....\nGreat job...";
                       
                    }
                }
            }
            else
                text.text = "You are now entering the Boss room...";
        }
    }
   
}
