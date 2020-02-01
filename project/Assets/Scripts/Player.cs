using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 20f;
    [Tooltip("In m")][SerializeField] float xRange = 8f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 20f;
    [Tooltip("In m")][SerializeField] float yMin = -5f;
    [Tooltip("In m")][SerializeField] float yMax = 0;

    [SerializeField] float basePitch = -30f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 4.3f;
    [SerializeField] float controlRollFactor = -20f;

    private float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");   

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float newXPosition = transform.localPosition.x + xOffset;
        float newYPosition = transform.localPosition.y + yOffset;

        newXPosition = Mathf.Clamp(newXPosition, -xRange, xRange);
        newYPosition = Mathf.Clamp(newYPosition, yMin, yMax);
        transform.localPosition = new Vector3(newXPosition, newYPosition, transform.localPosition.z);
    }

    private void HandleRotation() {
        float pitch = basePitch + transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
