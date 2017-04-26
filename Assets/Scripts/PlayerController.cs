using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public InputField inputField;
    private Vector2 position;
    void Start()
    {
        inputField.onEndEdit.AddListener(updateinput);


    }
    // Update is called once per frame
    void Update()
    {
    }

    void updateinput(string f)
    {
        if (inputField.text.ToUpper() == "W")
        {
            position += new Vector2(-1, 0);
        }
        else if (inputField.text.ToUpper() == "E")
        {
            position += new Vector2(1, 0);
        }
        else if (inputField.text.ToUpper() == "N")
        {
            position += new Vector2(0, 1);
        }
        else if (inputField.text.ToUpper() == "S")
        {
            position += new Vector2(0, -1);
        }

    }
}
