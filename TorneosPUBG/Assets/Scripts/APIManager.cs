using System.Collections;
using UnityEngine.Networking;

public class APIManager
{
    private const string url = "https://api.pubg.com/tournaments";
    private const string accept = "application/vnd.api+json";
    private const string Authorization = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI2ZjVjN2JlMC1iZTQwLTAxMzgtODJjMi0wYmM1ZWQ2ZGE2MzciLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNTk3MTc4MjY1LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6ImdvbnphbG9ydGVnby1nIn0.rbEjKV6EnErjws5Gj1dcMkgH3n53b9L4MQA3bHJGcS8";

    private FillTable fillTable;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="fillTable">FillTable que recibira la respuesta del servidor.</param>
    public APIManager(FillTable fillTable)
    {
        this.fillTable = fillTable;
    }

    /// <summary>
    /// Envia un pedido al servidor y le da una respuesta al FillTable que hizo la solicitud.
    /// </summary>
    /// <returns></returns>
    public IEnumerator askForData()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        webRequest.SetRequestHeader("accept", accept);
        webRequest.SetRequestHeader("Authorization", Authorization);
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            fillTable.connectionError();
            yield break;
        }
        else if (webRequest.isHttpError)
        {
            if(webRequest.responseCode == 429)
                fillTable.requestLimitError();
            else
                fillTable.serverError();
            yield break;
        }

        fillTable.completeTable(webRequest.downloadHandler.text);
    }
}
