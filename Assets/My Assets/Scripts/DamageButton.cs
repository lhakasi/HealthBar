using UnityEngine;

public class DamageButton : MonoBehaviour
{
    private int _damage = 10;

    public int DealDamage(int currnetHealth) =>    
        currnetHealth -= _damage;    
}