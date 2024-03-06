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
    }
    private void OnMove()
    {
        Debug.Log("move");
        //  if the box is not full yet
        // {
                float _movementInput = playerActionControls.Land.Move.ReadValue<float>();
                float _horizontalMovement = _movementInput * moveSpeed;
                _rg.velocity = new Vector2(_horizontalMovement, _rg.velocity.y);

        // }
    }
        private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }
}
