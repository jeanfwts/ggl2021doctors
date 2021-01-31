using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
    public Vector2 checkPointPos;
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
        if (_player == null || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FinishGame();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        GameObject fin = GameObject.Find("END");
        if (fin != null)
            fin.GetComponent<ContactToNotify>()?.collisionEnterBis?.AddListener(FinishGame);
        else
            Debug.Log("fin introuvable");
        _player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(checkPointPos);
        if (checkPointPos != null && checkPointPos != Vector2.zero)
            _player.transform.position = checkPointPos;
    }

    public void FinishGame()
    {
        Debug.Log("Jeu fini");
        Application.Quit();
    }
}
