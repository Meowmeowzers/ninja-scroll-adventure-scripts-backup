using System.Collections;
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

    public void DamageHealth(float amount){
        if(_isKO) return;

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
