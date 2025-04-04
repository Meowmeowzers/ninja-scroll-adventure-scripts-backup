using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Movement characterMovement;

    private void Awake(){
        characterMovement = GetComponent<Movement>();
    }

    public void OnMove(InputValue input){
        characterMovement.SetMoveDirection(input.Get<Vector2>());
    }
    public void OnMeleeAttack(InputValue input){
        characterMovement.Test();
    }
}
