﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateTeller : MonoBehaviour
{   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeDate", 0f, 30f);
    }

    // Update is called once per frame
    void ChangeDate()
    {
        this.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("MM/dd/yyyy");
    }
}
