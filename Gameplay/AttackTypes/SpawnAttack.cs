using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Attacks/SpawnAttack")]
public class SpawnAttack : AttackType
{
    [SerializeField] GameObject _spawn;
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] int _numberOfSpawns = 2;
    [SerializeField] float _spawnRadius = 5f;
    [SerializeField] GameObject _spawnEffect;
	[SerializeField] AudioClip _weaponSound;
	
	public override void InitializeWeapon(Weapon weapon){
		if(_weaponSprite != null){
			SpriteRenderer sr = weapon.GetComponent<SpriteRenderer>();
			BoxCollider2D col = weapon.GetComponent<BoxCollider2D>();

			sr.sprite = _weaponSprite;
			col.size = sr.bounds.size;
			col.offset = (Vector2)(_weaponSprite.bounds.size / 2f) - (_weaponSprite.pivot / _weaponSprite.pixelsPerUnit);
		}
		weapon.GetComponent<SpriteRenderer>().enabled = false;
      	weapon.GetComponent<BoxCollider2D>().enabled = false;
		weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
	}

	public override void StartWeapon(Weapon weapon){
		if(_weaponSound != null)
			GameManager.instance.audioPlayer.PlaySound(_weaponSound, 0.8f);
	}
	public override void ExitWeapon(Weapon weapon){}

    public override void Execute(Weapon weapon, GameObject source){
        int attempts = _numberOfSpawns * 10;

        for(int i = 0; i < _numberOfSpawns; i++){
            for (int j = 0; j < attempts; j++){
                Vector2 randomOffset = Random.insideUnitCircle.normalized * Random.Range(0, _spawnRadius);
                Vector2 spawnPosition = (Vector2)source.transform.position + randomOffset;

                if (IsValidSpawn(spawnPosition, .4f, LayerMask.GetMask("Unwalkable", "Default"))){
                    if(_spawnEffect != null) Instantiate(_spawnEffect, spawnPosition, Quaternion.identity);
                    Instantiate(_spawn, spawnPosition, Quaternion.identity);
                    break;
                }
            }
        }
	}

    bool IsValidSpawn(Vector2 position, float radius, int mask){
        return Physics2D.OverlapCircle(position, radius, mask) == null;
    }

	public override float GetDamage() => 0;
}
