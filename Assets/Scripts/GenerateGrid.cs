using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{

    public GameObject cubePrefab;
    public GameObject bridgePrefab;
    [HideInInspector]
    public Dictionary<Vector2, GameObject> grid = new Dictionary<Vector2, GameObject>();
    private List<GameObject> Objects = new List<GameObject>();
    void Start()
    {
        CreateGrid();
    }
    [ContextMenu("Create")]
    void CreateGrid()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                var g = GameObject.Instantiate<GameObject>(cubePrefab, this.transform) as GameObject;
                g.transform.position = new Vector3(2 * 2.15f * i - 2.5f, 0, 2 * 2.15f * j - 2.5f);
                g.transform.localScale = new Vector3(2, 1, 2);
                var ng = new GameObject();
                Encounter e = ng.AddComponent<Encounter>();
                e.position = new Vector2(i, j);
                ng.transform.parent = g.transform;
                ng.transform.position = g.transform.position;
                var bc = ng.AddComponent<BoxCollider>();
                bc.center = new Vector3(0, 1.5f, 0);
                bc.size = new Vector3(g.transform.localScale.x, 2, g.transform.localScale.z);
                bc.isTrigger = true;
                Objects.Add(g);
                grid.Add(new Vector2(i,j),g);

                if (j < 4)
                {
                    var b = GameObject.Instantiate<GameObject>(bridgePrefab, this.transform) as GameObject;
                    b.transform.position = new Vector3(2 * 2.15f * i - 2.5f, .49f, 2 * 2.15f * j - .2f);
                    Rigidbody rbb = b.AddComponent<Rigidbody>();
                    rbb.isKinematic = true;
                    rbb.useGravity = false;
                    Objects.Add(b);
                }
                if (i < 4)
                {
                    var b = GameObject.Instantiate<GameObject>(bridgePrefab, this.transform) as GameObject;
                    b.transform.rotation = b.transform.rotation * new Quaternion(0, Mathf.Sin(Mathf.PI / 4), 0, Mathf.Cos(Mathf.PI / 4));
                    b.transform.position = new Vector3(2 * 2.15f * i - .2f, .49f, 2 * 2.15f * j - 2.5f);
                    Rigidbody rbb = b.AddComponent<Rigidbody>();
                    rbb.isKinematic = true;
                    rbb.useGravity = false;
                    Objects.Add(b);
                }
            }
        }
    }
    [ContextMenu("Destroy")]
    void DestroyGrid()
    {
        for (int i = 0; i < grid.Count; i++)
        {
            DestroyImmediate(Objects[i]);

        }
        grid.Clear();
    }

}
