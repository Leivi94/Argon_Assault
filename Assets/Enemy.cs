﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int ScorePerHit = 12;


    ScoreBoard scoreBoard;

    // Use this for initialization
    void Start()
    {
        addBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
 
    private void addBoxCollider()
    {
        Collider boxColider = gameObject.AddComponent<BoxCollider>();
        boxColider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(ScorePerHit);
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        StartEnemyDeathSequence();
    }

    private void StartEnemyDeathSequence()
    {
        deathFx.SetActive(true);
        Destroy(gameObject);
    }
}
