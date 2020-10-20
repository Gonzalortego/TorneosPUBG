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
    /// Turn on the Dialog.
    /// </summary>
    public void StartLoading()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Turn off the Dialog.
    /// </summary>
    public void FinishLoading()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Displays an error message when connection could not be established.
    /// </summary>
    public void ConnectionError()
    {
        txtDialog.text = "Could not connect to the server.";
    }

    /// <summary>
    /// Displays an error message when too many queries were made to the server.
    /// </summary>
    public void RequestLimitError()
    {
        txtDialog.text = "You can only make a maximum of 10 queries per minute.";
    }

    /// <summary>
    /// Displays an error message when the expected response was not obtained from the server.
    /// </summary>
    public void ServerError()
    {
        txtDialog.text = "An error occurred on the server.";
    }

}
