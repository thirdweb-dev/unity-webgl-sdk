using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Thirdweb
{
    public class Bridge : MonoBehaviour
    {
        private Dictionary<string, TaskCompletionSource<string>> taskMap = new Dictionary<string, TaskCompletionSource<string>>();

        [System.Serializable]
        private struct GenericMessage
        {
            public string ack_id;
        }

        public async Task<string> InvokeRoute(string route, string payload)
        {
            var ack_id = ThirdWebInvoke(route, payload);
            var tr = new TaskCompletionSource<string>();
            taskMap[ack_id] = tr;
            return await tr.Task;
        }

        public void Callback(string payload)
        {
            var msg = JsonUtility.FromJson<GenericMessage>(payload);
            if (taskMap.ContainsKey(msg.ack_id))
            {
                var tr = taskMap[msg.ack_id];
                tr.SetResult(payload);
                taskMap.Remove(msg.ack_id);
            }
        }

        [DllImport("__Internal")]
        private static extern string ThirdWebInvoke(string route, string payload);
    }
}

