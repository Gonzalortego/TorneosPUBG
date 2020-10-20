using UnityEngine;

public class Inyector : MonoBehaviour
{

    public FillTable _fillTable;

    void Start()
    {
        IService service = new APIManager();
        _fillTable.SetService(service);
        _fillTable.AskInformationToServer();
    }
}
