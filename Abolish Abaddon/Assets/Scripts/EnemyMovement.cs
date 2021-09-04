using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    public static float health = 1;
    public GameObject deathEffect;
    public GameObject bloodStain;
    


    float waitSeconds = 0.5f;

    
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.CompareTag("turn")) {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else {
                MoveRight = true;
            }
        }

        if (trig.gameObject.CompareTag("WandCollider"))
        {
            health -= 1;
            if (health <= 0)
            {
                PlayerSoundManger.PlayerSound("enemyDeath");
                Instantiate(bloodStain, transform.position, Quaternion.identity);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }



    }

    

    IEnumerator WaitForHalfASecond()
    {
        yield return new WaitForSeconds(waitSeconds);
        
    }
}
