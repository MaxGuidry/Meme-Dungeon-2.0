using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractVehicleFactory : ScriptableObject
{

    public virtual IFactory GetVehicle(string name)
    {
        return null;
    }
}
   
