using System.Collections;
using UnityEngine.Events;

public delegate void DataReceived(string data);

public interface IService
{
    event DataReceived dataReceived;
    IEnumerator AskForData();
}
