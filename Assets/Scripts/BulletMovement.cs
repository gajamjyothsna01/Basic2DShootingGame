using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;
    int score;
    SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
     {
        spawnManager = GameObject.Find("Player").GetComponent<SpawnManager>();
     } 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, bulletSpeed, 0);
        //Pushing a Bullet back into the Pool, Once it reaches Out of the Game Window.
        if(transform.position.y > 4.79 )
        {
            spawnManager.BackToPool(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            Destroy(collision.gameObject);
            spawnManager.BackToPool(gameObject);
            gameObject.SetActive(false);
            GameObject.Find("Player").SendMessage("Score");
        }
        
        /*score = score++;
        print("The score is" + score);
        Destroy(collision.gameObject);
        if (score==10)
        {
            print("You have won the Game");
        } */
    }
}
