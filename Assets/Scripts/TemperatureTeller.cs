using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class TemperatureTeller : MonoBehaviour
{   
    string url = "http://api.openweathermap.org/data/2.5/weather?lat=41.88&lon=-87.6&APPID=f50fe7a9f2ca387f5670be5ddebca8cb";
    public WeatherData weatherData = new WeatherData();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetDataFromWeb", 2f, 900f);    
    }

    void GetDataFromWeb() {
        StartCoroutine(GetRequest());
        this.GetComponent<TextMeshPro>().text = this.weatherData.main.temp.ToString();
    }

    // Update is called once per frame
    public IEnumerator GetRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(this.url))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                weatherData = JsonUtility.FromJson<WeatherData>(webRequest.downloadHandler.text);
                Debug.Log(weatherData.main.temp);
            }
            
        }
    }
}
