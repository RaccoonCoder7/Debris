using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : SingletonMono<GameMgr>
{
    public Vector3 PlayerPos;

    public int Stage = 0;

    public int EventNumber = 0;
}
