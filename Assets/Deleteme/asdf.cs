using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdf : MonoBehaviour {

    void Awake()
    {
        StartCoroutine(PrintNonsense());
    }
	
    IEnumerator PrintNonsense()
    {
        while (true)
        {

            Debug.Log("Nonsense");
            yield return null;
        }

    }
}
