using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private Slider _slider;    

    private void Awake() =>
        _slider = GetComponent<Slider>();

    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        _slider.value = health;

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}