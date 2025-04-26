using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : Stats, IDamageable
{
   [SerializeField] AudioClip _KOSound;
   [SerializeField] GameObject _particlesOnKO;

    public void RestoreHealth(float amount){
        if(_isKO) return;

        _currentHealth += amount;

        if(_currentHealth > _maxHealth){
            _currentHealth = _maxHealth;
        }
    }
    public void DamageHealth(float amount, List<DamageType> damageType){
        if(_isKO) return;
        foreach(var i in damageType){
            if(_damageTypeImmunities.Contains(i)) return;
        }

        _currentHealth -= amount;
        UnitDamaged();
        if(_currentHealth < 1f){
            _isKO = true;
            if(_KOSound != null) GameManager.instance.audioPlayer.PlaySound(_KOSound);
            GetComponent<ItemDrop>().DropItem(transform.position);
            if(_particlesOnKO != null) Instantiate(_particlesOnKO, transform.position, Quaternion.identity);
            UnitKO();
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
