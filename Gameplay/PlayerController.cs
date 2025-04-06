using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private Movement _characterMovement;

    private void Awake(){
        _characterMovement = GetComponent<Movement>();
    }

    public void OnMove(InputValue input){
        _characterMovement.SetMoveDirection(input.Get<Vector2>());
    }
    public void OnMeleeAttack(InputValue input){
        _characterMovement.Test();
    }
}
