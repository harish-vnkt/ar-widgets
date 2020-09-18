using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HumidityTeller : MonoBehaviour
{   
    GameObject requestHandlerGameObject;
    RequestHandler requestHandler;
    // Start is called before the first frame update
    void Start()
    {
        requestHandlerGameObject = GameObject.Find("RequestHandler");
        requestHandler = requestHandlerGameObject.GetComponent<RequestHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshPro>().text = this.requestHandler.weatherData.main.humidity.ToString() + "%";
    }
}
