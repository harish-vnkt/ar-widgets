using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestHandler : MonoBehaviour
{
    public string apiKey;
    string url = "http://api.openweathermap.org/data/2.5/weather?lat=41.88&lon=-87.6&APPID=";
    public string unit = "imperial";
    [HideInInspector] public WeatherData weatherData;
    // Start is called before the first frame update
    void Start()
    {
        url = url + apiKey;
        InvokeRepeating("GetDataFromWeb", 2f, 10f); 
    }

    public void ChangeUnit() {
        if (this.unit == "imperial") {
            this.unit = "metric";
        }
        else {
            this.unit = "imperial";
        }
    }

    // Update is called once per frame
    void GetDataFromWeb() {
        StartCoroutine(GetRequest());
    }

    public IEnumerator GetRequest()
    {
        string new_url = this.url + "&units=" + this.unit;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(new_url))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                weatherData = JsonUtility.FromJson<WeatherData>(webRequest.downloadHandler.text);
            }
            
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            this.ChangeUnit();
        }
    }
}
