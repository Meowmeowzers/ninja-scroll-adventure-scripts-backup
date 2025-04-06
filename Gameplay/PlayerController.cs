using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    Movement _characterMovement;
    PlayerInteraction _playerInteraction;

    private void Awake(){
        _characterMovement = GetComponent<Movement>();
        _playerInteraction = GetComponentInChildren<PlayerInteraction>();
    }

    public void OnMove(InputValue input){
        _characterMovement.SetMoveDirection(input.Get<Vector2>());
    }
    public void OnMeleeAttack(InputValue input){
        _characterMovement.Test();
    }
    public void OnInteract(InputValue input){
        _playerInteraction.Interact();
    }
}
