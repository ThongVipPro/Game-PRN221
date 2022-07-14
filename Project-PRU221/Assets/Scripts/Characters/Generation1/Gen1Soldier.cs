using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1Soldier : Soldier
{
    public override Generation GetGeneration()
    {
        return Generation.Gen1;
    }
}
