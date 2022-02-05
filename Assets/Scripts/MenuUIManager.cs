using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{

    public GameManager gameManagerInst;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerInst = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void StartNew()
    {
        gameManagerInst.saveName();
        Debug.Log("Game  started with name: " + gameManagerInst.playerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor();
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                        Application.Quit(); // original code to quit Unity player
        #endif
    }
}
