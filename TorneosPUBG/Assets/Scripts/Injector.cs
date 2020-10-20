using UnityEngine;

public class Injector : MonoBehaviour
{

    public FillTable _fillTable;

    /// <summary>
    /// I usually use Zenject for dependency injection, but as in this case there was only one. I did it manually.
    /// </summary>
    void Start()
    {
        IService service = new APIManager();
        _fillTable.SetService(service);
        _fillTable.AskInformationToServer();
    }
}
