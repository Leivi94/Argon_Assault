using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 2f;
    [Tooltip ("Paricle FX on player")][SerializeField] GameObject deathFx;


    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFx.SetActive(true);
        Invoke("ReloadScene", 3f);
    }

    private void StartDeathSequence()
    {
        SendMessage("onPlayerDeath");
    }

    private void ReloadScene()
    {

        SceneManager.LoadScene(1);
    }


}

