﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class WaveMaker : MonoBehaviour {

    public float freqBaseLS;
    public float freqBaseRS;

    public float freqRngLS;
    public float freqRngRS;

    public float ampBaseLS;
    public float ampRangeLS;

    public float ampBaseRS;
    public float ampRangeRS;

    public List<float> pointsLS = new List<float>();
    public List<float> pointsRS = new List<float>();

    private float periodLS;
    private float periodRS;

    public float LSUD;
    public float LSLR;
    public float RSUD;
    public float RSLR;

    public float[] points;

    private VectorLine graphic;
    public Vector3[] values;
    public int segmentNum;
    public float lineWidth;

    // Use this for initialization
    void Start () {
        points = new float[100];
        values = new Vector3[100];

        for (int i = 0; i < 100; i++)
        {
            pointsLS.Add(0);
            pointsRS.Add(0);
            points[i] = 0.0f;
            values[i] = Vector3.zero;
        }
        InitLine();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MakeNewPoint();
        CombinePoints();
        DrawLine();
	}

    void MakeNewPoint ()
    {
        float freqModLS = freqBaseLS + (freqRngLS * LSLR);
        float freqModRS = freqBaseRS + (freqRngRS * RSLR);
        float ampModLS = ampBaseLS + (ampRangeLS * LSUD);
        float ampModRS = ampBaseRS + (ampRangeRS * RSUD);

        periodLS += freqModLS * Time.fixedDeltaTime;
        periodRS += freqModRS * Time.fixedDeltaTime;

        float nextPointLS = ampModLS * Mathf.Sin(periodLS);
        float nextPointRS = ampModRS * Mathf.Sin(periodRS);

        pointsLS.Add(nextPointLS);
        pointsRS.Add(nextPointRS);

        pointsLS.RemoveAt(0);
        pointsRS.RemoveAt(0);
    }

    void CombinePoints()
    {
        for (int i = 0; i < 100; i++)
        {
            points[i] = (pointsLS[i] + pointsRS[99 - i]);
        }
    }

    void DrawLine()
    {
        for (int i = 0; i < 100; i++)
        {
            values[i] = new Vector3(100 - (i * 2), points[i], 0);
        }
        graphic.MakeSpline(values);
        graphic.Draw();
    }

    public void InitLine()
    {
        graphic = new VectorLine("Squiggle", new List<Vector3>(segmentNum), null, lineWidth, LineType.Discrete, Joins.Weld);
    }

    public void ShutDownLine()
    {
        VectorLine.Destroy(ref graphic);
    }
}
