using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centroid : MonoBehaviour
{
    //list cac datapoint thuoc group cua Centroid nay o buoc L
    public List<GameObject> GroupL = new List<GameObject>();
    
    //list cac datapoint thuoc group cua Centroid nay o buoc L - 1
    public List<GameObject> GroupL1 = new List<GameObject>();

    //cac vi tri ma Centroid nay phai di chuyen den
    public List<Vector2> Positions = new List<Vector2>();
    public int Current = 0;

    //xem list datapoint co thay doi qua 2 buoc ko
    public bool IsChanged()
    {
        //kiem tra so phan tu co khac nhau ko
        if (GroupL.Count != GroupL1.Count)
        {
            return true;
        }

        //kiem tra tung phan tu
        for (int i = 0; i < GroupL.Count; i++)
        {
            Vector3 groupLPointPosition = GroupL[i].transform.position;
            Vector3 groupL1PointPosition = GroupL1[i].transform.position;

            if (groupLPointPosition.x != groupL1PointPosition.x || groupLPointPosition.y != groupL1PointPosition.y)
            {
                return true;
            }
        }

        return false;
    }

    //cập nhật các đỉnh (centroid): dịch chuyển về tâm của tất cả các data point thuộc nhóm của nó


    /*public void UpdatePosition()
    {
        X = Points.Sum(p => p.X) / Points.Count;
        Y = Points.Sum(p => p.Y) / Points.Count;
    }*/
    public void UpdateCentroid()
    {
        //tinh toa do cho centroid: trung binh cua toa do cac dinh
        float x = 0;
        float y = 0;

        foreach(GameObject dataPoint in GroupL)
        {
            x += dataPoint.transform.position.x;
            y += dataPoint.transform.position.y;
        }

        x /= (float)GroupL.Count;
        y /= (float)GroupL.Count;

        //cap nhat toa do cua centroid
        Positions.Add(new Vector2(x, y));
    }

    //chuyen buoc -> chuyen GroupL sang L1 va clear GroupL
    public void ChangeGroup()
    {
        GroupL1 = GroupL;
        GroupL = new List<GameObject>();
    }
}
