using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int score;
    public Text GemText;
    
    public void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GemText.text = "Gems Collected : " + score;
        if(score >= 5) 
        {
            GoToWin();
        }
    }


    public void GoToLose()
    {
        SceneManager.LoadScene("GameLose");
    }
    public void GoToWin()
    {
        SceneManager.LoadScene("GameWin");
    }
}

