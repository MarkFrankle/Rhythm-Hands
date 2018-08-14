using UnityEngine;
using System.Collections;
public class GazeManager : MonoBehaviour
{
    public float sightlength = 100.0f;
    public GameObject selectedObj;

    private int layerMask;

    void Awake()
    {
        layerMask = LayerMask.GetMask("ButtonUI");
    }

    void FixedUpdate()
    {
        RaycastHit seen;
        Ray raydirection = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(raydirection, out seen, sightlength, layerMask))
        {
            selectedObj = seen.transform.gameObject;
            if (selectedObj.tag == "UI")
            {
                Debug.Log("RaycastHit UI: " + selectedObj.name);
            }
        }
    }
}