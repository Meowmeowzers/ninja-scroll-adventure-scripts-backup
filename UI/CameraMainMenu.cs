using System.Collections;
using UnityEngine;

public class CameraMainMenu : MonoBehaviour
{
    [SerializeField] Transform[] _waypoints;
    [SerializeField] float _moveSpeed = 2f;
    [SerializeField] float _waitTime = 1f;
    int _currentIndex = 0;
	
    void Awake()
	{
        _currentIndex = Random.Range(0, _waypoints.Length);
	}

	private void Start()
    {
        if (_waypoints.Length == 0)
        {
            enabled = false;
            return;
        }

        transform.position = _waypoints[_currentIndex].position;
        StartCoroutine(MoveThroughWaypoints());
    }

    private IEnumerator MoveThroughWaypoints()
    {
        while (true)
        {
            Vector3 targetPos = _waypoints[_currentIndex].position;

            while (Vector3.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = 
                    Vector3.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.position = targetPos;
            yield return new WaitForSeconds(_waitTime);

            _currentIndex++;

            if (_currentIndex >= _waypoints.Length) _currentIndex = 0;
        }
    }
}
