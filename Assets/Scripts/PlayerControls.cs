using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.WebCam;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 5f;
    [SerializeField] float xRange = 3f;
    [SerializeField] float yRange = 2f;

    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor = 10f;

    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -25f;

    float xMovement;
    float yMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        movement.Enable();
    }

    private void OnDisable() {
        movement.Disable();
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xMovement = movement.ReadValue<Vector2>().x;
        yMovement = movement.ReadValue<Vector2>().y;

        float xOffset = xMovement * controlSpeed * Time.deltaTime;
        float yOffset = yMovement * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYpos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yMovement * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xMovement * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
