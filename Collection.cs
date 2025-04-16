using System;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public static Collection _instance;

    [SerializeField] int _scrollCollection = 0;
    public Action OnCollect;
    public Action<int> OnScrollUpdate;

    private void Awake()
    {
        _instance = this;
    }

	void OnEnable()
	{
		OnCollect += IncreaseCollection;
	}
	void OnDisable()
	{
		OnCollect -= IncreaseCollection;
	}

	public void IncreaseCollection(){
        _scrollCollection++;
        OnScrollUpdate?.Invoke(_scrollCollection);
    }

    public Collection GetInstance() => _instance;

    public int GetScore() => _scrollCollection;
}
