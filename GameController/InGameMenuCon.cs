using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuCon : MonoBehaviour {

    public GameObject title,pauseMenu,gameOverMenu;

	public void PauseMenu(bool onOff)
    {
        title.SetActive(onOff);
        pauseMenu.SetActive(onOff);
    }

    public void GameOverMenu(bool onOff)
    {
        title.SetActive(onOff);
        gameOverMenu.SetActive(onOff);
    }
}
