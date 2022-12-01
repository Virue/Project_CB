using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneController : MonoBehaviour
{
    PanelHandler panelHandler;
    Cameralock cameralock;
    AnimationBehavior animationBehavior;
    PlayerStats playerStats;

    public Timer_Score timer;

    public TextMeshProUGUI score;


    public bool beenUsed = false;
    public bool health = true;
    public GameObject playerHUD;
    public GameObject scoreScreen;
    public GameObject pressEUI;
    public float sceneCounter;

   // List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    // Start is called before the first frame update
    void Start()
    {
        sceneCounter = 0;
        // playerStats= new PlayerStats();
        playerHUD = transform.Find("PlayerHUD").gameObject as GameObject;
        scoreScreen = transform.Find("End Screen").gameObject as GameObject;
        pressEUI = transform.Find("Blessing_CurseCanvas").gameObject as GameObject;
        playerHUD.SetActive(false);
        scoreScreen.SetActive(false);
        pressEUI.SetActive(false);
        Debug.Log("start");
        Debug.Log("The scene name for the first scene is " + SceneManager.GetSceneAt(0).name);
       // scenesToLoad.Add();
     //  scenesToLoad.Add();
      //  scenesToLoad.Add();
//scenesToLoad.Add();
        SceneManager.sceneLoaded += SceneChanger;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerDied() 
    {
        health = false;
    }
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        panelHandler = GameObject.Find("PanelHandler").GetComponent<PanelHandler>();
        cameralock = GameObject.Find("MainCamera").GetComponent<Cameralock>();
        animationBehavior = GetComponent<AnimationBehavior>();
        
    }
    public void SceneChanger(Scene s, LoadSceneMode m)
    {
        Debug.Log("Called SceneChanger.");
        Debug.Log("The scene name is " + s.name);
        Debug.Log("The scene name for the first scene is " + SceneManager.GetSceneByBuildIndex(0).name);
        if (beenUsed)
        {
            SceneManager.sceneLoaded -= SceneChanger;
            Destroy(this.gameObject);
        }

        if (s.name != SceneManager.GetSceneByBuildIndex(0).name)
        {
            Debug.Log("Setting beenUsed to true!");
            beenUsed = true;
        }
        if (s.name != SceneManager.GetSceneByBuildIndex(2).name)
        {
            Debug.Log("Setting beenUsed to False!");
            beenUsed = false;
        }
        if (s.name != SceneManager.GetSceneByBuildIndex(3).name)
        {
            Debug.Log("Setting beenUsed to False!");
            beenUsed = false;
        }
        if (s.name != SceneManager.GetSceneByBuildIndex(4).name)
        {
            Debug.Log("Setting beenUsed to False!");
            beenUsed = false;
        }

    }
    public void switchScenes()
    {
        if (sceneCounter == 3 && !beenUsed)
        {
            Debug.Log("Loading game scene");
            SceneManager.LoadScene(4, LoadSceneMode.Additive);//Or whatever index you want.
            playerHUD.SetActive(true);
            SceneManager.UnloadSceneAsync("CastleHallways");
        }
        else if (sceneCounter == 2 && !beenUsed)
        {
            Debug.Log("Loading game scene");
            SceneManager.LoadScene(3, LoadSceneMode.Additive);//Or whatever index you want.
            playerHUD.SetActive(true);
            SceneManager.UnloadSceneAsync("Village");
        }
        else if (sceneCounter == 1 && !beenUsed)
        {

            Debug.Log("Loading game scene");
            SceneManager.LoadScene(2, LoadSceneMode.Additive);//Or whatever index you want.
            playerHUD.SetActive(true);
            SceneManager.UnloadSceneAsync("SewerMap");
        }else 
        if (!beenUsed)
        {
            
            Debug.Log("Loading game scene");
            SceneManager.LoadScene(1, LoadSceneMode.Additive);//Or whatever index you want.
            playerHUD.SetActive(true);
            Debug.Log("Loaded game scene");
            StartCoroutine(EndGame());
        }
        else
        {
            Debug.Log("Loading Menu scene");
            SceneManager.LoadScene(0);
        }
        
    }
    public IEnumerator EndGame()
    {
        yield return new WaitWhile(()=>health);
        endScene();
    }
    public void BoonUIActivate()
    {
        pressEUI.SetActive(true);
    }
    public void BoonUIDeActivate()
    {
        pressEUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void endScene()
    {
        cameralock.MainCamera.GetComponent<Camera>();
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible = true;
        playerHUD.SetActive(false);
        pressEUI.SetActive(false);
        scoreScreen.SetActive(true);
        score.text = "Score: " + timer.score+"\n";

        score.text += "Time: ";
        float t = Time.timeSinceLevelLoad; //scene loaded

        int seconds = (int)(t % 60);// return remainder of seconds/60 as an it
        t /= 60; //minutes
        int minutes = (int)(t % 60);//remainder of minutes
        t /= 60;//hours
        int hours = (int)(t % 60);//remainder of hours
        score.text += string.Format("{0}:{1}:{2}",
           hours.ToString("00"), minutes.ToString("00"), seconds.ToString("00"));
        
    }
    public void returnToMainMenu()
    {
        Debug.Log("Loading game scene");
        SceneManager.LoadScene(0, LoadSceneMode.Single);//Or whatever index you want.
        Debug.Log("Loaded game scene");
    }
   
   
   

}
