using SimpleJSON;
using System.Collections;
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
    
    void Start()
    {
        dialogInfo.startLoading();
        APIManager am = new APIManager(this);
        StartCoroutine(am.askForData());
    }

    /// <summary>
    /// Completa la tabla con la informacion obtenida en el JSON.
    /// </summary>
    /// <param name="jsonText">JSON a cargar en la tabla.</param>
    public void completeTable(string jsonText)
    {
        JSONNode json = JSON.Parse(jsonText)["data"];
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
        dialogInfo.finishLoading();
    }

    /// <summary>
    /// Envia una orden de mostrar un mensaje de error de conexion.
    /// </summary>
    public void connectionError()
    {
        dialogInfo.connectionError();
    }

    /// <summary>
    /// Envia una orden de mostrar un mensaje de error cuando se hicieron demasiadas consultas.
    /// </summary>
    public void requestLimitError()
    {
        dialogInfo.requestLimitError();
    }

    /// <summary>
    /// Envia una orden de mostrar un mensaje de error cuando ocurrio un problema en el servidor.
    /// </summary>
    public void serverError()
    {
        dialogInfo.serverError();
    }

}
