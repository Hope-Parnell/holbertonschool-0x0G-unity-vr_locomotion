using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private GameObject[] enemies;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        pauseMenu.SetActive(false);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            WinGame();
    }
    public void Pause(){
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GameOver(){
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
        Debug.Log("Game Over!");
    }
    public void Restart(){
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame(){
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    void WinGame(){
        StartCoroutine("Win");
    }
    IEnumerator Win(){
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        winMenu.SetActive(true);
        Debug.Log("You Win!");
    }
}
