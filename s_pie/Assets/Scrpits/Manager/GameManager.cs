using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField]
    private ChallengeSaveData challengeSaveData;

    private bool isPhotoDone = false;
    private bool gameOver = false;

    private bool mainLoaded = false;
    private bool canGameDoneLoad = true;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject temp = new GameObject("GameManager");
                    instance = temp.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private string jsonString = "";

    private string filePath = "";

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        challengeSaveData = new ChallengeSaveData();
        filePath = string.Concat(Application.persistentDataPath, "/", "Save.txt");
        ChallengeLoad();
        Debug.Log("filePath : " + filePath);
    }
    private void Update()
    {
        if (gameOver || isPhotoDone)
            GameDone();
    }
    public void GameDone()
    {
        if (canGameDoneLoad)
        {
            canGameDoneLoad = false;
            SceneManager.LoadScene("GameDone");
        }
    }
    public void SetCanGameDoneLoad(bool a)
    {
        canGameDoneLoad = a;
    }
    public bool GetMainLoaded()
    {
        return mainLoaded;
    }
    public void SetMainLoaded(bool a)
    {
        mainLoaded = a;
    }
    public void SetGameOver(bool a)
    {
        gameOver = a;
    }
    public bool GetGameOver()
    {
        return gameOver;
    }
    public bool GetIsPhotoDone()
    {
        return isPhotoDone;
    }
    public void SetIsPhotoDone(bool a)
    {
        isPhotoDone = a;
    }
    public ChallengeSaveData GetChallengeSaveData()
    {
        return challengeSaveData;
    }
    public void ChallengeSave()
    {
        jsonString = JsonUtility.ToJson(challengeSaveData);
        FileStream fs = new FileStream(filePath, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        fs.Write(data, 0, data.Length);
        fs.Close();
        Debug.Log("JSON : " + jsonString);
    }
    public void ChallengeLoad()
    {
        try
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();
            jsonString = Encoding.UTF8.GetString(data);
            challengeSaveData = JsonUtility.FromJson<ChallengeSaveData>(jsonString);
        }
        catch(FileNotFoundException)
        {
            ChallengeSave();
        }
    }
}
