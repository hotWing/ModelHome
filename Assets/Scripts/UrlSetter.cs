using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UniWebView))]
public class UrlSetter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UniWebView uniWebView = GetComponent<UniWebView>();
        uniWebView.url = PlayerPrefs.GetString("url");
        uniWebView.Load();
    }
}
