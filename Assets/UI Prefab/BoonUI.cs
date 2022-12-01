using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoonUI : MonoBehaviour
{
    BoonStats boonStats;
    public Camera MainCamera;
    public TextMeshProUGUI blessing;
    public TextMeshProUGUI curse;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {

        boonStats = GameObject.Find("Player").GetComponent<BoonStats>();
       // panel = GameObject.Find("Blessing_CurseCanvas").gameObject;
      //  panel.SetActive(false);
        blessing.text = "" + boonStats.blessingText;
        curse.text = "" + boonStats.curseText;
    }

    // Update is called once per frame
    void Update()
    {
        blessing.text = "" + boonStats.blessingText;
        curse.text = "" + boonStats.curseText;
    }
    public void toggleOff()
    {
     //   panel.SetActive(false);
        MainCamera.GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
