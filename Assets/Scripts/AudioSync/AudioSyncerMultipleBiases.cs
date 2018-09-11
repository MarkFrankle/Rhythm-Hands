using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class responsible for extracting beats from..
/// ..spectrum value given by AudioSpectrum.cs
/// </summary>
public class AudioSyncerMultipleBiases : MonoBehaviour {

	/// <summary>
	/// Inherit this to cause some behavior on each beat
	/// </summary>
	public virtual void OnBeat(int bias)
	{
		Debug.Log("beat");
		m_timer = 0;
		m_isBeat = true;
	}

	/// <summary>
	/// Inherit this to do whatever you want in Unity's update function
	/// Typically, this is used to arrive at some rest state..
	/// ..defined by the child class
	/// </summary>
	public virtual void OnUpdate()
	{ 
		// update audio value
		m_previousAudioValue = m_audioValue;
		m_audioValue = AudioSpectrum.spectrumValue;

        //// if audio value went below the bias during this frame
        //bias = BiasCheck();
        //if (bias != -1)
        //{
        //    OnBeat();
        //}

		m_timer += Time.deltaTime;
	}

	private void Update()
	{
		OnUpdate();
	}

    protected int BiasCheck()
    {
        // if audio went below any of the biases during this frame
        for(int i = 0; i < NumberOfBiases; i++)
        {
            if (m_previousAudioValue > biases[i] &&
                        m_audioValue <= biases[i] &&
                        m_timer > timeSteps[i])
                return i;
        }
        

        // if audio value went above any of the biases during this frame
        for (int i = 0; i < NumberOfBiases; i++)
        {
            if (m_previousAudioValue <= biases[i] &&
                        m_audioValue > biases[i] &&
                        m_timer > timeSteps[i])
                return i;
        }
        return -1;
    }

    public int NumberOfBiases;
    public float[] biases = new float[5];
    public float[] timeSteps = new float[5];
    public float[] timesToBeat = new float[5];
    public float[] restSmoothTimes = new float[5];

    private float m_previousAudioValue;
	private float m_audioValue;
	private float m_timer;

    protected int _bias;
	protected bool m_isBeat;
}
