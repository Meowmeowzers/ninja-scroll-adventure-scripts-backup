using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableStat : Stats, IDamageable
{
    SpriteRenderer sr;
    ParticleSystem ps;
    BoxCollider2D col;
    AudioSource aus;
    [SerializeField] AudioClip[] _audioClips;
    [SerializeField] ItemDropTableSO _itemsToDrop;

    void Awake(){
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponent<ParticleSystem>();
        col = GetComponent<BoxCollider2D>();
        aus = GetComponent<AudioSource>();
    }

    public void RestoreHealth(float amount)
	{
	    return;
	}

    public void DamageHealth(float amount, List<DamageType> damageType){
        if(_isKO) return;
        foreach(var i in damageType){
            if(_damageTypeImmunities.Contains(i)) return;
        }

        _currentHealth -= amount;
        if(_currentHealth < 1f){
            _isKO = true;
            StartCoroutine(OnDestroyed());
        }
    }

    public IEnumerator OnDestroyed(){
        ps.Play();
        if(_audioClips.Length != 0){
            aus.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
        }
        _itemsToDrop.DropItem(transform.position);
        col.enabled = false;
        sr.enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
