using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
    public Transform checkPoint;
    public static GameLevelManager INSTANCE;

    GameObject _player;
    GameObject currentNiveau;

    void Start()
    {
        if(INSTANCE != null)
        {
            Destroy(gameObject);
        }
        else
        {
            INSTANCE = this;
        }
        DontDestroyOnLoad(gameObject);
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (_player == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
