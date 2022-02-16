using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : Enemy
{
    public float stopDistance;
    public float attackSpeed;

    [SerializeField] private Animator _animator;

    private float attackTime;
    private void Update()
    {
        ChasePlayer();
    }
    private void ChasePlayer()
    {
        if (_player != null)
        {
            Vector2 movementVector = _player.position - transform.position;
            if (Vector2.Distance(transform.position, _player.position) > _stopDistance)
            {
                transform.position += (Vector3)movementVector.normalized * _speed * Time.deltaTime;
                _animator.SetFloat("Horizontal", movementVector.x);
                _animator.SetFloat("Vertical", movementVector.y);
                _animator.SetFloat("Speed", movementVector.sqrMagnitude);
                if (movementVector.x != 0 || movementVector.y != 0)
                {
                    _animator.SetFloat("LastHorizontal", movementVector.x);
                    _animator.SetFloat("LastVertical", movementVector.y);
                }
            }
            else
            {

                _animator.SetFloat("Horizontal", 0f);
                _animator.SetFloat("Vertical", 0f);
                _animator.SetFloat("Speed", 0f);

            }
        }

    }
}
