using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTeller : MonoBehaviour
{
    GameObject requestHandlerGameObject;
    RequestHandler requestHandler;
    // Start is called before the first frame update
    void Start()
    {
        requestHandlerGameObject = GameObject.Find("RequestHandler");
        requestHandler = requestHandlerGameObject.GetComponent<RequestHandler>();
        InvokeRepeating("ChangeTime", 0f, 30f);
    }

    // Update is called once per frame
    void ChangeTime()
    {
        if (this.requestHandler.unit == "imperial") {
            this.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("h:mm tt");
        }
        else {
            this.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("HH:mm tt");
        }
    }
}
