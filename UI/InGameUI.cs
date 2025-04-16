using UnityEngine;
using TMPro;
using System;

public class InGameUI : MonoBehaviour
{
    [SerializeField] Stats _statsToObserve;
    [SerializeField] Collection _collectionToObserve;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _scrollText;

	void Awake()
	{
		_collectionToObserve = FindObjectOfType<Collection>();
	}
	void OnEnable()
    {
        if (_statsToObserve != null){
            _statsToObserve.OnHealthChanged += UpdateHealthUI;
        }
        if(_collectionToObserve != null){
            _collectionToObserve.OnScrollUpdate += UpdateScrollUI;
        }
    }

	void Start()
	{
        if(_statsToObserve != null)
		    _healthText.text = $"Health: {_statsToObserve.GetHealth()}";
	}

    void UpdateHealthUI(float newValue)
    {
        if(_statsToObserve != null)
            _healthText.text = $"Health: {newValue}";
    }

    void UpdateScrollUI(int newValue)
    {
        if(_collectionToObserve != null)
        _scrollText.text = $"Scrolls: {newValue} / 20";
    }

	void OnDisable()
    {
        if (_statsToObserve != null){
            _statsToObserve.OnHealthChanged -= UpdateHealthUI;
        }
        if(_collectionToObserve != null){
            _collectionToObserve.OnScrollUpdate -= UpdateScrollUI;
        }
    }
}
