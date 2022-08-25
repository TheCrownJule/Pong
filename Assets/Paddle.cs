using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;

    string input;
    bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        
        
    }

    public void Init(bool isRightPaddle)
    {
        Vector2 pos = Vector2.zero;

        isRight = isRightPaddle;

        if (isRightPaddle)
        {
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }
        else
        {
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }

        //Update paddle position
        transform.position = pos;
        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input)*Time.deltaTime*speed;
        transform.Translate(move * Vector2.up);
        //Keep in bounds
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move<0)
        {
            move = 0;
        }

        if (transform.position.y > GameManager.topRight.y - height / 2 && move < 0)
        {
            move = 0;
        }
    }
}
