using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeStop : MonoBehaviour
{
    private bool isPaused = false;

    public void SceneChange()
    {
        SceneManager.LoadScene(0);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // 게임 정지
        }
        else
        {
            Time.timeScale = 1f; // 게임 재개
        }
    }
}
