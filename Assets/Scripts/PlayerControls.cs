using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float xOffset = 0.1f;

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

    // Update is called once per frame
    void Update()
    {
        float xMovement = movement.ReadValue<Vector2>().x;
        float yMovement = movement.ReadValue<Vector2>().y;

        transform.localPosition = new Vector3 (transform.localPosition.x + xOffset, transform.localPosition.y, transform.localPosition.z);
    }
}
