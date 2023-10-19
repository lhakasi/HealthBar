using UnityEngine;

public class HealingButton : MonoBehaviour
{
    private int _healing = 10;

    public int HealPlayer(int currentHealth) =>    
        currentHealth += _healing;    
}