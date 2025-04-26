using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] GameObject _move;
    [SerializeField] GameObject _attack;
    [SerializeField] GameObject _scroll;
    [SerializeField] GameObject _enemies;

    public void ShowMove(){
        _move.SetActive(true);
        _attack.SetActive(false);
        _scroll.SetActive(false);
        _enemies.SetActive(false);
    }
    public void ShowAttack(){
        _move.SetActive(false);
        _attack.SetActive(true);
        _scroll.SetActive(false);
        _enemies.SetActive(false);
    }
    public void ShowScrolls(){
        _move.SetActive(false);
        _attack.SetActive(false);
        _scroll.SetActive(true);
        _enemies.SetActive(false);
    }
    public void ShowEnemies(){
        _move.SetActive(false);
        _attack.SetActive(false);
        _scroll.SetActive(false);
        _enemies.SetActive(true);
    }
    public void HideTutorialScreen(){
        _move.SetActive(false);
        _attack.SetActive(false);
        _scroll.SetActive(false);
        _enemies.SetActive(false);
    }

}
