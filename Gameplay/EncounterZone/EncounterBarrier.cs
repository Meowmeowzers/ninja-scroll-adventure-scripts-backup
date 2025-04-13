using UnityEngine;

public class EncounterBarrier : MonoBehaviour
{
	void Awake()
	{
		GetComponent<SpriteRenderer>().enabled = false;
	}
}
