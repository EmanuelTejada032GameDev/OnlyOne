using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        collision.gameObject.GetComponent<Animator>().SetBool("Falling", true);
    }
}
