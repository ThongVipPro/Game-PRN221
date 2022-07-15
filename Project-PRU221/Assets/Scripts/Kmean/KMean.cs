using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class KMean : MonoBehaviour
{
    List<GameObject> DataPoints;
    List<GameObject> Centroids;

    private bool check = false;

    // Start is called before the first frame update
    public void Start()
    {
        
        //check = false;
        
        GetPoints();
    }

    public void RunHello()
    {
        GetPoints();

        Train();
        check = true;
    }

    //lay ra cac GameObject DataPoint va Centroid tren Game
    private void GetPoints()
    {
        DataPoints = GameObject.FindGameObjectsWithTag("DataPoint").ToList();

        Centroids = GameObject.FindGameObjectsWithTag("Centroid").ToList();
    }

    //thuc hien thuat toan
    private void Train()
    {
        bool flag = true;
        do
        {
            //update group cho cac Centroid
            foreach (GameObject centroid in Centroids)
            {
                Centroid centroidComponent = centroid.GetComponent<Centroid>();
                centroidComponent.ChangeGroup();
            }

            foreach (GameObject dataPoint in DataPoints)
            {
                //de luu centroid co khoang cach gan nhat den dataPoint nay
                Dictionary<GameObject, float> nearestCentroid = new Dictionary<GameObject, float>();
                nearestCentroid.Add(Centroids[0], float.MaxValue);

                foreach (GameObject centroid in Centroids)
                {
                    //Step 2: compute d(cj, di) with all i = 1..N; j = 1..K
                    float distance = Vector2.Distance(dataPoint.transform.position, centroid.transform.position);

                    if (distance < nearestCentroid.ElementAt(0).Value)
                    {
                        nearestCentroid.Clear();
                        nearestCentroid.Add(centroid.gameObject, distance);
                    }
                }

                //Step 3: assign di to group cT such that: T = argmin d(cj, di) với j = 1..K với mọi i = 1..N
                //Gan vao group L
                Centroid nearestCentroidComponent = nearestCentroid.ElementAt(0).Key.GetComponent<Centroid>();
                nearestCentroidComponent.GroupL.Add(dataPoint);
            }

            //Step 4: update Centroid
            foreach (GameObject centroid in Centroids)
            {
                Centroid centroidComponent = centroid.GetComponent<Centroid>();
                centroidComponent.UpdateCentroid();
            }

            //Step 5: nếu Cjl.group = Cjl-1.group với mọi j = 1..K => stop algorithm
            flag = false;

            foreach (GameObject centroid in Centroids)
            {
                if (centroid.GetComponent<Centroid>().IsChanged())
                {
                    flag = true;
                }
            }
        } while (flag);
    }

    public void Update()
    {
        Train();
        UpdateVisual();
              
    }


    private void UpdateVisual()
    {
        //update group cho cac Centroid
        foreach (GameObject centroid in Centroids)
        {
            Centroid centroidComponent = centroid.GetComponent<Centroid>();
            centroidComponent.ChangeGroup();
        }

        //tinh lai khoang cach tu moi dataPoint den tung Centroid de gan Group cho no -> doi mau
        foreach (GameObject dataPoint in DataPoints)
        {
            Dictionary<GameObject, float> nearestCentroid = new Dictionary<GameObject, float>();
            nearestCentroid.Add(Centroids[0], float.MaxValue);

            foreach (GameObject centroid in Centroids)
            {
                float distance = Vector2.Distance(dataPoint.transform.position, centroid.transform.position);

                if (distance < nearestCentroid.ElementAt(0).Value)
                {
                    nearestCentroid.Clear();
                    nearestCentroid.Add(centroid.gameObject, distance);
                }
            }

            Centroid nearestCentroidComponent = nearestCentroid.ElementAt(0).Key.GetComponent<Centroid>();
            nearestCentroidComponent.GroupL.Add(dataPoint);
        }

        //voi moi Centroid
        foreach (GameObject centroidObject in Centroids)
        {
            //doi mau cho cac DataPoint theo Group cua Centroid
            foreach(GameObject dataPoint in centroidObject.GetComponent<Centroid>().GroupL)
            {
                dataPoint.GetComponent<SpriteRenderer>().color = centroidObject.GetComponent<SpriteRenderer>().color;
            }

            //di chuyen tu tu Centroid den cac vi tri can den
            List<Vector2> Positions = centroidObject.GetComponent<Centroid>().Positions;
            int current = centroidObject.GetComponent<Centroid>().Current;
            centroidObject.transform.position = Vector3.MoveTowards(centroidObject.transform.position, Positions[current], Time.deltaTime * 1f);
            
            if (current >= Positions.Count - 1)
            {
                return;
            }

            else
            {
            }

            if (Vector3.Distance(Positions[current], centroidObject.transform.position) < 1)
            {
                centroidObject.GetComponent<Centroid>().Current++;
            }
        }
    }
}
