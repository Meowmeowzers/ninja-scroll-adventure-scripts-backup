using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test : MonoBehaviour
{
    public event Action ThingHappened;

	void Start()
	{
		StartCoroutine(DoThing());
	}

	public IEnumerator DoThing()
    {
        yield return new WaitForSeconds(3f);
        ThingHappened?.Invoke();
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.CompareTag("Player"))
		    collision.GetComponent<IDamageable>().DamageHealth(2f);
	}
}
