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
        if(_unitController.GetAttack().GetWeapon().GetIndex() != 0)
            _unitController.SwitchAttack(0);
        _unitController.Attack();
    }
    public void OnRangedAttack(){
        if(_unitController.GetAttack().GetWeapon().GetIndex() != 1)
            _unitController.SwitchAttack(1);
        _unitController.Attack();
    }
    public void OnInteract(){
        _unitController.GetPlayerInteraction().Interact();
    }
}
