using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : SingletonMono<GameMgr>
{
    public Vector3 PlayerPos;

    public int Stage = 1;

    public int EventNumber = 0;

    public List<bool> PartCheck;
}
