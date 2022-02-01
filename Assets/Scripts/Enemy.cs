using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 1;



    public void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
        if(_health <= 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
