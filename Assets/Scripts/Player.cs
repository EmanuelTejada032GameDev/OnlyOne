using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movementVector;
    [SerializeField] private float speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _damageAmount;

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    public LayerMask enemyLayers;

    [SerializeField] private float _attackRate = 2f;
    private float _nextAttackTime = 0f;

    private void Update()
    {
        MovementHandler();
    }

    private void FixedUpdate()
    {
        transform.position += movementVector.normalized * speed * Time.fixedDeltaTime;
    }
    private void MovementHandler()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat( "Horizontal",movementVector.x);
        _animator.SetFloat( "Vertical", movementVector.y);
        _animator.SetFloat("Speed", movementVector.sqrMagnitude);

        if(movementVector.x != 0 || movementVector.y != 0)
        {
            _animator.SetFloat("LastHorizontal", movementVector.x);
            _animator.SetFloat("LastVertical", movementVector.y);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) )
        {
           if(Time.time >= _nextAttackTime)
            {
                Attack();
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");

        Collider2D[] objectsReached = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, enemyLayers);


        foreach (Collider2D objectReached in objectsReached)
        {
            objectReached.gameObject.GetComponent<Enemy>().TakeDamage(_damageAmount);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
