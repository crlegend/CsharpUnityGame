using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

    //public GameObject directLight;
    //public GameObject wayPoint1;

    //public GameObject frontPage;

    public Camera mainCam;
    public float gameOverZoom;
    public GeneralSoundCon gSoundCon;
    public AudioClip gameOverMusic;
    //public Transform backGround;
    public GameObject controlGroup;
    public GameObject inGameMenu;
    public CheckPointCon checkCon;
    public bool menuOn = false;

    private float timeScale;
    private Common common = new Common();
    private MoveCon[] moves;
    private Transform[] controllers;
    private bool paused = false;
    private bool menuOpened = false;

    private void Awake()
    {
        //frontPage.SetActive(true);
        common.SwitchCamera(mainCam);
        




    }

    void Start()
    {
        //GameObject keeps = GameObject.FindGameObjectWithTag("Keeps");
        //keeps.GetComponent<LevelManager>().SetLevels();

        


        ResumeGame();
        Time.timeScale = 1f;
    }



    public void StartIntro(bool onOff)
    {
        GetComponent<IntroCon>().enabled = onOff;
    }

    public void ShowPauseMenu(bool onOff)
    {

        inGameMenu.GetComponent<InGameMenuCon>().PauseMenu(onOff);
        menuOpened = onOff;


    }

    public void StartTutorial(bool onOff)
    {
        GetComponent<TutorialCon>().enabled = onOff;
    }

    public void StartLevel1(bool onOff)
    {
        //GetComponent<Level1Con>().enabled = onOff;
    }

    public void DirectLight(bool onOff)
    {
        //directLight.SetActive(onOff);
    }

    public void GameOver()
    {
        Camera.main.GetComponent<MainCamCon>().Zoom(gameOverZoom);
        GameObject backGround = GameObject.FindGameObjectWithTag("Background");

        backGround.GetComponent<BackGroundCon>().FadeSelf(0f,false);

        /* //need wait until automusic stoped!
        gSoundCon.AutoMusic(false);
        gSoundCon.MuteMusic();
        gSoundCon.aSourceNormal.clip = gameOverMusic;
        gSoundCon.aSourceNormal.Play();*/

        inGameMenu.GetComponent<InGameMenuCon>().GameOverMenu(true);

        PauseGame(false);

        //wait until animation (Zoom, Fade) end
        //show gameover thing
        
        //RestartGame();       
        
    }

    public void PauseGame(bool stopTime)
    {      
        if (!paused)
        {
           
            timeScale = Time.timeScale;
            moves = transform.root.GetComponentsInChildren<MoveCon>();
            for (int i = 0; i < moves.Length; i++)
            {
                moves[i].StopMovement(true);
            }

            controllers = controlGroup.GetComponentsInChildren<Transform>();
            for (int j = 0; j < controllers.Length; j++)
            {
                controllers[j].gameObject.SetActive(false);
            }
            //ShowMenu(true);

            paused = true;
            if (stopTime)
            {
                Time.timeScale = 0f;
            }
            
            
        }
        
    }

   

    public void ResumeGame() // need paused first!
    {
        if (paused)
        {
            Time.timeScale = timeScale;
            for (int i = 0; i < moves.Length; i++)
            {
                moves[i].StopMovement(false);
            }
            for (int j = 0; j < controllers.Length; j++)
            {
                controllers[j].gameObject.SetActive(true);
            }
            //ShowMenu(false);
            paused = false;

        }
        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void ReturnToMain()
    {
        GameObject keeps = GameObject.FindGameObjectWithTag("Keeps");
        keeps.GetComponent<KeepCon>().checkNum = 0;
        
        /*for (int i =0; i < keeps.GetComponent<LevelManager>().level.Length; i++)
        {
            keeps.GetComponent<LevelManager>().level[i].onOff = false;
        }
        keeps.GetComponent<LevelManager>().level[0].onOff = true;

        keeps.GetComponent<LevelManager>().resetLevel = true;*/


        ReloadScene();
        
    }

    public void CheckPointStart()
    {
        ReloadScene();
    }

    public void SetUpMenu()
    {
        menuOn = true;
    }

    void Update()
    {
        if (menuOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !menuOpened)
            {
                ShowPauseMenu(true);

                PauseGame(true);
            }
            /*else if (Input.GetKeyDown(KeyCode.Escape) && menuOpened)
            {
                ShowPauseMenu(false);

                ResumeGame();
            }*/
        }
        

    }

   



    

    
    
}
