﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Ocillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(1000f, 1000f, 1000f);
    [SerializeField] float period = 1000f;

    float movementFactor;

    Vector3 startingPos;
	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) { return; }
        float cycle = Time.time / period;

        const float tau = Mathf.PI * 2; // 6.2
        float rawSinWave = Mathf.Sin(cycle * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
