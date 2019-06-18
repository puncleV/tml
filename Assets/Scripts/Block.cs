using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] AudioClip destroySound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(--health == 0)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
            Destroy(gameObject);
        }
    }
}
