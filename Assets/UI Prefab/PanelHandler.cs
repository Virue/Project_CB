using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PanelHandler : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    // Start is called before the first frame update
    void Start()
    {
        p1= transform.Find("MainMenuCanvas").gameObject as GameObject;
        p2= transform.Find("PlayerHUD").gameObject as GameObject; 
        p3= transform.Find("End Screen").gameObject as GameObject; 
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void setPanel(int p)
    {
        switch (p)
        {
            case 0:
                p1.SetActive(true);
                p2.SetActive(false);
                p3.SetActive(false);
                break;
            case 1:
                p1.SetActive(false);
                p2.SetActive(true);
                p3.SetActive(false);
                break;
            case 2:
                p1.SetActive(false);
                p2.SetActive(false);
                p3.SetActive(true);
                break;
            default:
                break;
        }
    }
   public IEnumerator EndGame()
   {
         yield return new WaitForSeconds(10.0f);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        setPanel(2);
       
    }
   public void startGame()
   {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        StartCoroutine(EndGame());
   }
}
