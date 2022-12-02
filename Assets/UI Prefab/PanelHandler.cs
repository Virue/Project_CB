using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
//using UnityEditor.SearchService;
using UnityEngine.SocialPlatforms.Impl;

public class PanelHandler : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    // Start is called before the first frame update
    void Start()
    {
        p1= transform.Find("MainMenuCanvas").gameObject as GameObject;
        p2= transform.Find("Directions").gameObject as GameObject;
        p3 = transform.Find("Credits").gameObject as GameObject;
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
            case 3:
                p1.SetActive(false);
                p2.SetActive(false);
                p3.SetActive(false);

                break;
            default:
                break;
        }
    }
      
}
