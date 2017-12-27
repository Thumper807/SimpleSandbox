using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour {

    public float MinSize = 0.5f;
    public float MaxSize = 2.0f;
    public float MinGrowthRate = 0.5f;
    public float MaxGrowthRate = 2.0f;
    public bool Dead;
    private float m_initialSize;
    private float m_matureSize;
    private float m_growthRate;

	// Use this for initialization
	void Start ()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        m_initialSize = m_matureSize * .25f;
        m_matureSize = Random.Range(MinSize, MaxSize);
        m_growthRate = Random.Range(MinGrowthRate, MaxGrowthRate);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
