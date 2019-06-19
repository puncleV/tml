using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] AudioClip destroySound;
    [SerializeField] int points = 10;
    [SerializeField] GameObject blockSparklesVfx;


    Level level;

    public int getPoints ()
    {
        return this.points;
    }

    private void Start()
    {
        cacheReferences();
        countBreakableBlock();
    }

    private void countBreakableBlock()
    {
        if (tag == "Breakable")
        {
            level.blockInitialized();
        }
    }

    private void cacheReferences()
    {
        level = FindObjectOfType<Level>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        decreaseBreakableHp();
    }

    private void decreaseBreakableHp ()
    {
        if (--health == 0 && tag == "Breakable")
        {
            destroy();
        }
    }

    private void destroy()
    {
        AudioSource.PlayClipAtPoint(destroySound, transform.position);
        triggerSparkles();
        level.onBlockDestroied(this);
        Destroy(gameObject);
    }

    private void triggerSparkles()
    {
        GameObject sparkles = Object.Instantiate(blockSparklesVfx, transform.position, transform.rotation);
        Destroy(sparkles, 0.2f);
    }
}
