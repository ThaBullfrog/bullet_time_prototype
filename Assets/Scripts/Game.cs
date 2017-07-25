using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Transform clones;
    private static Game obj;

    public Transform _player;

    private void Awake()
    {
        obj = this;
        clones = new GameObject("clones").transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public static Transform player { get { return obj._player; } }
}