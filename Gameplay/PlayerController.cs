using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    Movement _characterMovement;
    PlayerInteraction _playerInteraction;
    Attack _attack;

    private void Awake(){
        _characterMovement = GetComponent<Movement>();
        _playerInteraction = GetComponentInChildren<PlayerInteraction>();
        _attack = GetComponent<Attack>();
    }

    public void OnMove(InputValue input){
        _characterMovement.SetMoveDirection(input.Get<Vector2>());
    }
    public void OnMeleeAttack(InputValue input){
        _attack.InitiateAttack();
    }
    public void OnInteract(InputValue input){
        _playerInteraction.Interact();
    }
}
