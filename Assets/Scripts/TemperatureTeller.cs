using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TemperatureTeller : MonoBehaviour
{   
    GameObject requestHandlerGameObject;
    RequestHandler requestHandler;
    GameObject botCylinderPivot;
    GameObject topCylinderPivot;
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
        this.GetComponent<TextMeshPro>().text = this.requestHandler.weatherData.main.temp.ToString() + " C";

        float temperature = this.requestHandler.weatherData.main.temp;
        float range = 1.06f;
        float scaleFactor = ((20f + temperature) / 60f) * range;

        botCylinderPivot.transform.localScale = new Vector3(botCylinderPivot.transform.localScale.x, scaleFactor, botCylinderPivot.transform.localScale.z);
        topCylinderPivot.transform.localScale = new Vector3(topCylinderPivot.transform.localScale.x, (range - scaleFactor), topCylinderPivot.transform.localScale.z);
    }

}
