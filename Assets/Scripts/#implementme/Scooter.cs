using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooter : IFactory {
    public void Drive(int i)
    {
        Debug.Log("Driving with speed: " + i.ToString());
    }

   
}
