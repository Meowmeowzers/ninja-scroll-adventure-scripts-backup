using UnityEngine;

public class RestoreHPOnCollide : MonoBehaviour
{
	[SerializeField] float _heal = 1f;
    [SerializeField] float _timeBeforeDisappear = 10f;
	[SerializeField] AudioClip[] _soundClip = {};

	void Start()
	{
		Invoke(nameof(Disappear), _timeBeforeDisappear);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.GetComponent<PlayerStats>()){
            collision.GetComponent<PlayerStats>().RestoreHealth(_heal);
			GameManager.instance.audioPlayer.PlaySound(_soundClip[Random.Range(0, _soundClip.Length)]);
            Destroy(gameObject);
        }
	}

    void Disappear(){
        Destroy(gameObject);
    }
}
