using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSyncMultipleMovement : AudioSyncerMultipleBiases
{

    private IEnumerator MoveForward(int bias)
    {
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - distancesToMove[bias]);

        float timer = 0;
        Vector3 initial = transform.position;
        Vector3 curr = initial;

        while (transform.position != targetPosition)
        {
            curr = Vector3.Lerp(initial, targetPosition, timer / timesToBeat[bias]);
            timer += Time.deltaTime;

            transform.position = curr;

            yield return null;
        }

        m_isBeat = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        // if audio value went below the bias during this frame

        _bias = BiasCheck();
        if (_bias != -1)
        {
            OnBeat(_bias);
        }

        if (m_isBeat) return;

        //m_img.color = Color.Lerp(m_img.color, restColor, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat(int bias)
    {
        base.OnBeat(bias);


        StopCoroutine("MoveForward");
        StartCoroutine("MoveForward", bias);
    }

    private void Start()
    {
        
    }

    public float[] distancesToMove = new float[5];


}
