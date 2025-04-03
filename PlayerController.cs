using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    Movement characterMovement;

    private void Awake(){
        playerInput = GetComponent<PlayerInput>();
        characterMovement = GetComponent<Movement>();
    }

    // private void Update()
    // {
    //     if(playerInput.actions["Move"].IsPressed()){
    //         Debug.Log("Hello");
    //     }
    // }

    public void OnMove(InputValue input){
        characterMovement.SetMove(input.Get<Vector2>());
    }
    public void OnMeleeAttack(InputValue input){
        characterMovement.Test();
    }
}
