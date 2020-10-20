using System.Collections;
using UnityEngine.Networking;

public class APIManager: IService
{
    private const string url = "https://api.pubg.com/tournaments";
    private const string accept = "application/vnd.api+json";
    private const string Authorization = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI2ZjVjN2JlMC1iZTQwLTAxMzgtODJjMi0wYmM1ZWQ2ZGE2MzciLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNTk3MTc4MjY1LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6ImdvbnphbG9ydGVnby1nIn0.rbEjKV6EnErjws5Gj1dcMkgH3n53b9L4MQA3bHJGcS8";

    public event DataReceived dataReceived;

    /// <summary>
    /// Sends a request to the server and invoke an event.
    /// </summary>
    /// <returns></returns>
    public IEnumerator AskForData()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        webRequest.SetRequestHeader("accept", accept);
        webRequest.SetRequestHeader("Authorization", Authorization);
        yield return webRequest.SendWebRequest();
        
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            dataReceived.Invoke(webRequest.responseCode.ToString());
            yield break;
        }

        dataReceived.Invoke(webRequest.downloadHandler.text);
    }
}
