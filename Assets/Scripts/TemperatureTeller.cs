﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TemperatureTeller : MonoBehaviour
{   
    GameObject requestHandlerGameObject;
    RequestHandler requestHandler;
    // Start is called before the first frame update
    void Start()
    {
        requestHandlerGameObject = GameObject.Find("RequestHandler");
        requestHandler = requestHandlerGameObject.GetComponent<RequestHandler>();
    }

    void Update() {
        this.GetComponent<TextMeshPro>().text = this.requestHandler.weatherData.main.temp.ToString() + " F";    
    }

}
