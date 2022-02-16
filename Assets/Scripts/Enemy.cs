using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public int _health = 1;
    public float _speed = 1;
    public Transform _player;
    public float _stopDistance = 2f;

    public float timeBetweenAttacks;


    public virtual void Start() 
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            _player = FindObjectOfType<Player>().transform;
        }

    }

    private void Update()
    {
        
    }


    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Enemy taking damage " + damageAmount);
        _health -= damageAmount;
        if(_health <= 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    

}
