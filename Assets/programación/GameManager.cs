using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

    
{
    bool gamePaused = false;
    bool gameOver = false;
    [SerializeField] Player1 player;
    [SerializeField] GameObject canvas;
    [SerializeField] int numEnemigos;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
            PauseGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    void PauseGame()
    {
        gamePaused = gamePaused ? false : true;
        player.gamePaused = gamePaused;
        canvas.SetActive(gamePaused ? true : false);
        Time.timeScale = gamePaused ? 0 : 1 ;
    }
    public void ReducirNumeroEnemigos()
    {
        numEnemigos = numEnemigos - 1;
        if(numEnemigos < 1)
        {
            Ganar();
        }
    }

    void Ganar()
    {
        Time.timeScale = 0;
        player.gamePaused = true;
        gameOver = true;
        Debug.Log("Ganaste");
    }
}
