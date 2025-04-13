using UnityEngine;

public class EncounterEntrance : MonoBehaviour
{
	void Awake()
	{
		GetComponent<SpriteRenderer>().enabled = false;
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player")){
            GetComponentInParent<EncounterZone>().ZoneStart();
        }
	}
}
