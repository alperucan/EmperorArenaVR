using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public enum WeatherState { Rain, Snow}
public class DynamicWeatherSystem : MonoBehaviour
{
    private int[] possibleWeatherConditionCodes ={1000, 1003, 1006, 1009, 1030, 1063, 1066, 1069, 1072, 1087, 1114, 1117, 1135, 1147, 1150, 1153, 
        1168, 1171, 1180, 1183, 1186, 1189, 1192, 1195, 1198, 1201, 1204, 1207, 1210, 1213, 1216, 1219, 1222, 1225, 1237, 1240, 1243, 1246, 
        1249, 1252, 1255, 1258, 1261, 1264, 1273, 1276, 1279, 1282};

    private string[] ApiPossebleResbonse = {"Sunny", "Partly cloudy", "Cloudy", "Overcast", "Mist", "Patchy rain possible", 
        "Patchy snow possible", "Patchy sleet possible", "Patchy freezing drizzle possible", "Thundery outbreaks possible", "Blowing snow",
        "Blizzard", "Fog", "Freezing fog", "Patchy light drizzle", "Light drizzle", "Freezing drizzle", "Heavy freezing drizzle", "Patchy light rain",
        "Light rain", "Moderate rain at times", "Moderate rain", "Heavy rain at times", "Heavy rain", "Light freezing rain", "Moderate or heavy freezing rain",
        "Light sleet", "Moderate or heavy sleet", "Patchy light snow", "Light snow", "Patchy moderate snow", "Moderate snow", "Patchy heavy snow",
        "Heavy snow", "Ice pellets", "Light rain shower", "Moderate or heavy rain shower", "Torrential rain shower", "Light sleet showers",
        "Moderate or heavy sleet showers", "Light snow showers", "Moderate or heavy snow showers", "Light showers of ice pellets", 
        "Moderate or heavy showers of ice pellets", "Patchy light rain with thunder", "Moderate or heavy rain with thunder",
        "Patchy light snow with thunder", "Moderate or heavy snow with thunder"
    };
    private string[] ApiPossebleResbonseMached = {"Sunny", "Rain", "Rain", "Rain", "Rain", "Rain", 
        "Snow", "Rain", "Snow", "Rain", "Snow",
        "Snow", "Rain", "Snow", "Rain", "Rain", "Snow", "Snow", "Rain",
        "Rain", "Rain", "Rain", "Rain", "Rain", "Rain", "Rain",
        "Rain", "Snow", "Snow", "Snow", "Snow", "Snow", "Snow",
        "Snow", "Snow", "Rain", "Rain", "Rain", "Snow",
        "Snow", "Snow", "Snow", "Snow", 
        "Snow", "Rain", "Rain",
        "Snow", "Snow"
    };

    public WeatherState weatherState;
    public WeatherData[] weatherData;
    
    private void Awake()
    {
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.0f;
    }

    private void Start()
    {
        LoadweatherSystem();
        for (int i = 0; i < possibleWeatherConditionCodes.Length; i++)
        {
            if (possibleWeatherConditionCodes[i] == (int)LocationFromIp.getWeatherInfo())
            {
                StartCoroutine(StartDynamicWeather(ApiPossebleResbonseMached[i]));
                Debug.Log(possibleWeatherConditionCodes[i]);
                Debug.Log(ApiPossebleResbonse[i]);
            }
        }
        
        
                
                
    }

    void LoadweatherSystem()
    {
        for (int i = 0; i < weatherData.Length; i++)
        {
            weatherData[i].emission = weatherData[i].particleSystem.emission;
        }

        
    }

    
    IEnumerator StartDynamicWeather(string weather)
    {
        while (true)
        {
            ActivedWeather(weather);
            yield return null;
        }
        
    }

    private void ActivedWeather(string weather)
    {
        if (weatherData.Length > 0)
        {
            for (int i = 0; i < weatherData.Length; i++)
            {
                if (weatherData[i].particleSystem != null)
                {
                    if (weatherData[i].name == weather)
                    {
                        weatherData[i].emission.enabled = true;
                        

                    }else
                        weatherData[i].emission.enabled = false;
                }
            }
        }
    }
    

    void SelectWeather()
    {
        
        weatherState = WeatherState.Rain;
    }
    

    void ResetWeather()
    {
        return;
    }
}