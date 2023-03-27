using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
      /*  Cursor.visible = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoTo(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void closeGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
