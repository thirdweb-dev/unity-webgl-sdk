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

        [System.Serializable]
        private struct Result<T>
        {
            public string ack_id;
            public T result;
        }

        [System.Serializable]
        private struct RequestMessageBody
        {
            public RequestMessageBody(string[] arguments)
            {
                this.arguments = arguments;
            }

            public string[] arguments;
        }

        public async Task<T> InvokeRoute<T>(string route, string[] body)
        {
            var msg = JsonUtility.ToJson(new RequestMessageBody(body));
            var ack_id = ThirdwebInvoke(route, msg);
            var tr = new TaskCompletionSource<string>();
            taskMap[ack_id] = tr;
            string result = await tr.Task;
            // Debug.LogFormat("Result from {0}: {1}", route, result);
            return JsonUtility.FromJson<Result<T>>(result).result;
        }

        public async Task<string> InvokeRouteRaw(string route, string[] body)
        {
            var msg = JsonUtility.ToJson(new RequestMessageBody(body));
            var ack_id = ThirdwebInvoke(route, msg);
            var tr = new TaskCompletionSource<string>();
            taskMap[ack_id] = tr;
            string result = await tr.Task;
            // Debug.LogFormat("Result from {0}: {1}", route, result);
            return result;
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
        private static extern string ThirdwebInvoke(string route, string payload);
    }
}

