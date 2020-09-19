using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HumidityTeller : MonoBehaviour
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
        InvokeRepeating("UpdateHumidity", 0f, 1f); 
    }

    void UpdateHumidity() {
        this.GetComponent<TextMeshPro>().text = this.requestHandler.weatherData.main.humidity.ToString() + "%";

        float humidity = this.requestHandler.weatherData.main.humidity;
        float range = 1.22f;
        float scaleFactor = (100 / 100f) * range;

        botCylinderPivot.transform.localScale = new Vector3(botCylinderPivot.transform.localScale.x, scaleFactor, botCylinderPivot.transform.localScale.z);
        topCylinderPivot.transform.localScale = new Vector3(topCylinderPivot.transform.localScale.x, (range - scaleFactor), topCylinderPivot.transform.localScale.z);
    }
}
