using UnityEngine;
using UnityEngine.UI;

public class DialogInfo : MonoBehaviour
{
    private Text txtDialog;

    private void Start()
    {
        txtDialog = GetComponentInChildren<Text>();
    }

    /// <summary>
    /// Enciende el Dialog.
    /// </summary>
    public void StartLoading()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Apaga el Dialog.
    /// </summary>
    public void FinishLoading()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Muestra un mensaje de error cuando no se pudo establecer conexion.
    /// </summary>
    public void ConnectionError()
    {
        txtDialog.text = "No se pudo establecer conexion con el servidor.";
    }

    /// <summary>
    /// Muestra un mensaje de error cuando se hicieron demasiadas consultas al servidor.
    /// </summary>
    public void RequestLimitError()
    {
        txtDialog.text = "Solo puede hacer un maximo de 10 consultas por minuto.";
    }

    /// <summary>
    /// Muestra un mensaje de error cuando no se obtuvo la respuesta esperada del servidor.
    /// </summary>
    public void ServerError()
    {
        txtDialog.text = "Ocurrio un error en el servidor.";
    }

}
