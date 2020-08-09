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
    [SerializeField] private int elementsCount;

    // Start is called before the first frame update
    void Start()
    {
        completeTableID();
        completeTableDate();
    }

    private void completeTableID()
    {
        GameObject element;
        for (int i = 0; i < elementsCount; i++)
        {
            element = Instantiate(prefabElement, idList);
            element.GetComponent<Image>().color = colors[i % colors.Count];
            element.GetComponentInChildren<Text>().text = i.ToString();
        }
    }

    private void completeTableDate()
    {
        GameObject element;
        for (int i = 0; i < elementsCount; i++)
        {
            element = Instantiate(prefabElement, dateList);
            element.GetComponent<Image>().color = colors[i % colors.Count];
            element.GetComponentInChildren<Text>().text = i.ToString();
        }
    }

}
