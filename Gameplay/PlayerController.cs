using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    UnitController _unitController;

    private void Awake(){
        _unitController = GetComponent<UnitController>();
    }
    public void OnMove(InputValue input){
        _unitController.Move(input.Get<Vector2>());
    }
    public void OnMeleeAttack(){
        _unitController.Attack();
    }
    public void OnRangedAttack(){
        
    }
    public void OnInteract(){
        _unitController.GetPlayerInteraction().Interact();
    }
}
