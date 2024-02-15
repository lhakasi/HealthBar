using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class RawHealthBar : HealthBar
{    
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake() =>
        _slider = GetComponent<Slider>();    

    protected override void OnMaxHealthEstablished(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        _fill.color = _gradient.Evaluate(1f);
    }

    protected override void OnHealthChanged(int health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeHealth(health));
    }

    private IEnumerator ChangeHealth(int health)
    {
        while (_slider.value != health)
        {
            _slider.value = health;

            _fill.color = _gradient.Evaluate(_slider.normalizedValue);

            yield return null;
        }
    }
}
