using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;
    //создаем массив

    void Awake ()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }

    }
    //при Awake осмотреть и подгрузить объекты в массив
}
