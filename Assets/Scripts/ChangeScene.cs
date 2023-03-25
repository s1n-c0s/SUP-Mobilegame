using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject UI_Replay;
    public bool moveCursor;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
           
            if (moveCursor == true)
            {
                unlockCursor();
            }
        }
    }

    public void GoTo(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ResumeGame()
    {
        if (Time.timeScale == 0)//????????
        {
            Cursor.visible = true;
            UI_Replay.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Time.timeScale > 0)//????????
        {
            Cursor.visible = false;
            UI_Replay.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void unlockCursor()
    {
        if (Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Time.timeScale > 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
