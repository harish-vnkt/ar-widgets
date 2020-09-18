﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WindSpeedTeller : MonoBehaviour
{
    public GameObject flagPivot;
    GameObject requestHandlerGameObject;
    RequestHandler requestHandler;
    float windSpeed, direction;
    float range = 0.0503f;
    // Start is called before the first frame update
    void Start()
    {
        requestHandlerGameObject = GameObject.Find("RequestHandler");
        requestHandler = requestHandlerGameObject.GetComponent<RequestHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        windSpeed = requestHandler.weatherData.wind.speed;
        direction = requestHandler.weatherData.wind.deg;
        this.GetComponent<TextMeshPro>().text = windSpeed.ToString() + " m/s";
        float newYPosition = (windSpeed / 10f) * this.range;
        this.flagPivot.transform.localPosition = new Vector3(this.flagPivot.transform.localPosition.x, newYPosition, this.flagPivot.transform.localPosition.z);
        if (this.flagPivot.transform.eulerAngles.y == 0f) {
            this.flagPivot.transform.RotateAround(this.flagPivot.transform.position, Vector3.up, this.direction);
        }
    }
}