using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private float _delay;
    [SerializeField] private float _interpolationValue;    

    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake() =>
        _slider = GetComponent<Slider>();

    private void OnEnable()
    {
        _player.MaxHealthEstablished += SetMaxHealth;
        _player.HealthChanged += SetHealth;
    }

    private void OnDisable()
    {
        _player.MaxHealthEstablished -= SetMaxHealth;
        _player.HealthChanged -= SetHealth;
    }

    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeHealth(health));
    }

    private IEnumerator ChangeHealth(int health)
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _interpolationValue);

            _fill.color = _gradient.Evaluate(_slider.normalizedValue);

            yield return delay;
        }
    }
}