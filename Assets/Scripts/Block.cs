using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] AudioClip destroySound;

    BlockCounter blockCounter;
       
    private void Start()
    {
        blockCounter = FindObjectOfType<BlockCounter>();
        blockCounter.add();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(--health == 0)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
            blockCounter.delete();
            Destroy(gameObject);
        }
    }
}
