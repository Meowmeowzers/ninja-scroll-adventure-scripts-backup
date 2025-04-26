using System;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public static Collection instance;

    [SerializeField] int _scrollCollection = 0;
    
    public event Action<int> OnScrollUpdate;

    private void Awake()
    {
        instance = this;
    }

	public void IncreaseCollection(){
        _scrollCollection++;
        OnScrollUpdate?.Invoke(_scrollCollection);
    }

    public void ResetCollection(){
        _scrollCollection = 0;
        OnScrollUpdate = null;
    }

    public Collection GetInstance() => instance;

    public int GetScore() => _scrollCollection;
}
