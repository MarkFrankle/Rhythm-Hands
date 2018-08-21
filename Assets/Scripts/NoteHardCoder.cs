using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHardCoder : MonoBehaviour
{

    public Material mat1;
    public Material mat2;
    public GameObject note;
    public GameObject beatParent;

    public bool CreateMode;
    public KeyCode key;

    private GameObject temp;
    void Update()
    {
        if (CreateMode && Input.GetKeyDown(key))
        {
            temp = Instantiate(note, transform.position, Quaternion.Euler(90, 0, 0));
            temp.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            temp.transform.parent = beatParent.transform;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Touched: " + col.gameObject.name);
        GetComponent<MeshRenderer>().material = mat2;
    }

    void OnTriggerExit(Collider col)
    {
        GetComponent<MeshRenderer>().material = mat1;
    }
}
