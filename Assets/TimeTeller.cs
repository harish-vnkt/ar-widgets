using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTeller : MonoBehaviour
{
    public GameObject timeTextObject;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeTime", 0f, 30f);
    }

    // Update is called once per frame
    void ChangeTime()
    {
        timeTextObject.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("h:mm tt");
    }
}
