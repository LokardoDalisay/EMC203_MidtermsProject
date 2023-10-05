using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DashManager : MonoBehaviour
{
    public int dash_count;
    public Text dash_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       dash_text.text = dash_count.ToString();
    }
}
