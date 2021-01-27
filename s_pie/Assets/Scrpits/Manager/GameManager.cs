using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField]
    private ChallengeSaveData challengeSaveData;

    private string previousScene = "";

    public bool isPhotoDone = false;

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

    }
    private void Awake()
    {
        challengeSaveData = new ChallengeSaveData();
        filePath = string.Concat(Application.persistentDataPath, "/", "Save.txt");
        ChallengeLoad();
        Debug.Log("filePath : " + filePath);
    }
    private void Update()
    {

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
