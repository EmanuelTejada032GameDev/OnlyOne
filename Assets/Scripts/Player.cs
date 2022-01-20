using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movementVector;
    [SerializeField] private float speed;
    [SerializeField] private Animator _animator;

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
    }


}
