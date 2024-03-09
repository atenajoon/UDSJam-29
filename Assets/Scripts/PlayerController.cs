using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActionControls playerActionControls;
    private Rigidbody2D _rg;
    public float moveSpeed;
    
    void Awake()
    {
        playerActionControls = new PlayerActionControls();
        _rg = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        // KeepPlayerInCamera();
    }
    private void OnMove()
    {
        // Debug.Log("move");
        //  if the box is not full yet
        // {
                float _movementInput = playerActionControls.Land.Move.ReadValue<float>();
                float _horizontalMovement = _movementInput * moveSpeed;
                _rg.velocity = new Vector2(_horizontalMovement, _rg.velocity.y);

        // }
    }
    // private void KeepPlayerInCamera()
    // {
    //     // Get the player character's position
    //     Vector3 playerPosition = transform.position;

    //     // Get the camera's bounds in world space
    //     Vector3 cameraMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)); // the bottom-left of the camera
    //     Vector3 cameraMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)); // top-right

    //     // Check if the player is outside the camera's bounds
    //     if (playerPosition.x < cameraMin.x)
    //     {
    //         playerPosition.x = cameraMin.x;
    //     }
    //     else if (playerPosition.x > cameraMax.x)
    //     {
    //         playerPosition.x = cameraMax.x;
    //     }

    //     // Update the player character's position
    //     transform.position = playerPosition;
    // }
    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }
}
