using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    PanelHandler panelHandler;
    Cameralock cameralock;
    AnimationBehavior animationBehavior;
    PlayerStats playerStats;

    public bool beenUsed = false;
    public GameObject playerHUD;
    public GameObject scoreScreen;
    public GameObject pressEUI;

    // Start is called before the first frame update
    void Start()
    {
       // playerStats= new PlayerStats();
        playerHUD = transform.Find("PlayerHUD").gameObject as GameObject;
        scoreScreen = transform.Find("End Screen").gameObject as GameObject;
        pressEUI = transform.Find("Press E").gameObject as GameObject;
        playerHUD.SetActive(false);
        scoreScreen.SetActive(false);
        pressEUI.SetActive(false);
        Debug.Log("start");
        Debug.Log("The scene name for the first scene is " + SceneManager.GetSceneAt(0).name);
        SceneManager.sceneLoaded += SceneChanger;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
    public void switchScenes()
    {
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
        yield return new WaitForSeconds(60.0f);
        endScene();
    }
    public void endScene()
    {
        cameralock.MainCamera.GetComponent<Camera>();
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible = true;
        playerHUD.SetActive(false);
        scoreScreen.SetActive(true);
    }
    public void returnToMainMenu()
    {
        Debug.Log("Loading game scene");
        SceneManager.LoadScene(0, LoadSceneMode.Single);//Or whatever index you want.
        Debug.Log("Loaded game scene");
    }
    // player collides with sphere Collider for Boon
    //use the press e UI to pop up
    public void toggleEUI()
    {
      pressEUI.SetActive(true);
   
    }
    /*
 public void OnTriggerStay(Collider other)
{
    Debug.Log("Player Collided with Boon Scene Saw it");
    Vector3 CollisonPoint = other.ClosestPoint(animationBehavior.myRig.position);
    if ((other.gameObject.tag == "Boon") && (CollisonPoint - animationBehavior.myRig.position).normalized.y < .8)
    {
            pressEUI.SetActive(true);
    }
}
 */

}
