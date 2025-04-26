using UnityEngine;

public class EncounterSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject trackedSpawn;
    bool isActive = false;
    event System.Action Pawned;
    System.Action action;

    void Update()
    {
        if(isActive){
            if(trackedSpawn != null && trackedSpawn.GetComponent<UnitController>().GetState() == CharacterState.KO){
                isActive = false;
                Pawned?.Invoke();
            }
        }
    }

    public void Spawn(System.Action reduce)
	{
        trackedSpawn = Instantiate(spawn, transform);
        Pawned += reduce;
        action = reduce;
        isActive = true;
    }

	void OnDisable()
	{
		Pawned -= action;
	}
}
