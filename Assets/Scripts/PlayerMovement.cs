using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        MovementOfPlayer(KeyCode.RightArrow, playerSpeed);
        MovementOfPlayer(KeyCode.LeftArrow, playerSpeed);
        MovementOfPlayer(KeyCode.UpArrow, playerSpeed);
        MovementOfPlayer(KeyCode.DownArrow, playerSpeed);*/
        MovementOfPlayer(playerSpeed);

    }
    private void MovementOfPlayer(float speedOfPlayer)
    {

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -11.0f)
            transform.Translate(-speedOfPlayer, 0, 0);
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 11.0f)
            transform.Translate(speedOfPlayer, 0, 0);
        else if(Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 13.0f)
            transform.Translate(0, speedOfPlayer, 0);
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -13.0f)
            transform.Translate(0, -speedOfPlayer, 0);
    }
    public void Score()
    {
        score = score + 10;
        if(score > 100)
        {
            Debug.Log("You Won GAME");
        }
    }
    
}
