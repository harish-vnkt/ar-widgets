using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateTeller : MonoBehaviour
{   

    GameObject requestHandlerGameObject;
    RequestHandler requestHandler;
    // Start is called before the first frame update
    void Start()
    {
        requestHandlerGameObject = GameObject.Find("RequestHandler");
        requestHandler = requestHandlerGameObject.GetComponent<RequestHandler>();
        InvokeRepeating("ChangeDate", 0f, 30f);
    }

    // Update is called once per frame
    void ChangeDate()
    {
        if (this.requestHandler.unit == "imperial") {
            this.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("MM/dd/yyyy");
        }
        else {
            this.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        
    }
}
