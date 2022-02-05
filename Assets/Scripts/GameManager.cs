using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public InputField playerNameField;
    public Text scoreTextOne;
    public Text highScoreDisplay;
    public string playerName = "";
    public string winnerName;
    public int highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScoreDisplay.text = "High Score: " + LoadHighScore().winnerName;
    }

    

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //LoadColor();
    }

    [System.Serializable]
    public class SaveData
    {
        public string winnerName;
        public int highScore;
    }

    public void saveName() {
        playerName = playerNameField.text; 
    }

    public void SaveHighScore(int newScore)
    {
        SaveData data = new SaveData();
        data.winnerName = playerName;
        data.highScore = newScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public SaveData LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            winnerName = data.winnerName;
            highScore = data.highScore;
            return data;
        }
        Debug.Log("returning NO data");
        return null;
        
    }

}
