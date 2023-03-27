using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject _amap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.M))
        {
            openMap();
        }*/
    }

    public void openMap()
    {

        if (Time.timeScale > 0)
        {
            PauseGame();
            _amap.SetActive(!_amap.activeSelf);  
        }
        else if (Time.timeScale == 0)
        {
            _amap.SetActive(!_amap.activeSelf);
            ResumeGame();
        }
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
