using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
public class GooglePlayGamesSeriviesLoginScripts : MonoBehaviour
{
    public static PlayGamesPlatform GooglePlayGamesInstance;
    static GooglePlayGamesSeriviesLoginScripts Instance;
    public static GooglePlayGamesSeriviesLoginScripts _Instance
    {
        get
        {
            return Instance;
        }
        set
        {
            Instance = value;
        }
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(this) ;
        bool NullInstance = (Instance == null);
        if (NullInstance)
        {
            _Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        if (GooglePlayGamesInstance == null)
        {
            PlayGamesClientConfiguration configVariable = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(configVariable);
            PlayGamesPlatform.DebugLogEnabled = true;
        }
        Social.localUser.Authenticate(sucess =>
        {
            if (sucess) { print("Loged in")}else { print("Failed to singin or signup")};
        });

    }
    
    void Update()
    {
        
    }
}
