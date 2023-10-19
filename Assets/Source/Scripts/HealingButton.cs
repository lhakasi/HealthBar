using UnityEngine;

public class HealingButton : MonoBehaviour
{
    private Player _player;
    
    private int _healing = 10;

    public void HealPlayer() =>    
        _player.TakeHealing(_healing);    
}