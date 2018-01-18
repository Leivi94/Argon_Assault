using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    // Use this for initialization
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    void AddNonTriggerBoxCollider()
    {
        Collider boxColider = gameObject.AddComponent<BoxCollider>();
        boxColider.isTrigger = false;

    }
    

void OnParticleCollision(GameObject other)
    {
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
