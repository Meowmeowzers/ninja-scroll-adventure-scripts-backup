using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Stats statsToObserve;
    [SerializeField] TextMeshProUGUI healthText;

    private void OnHealthChanged(float newHealth)
    {
        healthText.text = $"Health: {newHealth}";
    }

    private void Awake()
    {
        if (statsToObserve != null)
        {
            statsToObserve.HealthChanged += OnHealthChanged;
        }
    }

	void Start()
	{
		healthText.text = $"Health: {statsToObserve.GetHealth()}";
	}

	private void OnDestroy()
    {
        if (statsToObserve != null)
        {
            statsToObserve.HealthChanged -= OnHealthChanged;
        }
    }
}
