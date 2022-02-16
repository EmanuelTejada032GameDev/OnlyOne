using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{

    [SerializeField] Transform[] borderCheckers;
    private bool _borderTriggeredPlayer;
    private bool _borderTriggeredEnemy;

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (_borderTriggeredPlayer)
            {
                return;
            }
            SetFallingPositionAxis(collision);
            collision.gameObject.GetComponent<Animator>().SetBool("Falling", true);
            collision.gameObject.GetComponent<Player>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            _borderTriggeredPlayer = true;
        }

        if (collision.CompareTag("Enemy"))
        {
            
            SetFallingPositionAxisForEnemy(collision);
            collision.gameObject.GetComponent<Animator>().SetBool("Falling", true);
            collision.gameObject.GetComponent<Enemy>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

    }

    private void SetFallingPositionAxis(Collider2D objectColliding)
    {
        if (objectColliding.transform.position.x > 0)
        {
            //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingXPosition", 1);
            if (objectColliding.transform.position.y > 0)
            {
                Debug.Log("Falling top right");
                objectColliding.GetComponent<Animator>().Play("Player_Falling");
                //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingYPosition", 1);
            }
            else
            {
                Debug.Log("Falling bottom right");
                objectColliding.GetComponent<Animator>().Play("Player_Falling");
                //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingYPosition", -1);
            }
        }
        else
        {
            //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingXPosition", -1);
            if (objectColliding.transform.position.y > 0)
            {
                Debug.Log("Falling top left");
                objectColliding.GetComponent<Animator>().Play("Player_Falling");
                //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingYPosition", 1);
            }
            else
            {
                Debug.Log("Falling bottom left");
                objectColliding.GetComponent<Animator>().Play("Player_Falling");
                //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingYPosition", -1);
            }
        }
    }

    private void SetFallingPositionAxisForEnemy(Collider2D objectColliding)
    {
        if (objectColliding.transform.position.x > 0)
        {
            //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingXPosition", 1);
            if (objectColliding.transform.position.y > 0)
            {
                Debug.Log("Falling top right");
                objectColliding.GetComponent<Animator>().Play("Enemy_Falling");
                //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingYPosition", 1);
            }
            else
            {
                Debug.Log("Falling bottom right");
                objectColliding.GetComponent<Animator>().Play("Enemy_Falling");
                //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingYPosition", -1);
            }
        }
        else
        {
            //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingXPosition", -1);
            if (objectColliding.transform.position.y > 0)
            {
                Debug.Log("Falling top left");
                objectColliding.GetComponent<Animator>().Play("Enemy_Falling");
                //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingYPosition", 1);
            }
            else
            {
                Debug.Log("Falling bottom left");
                objectColliding.GetComponent<Animator>().Play("Enemy_Falling");
                //objectColliding.gameObject.GetComponent<Animator>().SetFloat("FallingYPosition", -1);
            }
        }
    }


}
