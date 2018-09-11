using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncMultipleScale : AudioSyncerMultipleBiases
{

	private IEnumerator MoveToScale(int bias)
	{
		Vector3 _curr = transform.localScale;
		Vector3 _initial = _curr;
		float _timer = 0;

		while (_curr != beatScales[bias])
		{
			_curr = Vector3.Lerp(_initial, beatScales[bias], _timer / timesToBeat[bias]);
			_timer += Time.deltaTime;

			transform.localScale = _curr;

			yield return null;
		}

		m_isBeat = false;
	}

	public override void OnUpdate()
	{
        _bias = BiasCheck();
        if (_bias != -1)
        {
            _prevBias = _bias;
            OnBeat(_bias);
        }

        if (m_isBeat) return;

        transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTimes[_prevBias] * Time.deltaTime);
	}

	public override void OnBeat(int bias)
	{
		base.OnBeat(bias);

		StopCoroutine("MoveToScale");
		StartCoroutine("MoveToScale", bias);
	}

    private int _prevBias = 0;
	public Vector3[] beatScales;
	public Vector3 restScale;
}
