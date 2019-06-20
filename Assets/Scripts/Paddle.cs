using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] int units;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.move();
    }

    private void move()
    {
        float newX = getXPos();
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y);
        newPosition.x = Mathf.Clamp(newX, minX, maxX);
        transform.position = newPosition;
    }

    private float getXPos()
    {
        bool autoplayOn = FindObjectOfType<GameState>().isAutoPlay();
        Debug.Log(autoplayOn);
        if(autoplayOn)
        {
            Debug.Log(FindObjectOfType<Ball>().transform.position.x);

            return FindObjectOfType<Ball>().transform.position.x;
        } else
        {
            return Input.mousePosition.x / Screen.width * units;
        }
    }
}
