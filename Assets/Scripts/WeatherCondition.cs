using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCondition : MonoBehaviour
{
    public GameObject clearSky;
    public GameObject fewClouds;
    public GameObject scatteredClouds;
    public GameObject brokenClouds;
    public GameObject showerRain;
    public GameObject rain;
    public GameObject thunderStorm;
    public GameObject snow;
    public GameObject mist;
    public int pointer = 0;
    GameObject[] objects;
    Dictionary<string, GameObject> objectsDict = new Dictionary<string, GameObject>();
    GameObject currentObject;
    string currentPrefab;
    GameObject requestHandlerGameObject;
    RequestHandler requestHandler;

    // Start is called before the first frame update
    void Start()
    {
        objects = new GameObject[] {this.clearSky, this.fewClouds, this.scatteredClouds, this.brokenClouds, this.showerRain, this.rain, this.thunderStorm, this.snow, this.mist};
        objectsDict.Add("clear sky", clearSky);
        objectsDict.Add("few clouds", fewClouds);
        objectsDict.Add("scattered clouds", scatteredClouds);
        objectsDict.Add("broken clouds", brokenClouds);
        objectsDict.Add("shower rain", showerRain);
        objectsDict.Add("rain", rain);
        objectsDict.Add("thunderstorm", thunderStorm);
        objectsDict.Add("snow", snow);
        objectsDict.Add("mist", mist);
        requestHandlerGameObject = GameObject.Find("RequestHandler");
        requestHandler = requestHandlerGameObject.GetComponent<RequestHandler>();
        InvokeRepeating("InstantiatePrefab", 0f, 1f); 
    }

    void InstantiatePrefab() {
        if (this.requestHandler.weatherData.weather.Length != 0 && this.gameObject.activeSelf) {
            if (currentPrefab != this.requestHandler.weatherData.weather[0].description) {
                if (currentObject != null) {
                    Destroy(currentObject);
                }
                if (objectsDict.ContainsKey(this.requestHandler.weatherData.weather[0].description)){
                    currentObject = Instantiate(objectsDict[this.requestHandler.weatherData.weather[0].description], transform.position, Quaternion.identity, transform.parent);
                    currentPrefab = this.requestHandler.weatherData.weather[0].description;
                }
                else {
                    currentObject = Instantiate(objectsDict["few clouds"], transform.position, Quaternion.identity, transform.parent);
                    currentPrefab = "few clouds";
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CancelInvoke();
            pointer = (pointer + 1) % objects.Length;
            Destroy(currentObject);
            currentObject = Instantiate(objects[pointer], transform.position, Quaternion.identity, transform.parent);
        }
    }
}
