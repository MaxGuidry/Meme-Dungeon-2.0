using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mathtest : MonoBehaviour
{
    public float radius;
    public float interval;
    public List<Vector3> spherepoints = new List<Vector3>();

    // Use this for initialization
    void Start()
    {
        for (float y = radius; y > -radius; y -= interval)
        {
            float x = Mathf.Sqrt((radius * radius) - (y * y));
            for (float n = x; n > -x; n -= interval)
            {
                float z = Mathf.Sqrt((x * x) - (n * n));

                spherepoints.Add(new Vector3(n, y, z));
                spherepoints.Add(new Vector3(n, y, -z));


            }
        }
        foreach (Vector3 v in spherepoints)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Matrix4x4 test = new Matrix4x4();
            test.SetRow(0, new Vector4(1, 0, 0, v.x));
            test.SetRow(1, new Vector4(0, 1, 0, v.y));
            test.SetRow(2, new Vector4(0, 0, 1, v.z));
            test.SetRow(3, new Vector4(0, 0, 0, 1));
            g.transform.position = test * new Vector4(g.transform.position.x, g.transform.position.y, g.transform.position.z, 1);
            Vector3 direction = Vector3.zero - this.transform.position;


        }
    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4 objectMat = new Matrix4x4();
        objectMat.SetRow(0, new Vector4(transform.forward.x, transform.up.x, transform.right.x));
        objectMat.SetRow(1, new Vector4(transform.forward.y, transform.up.y, transform.right.y));
        objectMat.SetRow(2, new Vector4(transform.forward.z, transform.up.z, transform.right.z));
        Matrix4x4 rotMat = new Matrix4x4();
        rotMat.SetRow(0, new Vector4(Mathf.Cos(Mathf.Deg2Rad), 0, Mathf.Sin(Mathf.Deg2Rad)));
        rotMat.SetRow(1, new Vector4(0, 1, 0));
        rotMat.SetRow(2, new Vector4(-Mathf.Sin(Mathf.Deg2Rad), 0, Mathf.Cos(Mathf.Deg2Rad)));
        objectMat *= rotMat;
        this.transform.forward = objectMat.GetRow(0);
        this.transform.up = objectMat.GetRow(1);
        this.transform.right = objectMat.GetRow(2);
    }
}
