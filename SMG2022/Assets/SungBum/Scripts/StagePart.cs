using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StagePart
{
    public int Stage;

    public GameObject StageType;

    public List<RawImage> Part;

    public List<Texture> RocketPart; 
}
