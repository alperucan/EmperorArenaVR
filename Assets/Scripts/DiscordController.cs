using UnityEngine;


    public class DiscordController : MonoBehaviour
    {
        
    public long applicationID;
    [Space]
    public string details = "Walking around the world";
    public string state = "Current Position: ";
    [Space]
    public string largeImage = "game_logo";
    public string largeText = "Discord Tutorial";

    private Transform pos;
    private long time;

    private static bool instanceExists;
    public Discord.Discord discord;

    void Awake() 
    {
        // Transition the GameObject between scenes, destroy any duplicates
        if (!instanceExists)
        {
            instanceExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Log in with the Application ID
        discord = new Discord.Discord(applicationID, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);

        pos = GameObject.FindWithTag("Player").GetComponent<Transform>();
       // rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();

        UpdateStatus();
    }

    void Update()
    {
        // Destroy the GameObject if Discord isn't running
        try
        {
            discord.RunCallbacks();
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate() 
    {
        UpdateStatus();
    }

    void UpdateStatus()
    {
        // Update Status every frame
        try
        {
            //Debug.LogWarning("dc deneme");
            var activityManager = discord.GetActivityManager();
           // Debug.LogWarning("dc denem2e");
            var activity = new Discord.Activity
            {
                Details = details,
                State = state +pos.position,
                Assets = 
                {
                    LargeImage = largeImage,
                    LargeText = largeText
                },
                Timestamps =
                {
                    Start = time
                }
            };
           // Debug.LogWarning("dc deneme2232323232");
            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res != Discord.Result.Ok) Debug.LogWarning("Failed connecting to Discord!");
            });
           // Debug.LogWarning("dc deneme3");
        }
        catch
        {
            Debug.Log("Faill to connect DC API");
            // If updating the status fails, Destroy the GameObject
            Destroy(gameObject);
        }
    }
}
