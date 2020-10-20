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

    public void AskInformationToServer()
    {
        dialogInfo.StartLoading();
        StartCoroutine(_service.AskForData(ShowData));
    }

    /// <summary>
    /// Set the IService.
    /// </summary>
    /// <param name="service"></param>
    public void SetService(IService service)
    {
        _service = service;
    }

    /// <summary>
    /// Completa la tabla con la informacion obtenida en el JSON.
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
    /// Completa la tabla con la informacion obtenida en el JSON.
    /// </summary>
    /// <param name="jsonText">JSON a cargar en la tabla.</param>
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
    /// Envia una orden de mostrar un mensaje de error de conexion.
    /// </summary>
    public void ConnectionError()
    {
        dialogInfo.ConnectionError();
    }

    /// <summary>
    /// Envia una orden de mostrar un mensaje de error cuando se hicieron demasiadas consultas.
    /// </summary>
    public void RequestLimitError()
    {
        dialogInfo.RequestLimitError();
    }

    /// <summary>
    /// Envia una orden de mostrar un mensaje de error cuando ocurrio un problema en el servidor.
    /// </summary>
    public void ServerError()
    {
        dialogInfo.ServerError();
    }

}
