using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class ThirdWeb : MonoBehaviour
{
    private Dictionary<string, TaskCompletionSource<string>> taskMap = new Dictionary<string, TaskCompletionSource<string>>();

    [System.Serializable]
    private struct GenericMessage
    {
        public string ack_id;
    }

    [System.Serializable]
    private struct CheckLoggedInMsg
    {
        public bool result;
    }

    public async void CheckLoggedIn()
    {
        var ack_id = ThirdWebInvoke("thirdweb.logged_in", "{}");
        var tr = new TaskCompletionSource<string>();
        taskMap[ack_id] = tr;
        var msg = await tr.Task;
        var loggedInMsg = JsonUtility.FromJson<CheckLoggedInMsg>(msg);
        Debug.LogFormat("logged in message: {0}", msg);
        Debug.LogFormat("logged in: {0}", loggedInMsg.result);
    }

    public void Callback(string payload)
    {
        var msg = JsonUtility.FromJson<GenericMessage>(payload);
        if(taskMap.ContainsKey(msg.ack_id))
        {
            var tr = taskMap[msg.ack_id];
            tr.SetResult(payload);
            taskMap.Remove(msg.ack_id);
        }
    }

    [DllImport("__Internal")]
    private static extern string ThirdWebInvoke(string route, string payload);
}
