using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RawHealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake() =>
        _slider = GetComponent<Slider>();

    private void OnEnable()
    {
        _player.MaxHealthEstablished += OnMaxHealthEstablished;
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.MaxHealthEstablished -= OnMaxHealthEstablished;
        _player.HealthChanged -= OnHealthChanged;
    }

    public void OnMaxHealthEstablished(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        _fill.color = _gradient.Evaluate(1f);
    }

    public void OnHealthChanged(int health)
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
