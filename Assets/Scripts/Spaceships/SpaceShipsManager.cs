using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShipsManager : MonoBehaviour
{
    #region Variables
    /// <summary>
    ///  KC = KillCount
    /// </summary>
    public Text timer, timerFinal, kC, kCF, bossKC, bossKCF;
    public GameObject panel;
    public MOTHER mothership;
    public Transform motherSpawnPoint;
    public Spawner spawner;
    float time;
    public int kills = 0, killsToBoss = 25, deathBoss = 0;
    public bool isPlaying, bossIsActive;
    #endregion

    private void Start()
    {
        panel.gameObject.SetActive(false);
        time = 0;
        isPlaying = true;
        kC.text = kills.ToString();
        bossKC.text = deathBoss.ToString();
    }
    private void Update()
    {
        SpawnBoss();
        Playing();
        if (Input.GetKeyDown(KeyCode.Escape)) { ReturnToMenu("MainMenu"); }
    }

    void SpawnBoss()
    {
        if (kills % killsToBoss == 0 && kills > 0 && !bossIsActive)
        {
            spawner.gameObject.SetActive(false);
            Instantiate(mothership, motherSpawnPoint);
            bossIsActive = !bossIsActive;
        }
    }

    public void SpawnerActivate()
    {
        spawner.gameObject.SetActive(true);
        StartCoroutine(spawner.Spawntimer());
    }

    void Playing()
    {
        if (isPlaying == true)
        {
            time = time + Time.deltaTime;
            DisplayTime(time);
            kC.text = kills.ToString();
            bossKC.text = deathBoss.ToString();
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void EndGame()
    {
        isPlaying = false;
        panel.gameObject.SetActive(true);
        timerFinal.text = timer.text;
        kCF.text = kC.text;
        bossKCF.text = bossKC.text;
    }
    public void ReturnToMenu(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    public void LoadLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salio del juego");
    }
}
