using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public Room3 room3;
    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject pausePanel;
    public Level1Boss boss;
    public bool isPause;
    public GameObject clearTxt, bosskillTxt;
    private void Awake()
    {
        instance = this;
        isPause = false;
    }
    private void LateUpdate()
    {
        if (player.isLive == false)
        {
            Lose();
        }
    }

    public void Lose()
    {
        losePanel.SetActive(true);
    }
    public void Win()
    {
        winPanel.SetActive(true);
    }
    public void BackToMenu()
    {

        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    public void ClearPopup()
    {
        clearTxt.SetActive(true);
        clearTxt.transform.DOMoveY(clearTxt.transform.position.y + 30f, 0.3f)
            .OnComplete(() =>
            {
                DOVirtual.DelayedCall(1.5f, () =>
                {
                    clearTxt.SetActive(false);
                    clearTxt.transform.DOMoveY(clearTxt.transform.position.y - 30f, 0);
                });
            });
    }    
    public void BossKillPopup()
    {
        bosskillTxt.SetActive(true);
        bosskillTxt.transform.DOMoveY(bosskillTxt.transform.position.y + 100f, 0.3f)
            .OnComplete(() => {
                DOVirtual.DelayedCall(1.5f, () =>
                {
                    bosskillTxt.SetActive(false);
                    bosskillTxt.transform.DOMoveY(bosskillTxt.transform.position.y - 30f, 0);
                });
            });
    }
}
