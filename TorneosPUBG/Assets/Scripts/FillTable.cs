using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillTable : MonoBehaviour
{
    [SerializeField] private Transform idList;
    [SerializeField] private Transform dateList;
    [SerializeField] private GameObject prefabElement;
    [SerializeField] private List<Color> colors;
    [SerializeField] private DialogInfo dialogInfo;

    private IService _service;

    /// <summary>
    /// Make a request to the service that has the information
    /// </summary>
    public void AskInformationToServer()
    {
        dialogInfo.StartLoading();
        StartCoroutine(_service.AskForData());
    }

    /// <summary>
    /// Set the IService.
    /// </summary>
    /// <param name="service"></param>
    public void SetService(IService service)
    {
        _service = service;
        _service.dataReceived += ShowData;
    }

    /// <summary>
    /// Shows something in the graphical interface according to what is obtained from the server.
    /// </summary>
    /// <param name="jsonText">JSON a cargar en la tabla.</param>
    public void ShowData(string response)
    {
        int responseCode;
        if (int.TryParse(response, out responseCode))
        {
            switch(responseCode)
            {
                case 0:
                    ConnectionError();
                    break;
                case 429:
                    RequestLimitError();
                    break;
                default:
                    ServerError();
                    break;
            }
        }
        else
        {
            CompleteTable(response);
        }
    }

    /// <summary>
    /// Complete the table with the information obtained in the JSON.
    /// </summary>
    /// <param name="jsonText">JSON to load in the table.</param>
    public void CompleteTable(string jsonText)
    {
        SimpleJSON.JSONNode json = SimpleJSON.JSON.Parse(jsonText)["data"];
        GameObject element;
        for (int i = 0; i < json.Count; i++)
        {
            element = Instantiate(prefabElement, idList);
            element.GetComponent<Image>().color = colors[i % colors.Count];
            element.GetComponentInChildren<Text>().text = json[i]["id"];

            element = Instantiate(prefabElement, dateList);
            element.GetComponent<Image>().color = colors[i % colors.Count];
            element.GetComponentInChildren<Text>().text = json[i]["attributes"]["createdAt"].Value.Substring(0, 10);
        }
        dialogInfo.FinishLoading();
    }

    /// <summary>
    /// Sends a command to display a connection error message.
    /// </summary>
    public void ConnectionError()
    {
        dialogInfo.ConnectionError();
    }

    /// <summary>
    /// Send a command to display an error message when too many queries were made.
    /// </summary>
    public void RequestLimitError()
    {
        dialogInfo.RequestLimitError();
    }

    /// <summary>
    /// Send a command to display an error message when a problem occurred on the server.
    /// </summary>
    public void ServerError()
    {
        dialogInfo.ServerError();
    }

}
