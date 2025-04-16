using UnityEngine;

public class Scroll : MonoBehaviour
{
	[SerializeField] AudioClip[] _soundClip = {};

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.GetComponent<PlayerStats>()){
			GameManager.PlaySound(_soundClip[Random.Range(0, _soundClip.Length)]);
            Collection._instance.OnCollect?.Invoke();
            Destroy(gameObject);
        }
	}
}
