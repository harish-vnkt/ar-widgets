using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Vuforia;

public class TemperatureTeller : MonoBehaviour
{   
    GameObject requestHandlerGameObject;
    RequestHandler requestHandler;
    GameObject botCylinderPivot;
    GameObject topCylinderPivot;
    float scale = -1f;
    // Start is called before the first frame update
    void Start()
    {
        requestHandlerGameObject = GameObject.Find("RequestHandler");
        requestHandler = requestHandlerGameObject.GetComponent<RequestHandler>();
        botCylinderPivot = transform.parent.Find("BotCylinderPivot").gameObject;
        topCylinderPivot = transform.parent.Find("TopCylinderPivot").gameObject;
        InvokeRepeating("UpdateThermometer", 0f, 1f); 
    }

    void UpdateThermometer() {
        
        float temperature = this.requestHandler.weatherData.main.temp;
        float range = 1.06f;
        float scaleFactor = ((temperature - 20) / 70f) * range;
        string unit = "";
        if (this.requestHandler.unit == "imperial") {
            unit = " F";
        }
        else {
            unit = " C";
        }
        
        this.GetComponent<TextMeshPro>().text = temperature.ToString() + unit;

        if (scale == -1 && scaleFactor > 0) {
            this.scale = scaleFactor;
            botCylinderPivot.transform.localScale = new Vector3(botCylinderPivot.transform.localScale.x, scaleFactor, botCylinderPivot.transform.localScale.z);
            topCylinderPivot.transform.localScale = new Vector3(topCylinderPivot.transform.localScale.x, (range - scaleFactor), topCylinderPivot.transform.localScale.z);
        }
    
    }

}
