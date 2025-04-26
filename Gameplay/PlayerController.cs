using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    UnitController _unitController;
    bool enableControl = true;

    private void Awake(){
        _unitController = GetComponent<UnitController>();
    }
    public void OnMove(InputValue input){
        if(Pause.IsGamePaused() || !enableControl) return;
        
        _unitController.Move(input.Get<Vector2>());
    }
    public void OnMeleeAttack(){
        if(Pause.IsGamePaused() || !enableControl) return;

        if(_unitController.GetAttack().GetWeapon().GetIndex() != 0)
            _unitController.SwitchAttack(0);
        _unitController.Attack();
    }
    public void OnRangedAttack(){
        if(Pause.IsGamePaused() || !enableControl) return;

        if(_unitController.GetAttack().GetWeapon().GetIndex() != 1)
            _unitController.SwitchAttack(1);
        _unitController.Attack();
    }
    public void OnInteract(){
        if(Pause.IsGamePaused() || !enableControl) return;

        _unitController.GetPlayerInteraction().Interact();
    }
    public void OnPause(){
        if(GameManager.instance.GetState() == GameState.Paused || !enableControl) return;
        
        Pause.PauseGame();
        FindObjectOfType<GameManager>().PauseGame();
    }

    public void EnableControl(bool value){
        enableControl = value;
    }
}
