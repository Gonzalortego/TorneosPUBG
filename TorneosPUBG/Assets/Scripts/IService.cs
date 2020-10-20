using System.Collections;

public delegate void DeliverMessageCallback(string s);

public interface IService
{
    IEnumerator AskForData(DeliverMessageCallback deliverMessageCallback);
}
