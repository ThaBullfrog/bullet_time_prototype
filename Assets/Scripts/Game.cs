using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Transform clones;
    //private static Game obj;

    private void Awake()
    {
        //obj = this;
        clones = new GameObject("clones").transform;
    }
}