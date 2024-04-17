using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Debug.Log("horizontal movement: " + horizontalMovement);
        float verticalMovement = Input.GetAxis("Vertical");
        Debug.Log("Vertical movement: " + verticalMovement);
    }
}
