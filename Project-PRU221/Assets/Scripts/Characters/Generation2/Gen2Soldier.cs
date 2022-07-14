using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen2Soldier : Soldier
{
    public override Generation GetGeneration()
    {
        return Generation.Gen2;
    }
}
