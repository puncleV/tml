﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter
{
    int blocksCount;

    public int getCount()
    {
        return blocksCount;
    }

    public void add()
    {
        blocksCount++;
    }

    public void delete ()
    {
        blocksCount--;
    }
}
