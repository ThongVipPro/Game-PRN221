using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    //dung de Spawn
    [SerializeField]
    GameObject DataPoint;

    [SerializeField]
    GameObject Centroid;

    void Awake()
    {
        BuildRandomMap(20, 4);

        //BuildMap();
    }

    private void SpamPoint()
    {

        //spam data point
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(DataPoint, StateVecter3(), Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject centroid = Instantiate(Centroid, StateVecter3(), Quaternion.identity);
            //random color
            centroid.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    void Update()
    {
        SpamPoint();
    }

    private Vector3 StateVecter3()
    {
        Vector3 new2 = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        /*Vector3 now = new Vector3(Input.mousePosition.x, Input.mousePosition.y);*/
        return new2;
    }

    //Tao ra cac DataPoint va cac Centroid tai vi tri ngau nhien
    private void BuildRandomMap(int DatapointNum, int CentroidNum)
    {
        //DataPoint
        for (int i = 0; i < DatapointNum; i++)
        {
            Instantiate(DataPoint, RandomVector(), Quaternion.identity);
        }

        //Centroid
        for (int i = 0; i < CentroidNum; i++)
        {
            GameObject centroid = Instantiate(Centroid, RandomVector(), Quaternion.identity);
            //random color
            centroid.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    //tao ra 1 Vector Random (dung cho Spawn)
    private Vector3 RandomVector()
    {
        Vector3 vector = new Vector3(Random.Range(-8f, 8f), Random.Range(-4.8f, 4.8f), 0);
        return vector;
    }

    //-------------------------------------------

    //tao ra map theo 1 kich ban cu the
    private void BuildMap()
    {
        //quarter 1
        Instantiate(DataPoint, new Vector3(5, 3, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(8, 4, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(4, 4, 0), Quaternion.identity);

        //quarter 2
        Instantiate(DataPoint, new Vector3(-6, -2, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(-4, -2, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(-5, -4, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(-6, -3, 0), Quaternion.identity);

        //quarter 3
        Instantiate(DataPoint, new Vector3(5, -4, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(7, -3, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(5, -2, 0), Quaternion.identity);

        //quarter 4
        Instantiate(DataPoint, new Vector3(-4, 4, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(-6, 3, 0), Quaternion.identity);
        Instantiate(DataPoint, new Vector3(-8, 4, 0), Quaternion.identity);

        //Centroid
        Instantiate(Centroid, new Vector3(1, 1, 0), Quaternion.identity).GetComponent<SpriteRenderer>().color = Color.red;
        Instantiate(Centroid, new Vector3(4, -7, 0), Quaternion.identity).GetComponent<SpriteRenderer>().color = Color.green;
        Instantiate(Centroid, new Vector3(2, -3, 0), Quaternion.identity).GetComponent<SpriteRenderer>().color = Color.yellow;
        Instantiate(Centroid, new Vector3(-1, -1, 0), Quaternion.identity).GetComponent<SpriteRenderer>().color = Color.white;
    }
}
