using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : SingletonMono<GameMgr>
{
    public Vector3 PlayerPos;
    public Vector3 BasicPlayerPos;

    public Vector3 CameraPos;
    public Vector3 BasicCameraPos;

    public int Stage = 1;

    public int EventNumber = 0;

    public List<bool> clearedEvent = new List<bool>(new bool[]
        {
            false,
            false,
            false,
            false,
            false
        }
    );
}
