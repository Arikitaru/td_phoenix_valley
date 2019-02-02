using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];
        //отсылка к waypoint массиву в другом скрипте
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        //в каждом кадре двигаться ближе и ближе к цели; Вектор получен вычитанием цель-позиция; 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //Normalize нормализация вектора, таким образом единственное что влияет на скорость - speed;
        //Time.DeltaTime для независимости скорости от ФПС ПК; Space.World для привязки вектора к миру;

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        //Проверка дистанции до точки назначения
        {
            GetNextWaypoint();
        //Если да, вызвать часть скрипта "GetNextWaypoint"
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        //Если индекс Точки Назначения более или равен общему количеству точек назначения(длине массива), минус один ->
        {
            Destroy(gameObject);
            return;
            //Иногда код может продолжить работать быстрее, чем уничтожение объекта; Return останавливает код;
        }

        waypointIndex++;
        //при вызове функции, накинуть +1 к индексу точки назначения
        target = Waypoints.waypoints[waypointIndex];
        //привязка нового значения переменной target
    }

}
