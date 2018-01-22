using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{

    [Header("General")]
    [Tooltip("In m^-1")] [SerializeField] float Speed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3.8f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position based")]
    [SerializeField] float positionYawFactor = 10f;
    [SerializeField] float positionPitchFactor = -5f;

    [Header("Screen-control based")]
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float controlRollFactor = -30f;

    float yThrow, xThrow;
    bool isDead = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { return; }
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    void onPlayerDeath()
    {
        isDead = true;
    }

    private void ProcessTranslation()
    {

        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yawhDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawhDueToPosition;

        float rollhDueToControl = xThrow * controlRollFactor;
        float roll = rollhDueToControl;


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }


    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            SetGunsActive(true);
               
                
        } else
        {
            SetGunsActive(false);
        }


    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var ParticleEmission = gun.GetComponent<ParticleSystem>().emission;
            ParticleEmission.enabled = isActive;

        }
    }

   
        
    }


