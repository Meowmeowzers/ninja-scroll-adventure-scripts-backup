using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] Stats _stats;
    [SerializeField] Collection _collection;
    [SerializeField] TextMeshProUGUI _scrollText;
    [SerializeField] Slider _hpSlider;

    public void ReconnectStatsToUI(Stats stats, Collection collection){
        _stats = stats;
        _collection = collection;

        _stats.OnHealthChanged -= UpdateHealthUI;
        _stats.OnHealthChanged += UpdateHealthUI;
        GameManager.instance.collection.OnScrollUpdate += UpdateScrollUI;        

        _hpSlider.value = 1;
        UpdateScrollUI(_collection.GetScore());
    }    

    void UpdateHealthUI(float newValue)
    {
        if(_stats != null)
            _hpSlider.value = newValue;
    }

    void UpdateScrollUI(int newValue)
    {
        if(_collection != null)
            _scrollText.text = $"{newValue} / 20";
    }

	void OnDisable()
    {
        if (_stats != null){
            _stats.OnHealthChanged -= UpdateHealthUI;
        }
        if(_collection != null){
            GameManager.instance.collection.OnScrollUpdate -= UpdateScrollUI;
        }
    }
    void OnDestroy()
    {
        if (_stats != null){
            _stats.OnHealthChanged -= UpdateHealthUI;
        }
        if(_collection != null){
            GameManager.instance.collection.OnScrollUpdate -= UpdateScrollUI;
        }
    }
}
