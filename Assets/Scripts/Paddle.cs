using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] int units;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    // Start is called before the first frame update

    GameState gameState;
    Ball ball;

    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        this.move();
    }

    private void move()
    {
        Vector2 newPosition = new Vector2(Mathf.Clamp(getXPos(), minX, maxX), transform.position.y);
        transform.position = newPosition;
    }

    private float getXPos()
    {
        bool autoplayOn = gameState.isAutoPlay();
        if(autoplayOn)
        {
            return ball.transform.position.x;
        } else
        {
            return Input.mousePosition.x / Screen.width * units;
        }
    }
}
