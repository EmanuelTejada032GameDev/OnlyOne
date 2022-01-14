using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movementVector;
    [SerializeField] private float speed;

    private void Update()
    {
        MovementHandler();
    }

    private void MovementHandler()
    {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position += movementVector.normalized * speed * Time.deltaTime;
    }
}
