using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSyncMoveBeat : AudioSyncer
{

    private IEnumerator MoveForward(Vector3 targetPosition)
    {
        float timer = 0;
        Vector3 initial = transform.position;
        Vector3 curr = initial;

        while (transform.position != targetPosition)
        {
            curr = Vector3.Lerp(initial, targetPosition, timer / timeToBeat);
            timer += Time.deltaTime;

            transform.position = curr;

            yield return null;
        }

        m_isBeat = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;

        //m_img.color = Color.Lerp(m_img.color, restColor, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - distanceToMove);

        StopCoroutine("MoveForward");
        StartCoroutine("MoveForward", newPosition);
    }

    private void Start()
    {
        
    }

    public float distanceToMove;
    
    
}
