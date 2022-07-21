using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlatformerManager : MonoBehaviour
{
    public bool UiOn = true;
    public Text text;
    public GameObject panelLose;
    public GameObject panelWin;
    public Player player;
    float time;
    bool isPlaying;

    private void Start()
    {
        time = 0;
        isPlaying = true;
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (isPlaying == true && UiOn)
        {
            time += Time.deltaTime;
            DisplayUI(time);
        }
    }
   
    void DisplayUI(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    /*
    public void WinGame()
    {
        isPlaying = false;
        panelWin.gameObject.SetActive(true);
        Destroy(player);
    }
    */
    public void LoseGame()
    {
        isPlaying = false;
        panelLose.gameObject.SetActive(true);
        Destroy(player.gameObject);
    }
    public void WinGame()
    {
        LoadScene("SpaceshipScene");
    }

    public void LoadScene(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salio del juego");
    }

    private void OnEnable()
    {
        Player.PlayerDie += LoseGame;
        Door.PlayerWin += WinGame;
    }

    private void OnDisable()
    {
        Player.PlayerDie -= LoseGame;
        Door.PlayerWin -= WinGame;

    }
}
