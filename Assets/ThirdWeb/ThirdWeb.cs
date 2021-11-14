using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ThirdWeb : MonoBehaviour
{
    public void CheckLoggedIn()
    {
        var ack_id = ThirdWebInvoke("thirdweb.logged_in", "{}");
        Debug.LogFormat("ack_id: {0}", ack_id);
    }

    public void Callback(string payload)
    {
        Debug.LogFormat("Callback called: {0}", payload);
    }

    [DllImport("__Internal")]
    private static extern string ThirdWebInvoke(string route, string payload);
}
