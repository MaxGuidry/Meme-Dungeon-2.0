using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Factory", menuName = "Factory", order = 1)]
public class ConcreteVehicleFactory : AbstractVehicleFactory
{

    public override IFactory GetVehicle(string name)
    {
        switch (name)
        {
            case "Bike":
                return new Bike();
            case "Scooter":
                return new Scooter();
            default:
                return null;
        }

    }
#if UNITY_EDITOR
    [CustomEditor(typeof(ConcreteVehicleFactory))]

    public class FactoryEditor : Editor
    {
        ConcreteVehicleFactory cvf;

        void OnEnable()
        {
            cvf = ScriptableObject.CreateInstance<ConcreteVehicleFactory>();
        }
        public IFactory vehicle;
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Bike"))
            {
                vehicle = cvf.GetVehicle("Bike");
                vehicle.Drive(8);
            }
            if (GUILayout.Button("Scooter"))
            {
                vehicle = cvf.GetVehicle("Scooter");
                vehicle.Drive(5);
            }

            if (vehicle != null)
                GUILayout.TextField(vehicle.ToString());


            base.OnInspectorGUI();
        }
    }
#endif
}
