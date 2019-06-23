using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    //How many scenes in build sequence before the first level
    public int SceneNumOffSet = 2;
    public Button[] buttons;

 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load (int id)
    {
        SceneManager.LoadScene(id + SceneNumOffSet - 1);
    }

    public void BackToMenu ()
    {
        Debug.Log("Back 2 menu");
        SceneManager.LoadScene(0);
    }
}
