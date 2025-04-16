using System.Collections;
using UnityEngine;

public class EnemyStats : Stats, IDamageable
{
    [SerializeField] AudioClip _KOSound;

    public void RestoreHealth(float amount){
        if(_isKO) return;

        _currentHealth += amount;

        if(_currentHealth > _maxHealth){
            _currentHealth = _maxHealth;
        }
    }
    public void DamageHealth(float amount){
        if(_isKO) return;

        _currentHealth -= amount;
        OnUnitDamaged();
        if(_currentHealth < 1f){
            _isKO = true;
            if(_KOSound != null) GameManager.PlaySound(_KOSound);
            GetComponent<ItemDrop>().DropItem(transform.position);
            OnUnitIsKO();
            StartCoroutine(nameof(RemoveBody));
        }
    }

    IEnumerator RemoveBody(){
        float x = 1f;
        for(var i = 0; i < 5; i++){
            x -= 0.2f;
            GetComponent<SpriteRenderer>().color = new(1f,1f,1f,x);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
        Destroy(gameObject);
    }
}
