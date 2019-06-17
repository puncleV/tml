using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int health = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(--health == 0)
        {
            Destroy(gameObject);
        }
    }
}
