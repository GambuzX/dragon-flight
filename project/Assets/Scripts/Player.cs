using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 1f;
    [Tooltip("In ms^-1")][SerializeField] float xRange = 5f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 1f;
    [Tooltip("In ms^-1")][SerializeField] float yRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalTrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");   

        float xOffset = horizontalTrow * xSpeed * Time.deltaTime;
        float yOffset = verticalThrow * ySpeed * Time.deltaTime;

        float newXPosition = transform.localPosition.x + xOffset;
        float newYPosition = transform.localPosition.y + yOffset;

        newXPosition = Mathf.Clamp(newXPosition, -xRange, xRange);
        newYPosition = Mathf.Clamp(newYPosition, -yRange, yRange);
        transform.localPosition = new Vector3(newXPosition, newYPosition, transform.localPosition.z);
    }
}
