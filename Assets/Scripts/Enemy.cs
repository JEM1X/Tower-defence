using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed; // �������� �������� �����
    public float RotationSpeed; // �������� �������� �����
    public Transform[] Points; // ������ ����� �������� �������� �����
    private Transform currentPoint; // ������� ����� �������� ����� (���� ��������)
    private int index; // ����� ������� ����� �������� ����� �� ������� "Points"
    public float MaxHP; // ��������� ��������
    private float HP; // ������� ��������
    private ResourceManager rm; // ������ �� ������ "ResourceManager"

    void Start()
    {
        index = 0; // �������� � 0-� ����� (1-� �� ������� � ������� "Points")
        currentPoint = Points[index]; // ������� ����� �������� ����� - 0-� ������� ������� "Points"
        HP = MaxHP; // ������������� ����� ������� �������� ������������� �������� (������, ���� ������������ "SetHP(float newHP)")
        rm = FindObjectOfType<ResourceManager>(); // ������ ���������/������ �� ������ "ResourceManager"
    }

    void Update()
    {
        Vector3 direct_pos = currentPoint.position - transform.position;
        // "direct_pos" - ������/��������/������ ����������� ����� (���� � �� ������� ��������)
        // "currentPoint.position" - �������/���������� ������� ����� �������� �� ������� "Points" (���� ��������)
        // "transform.position"- �������/���������� ������� ������� ����� (���������� ���."Enemy")
        // "transform.position" - ��������� � �������� "Position" �������, � ��. �������� ������ ������
        Vector3 direct_rot = Vector3.RotateTowards(transform.forward, direct_pos, Time.deltaTime * RotationSpeed, 0);
        // ".RotateTowards" (������� �)
        // "transform.forward" - ������� �� ������ �������/�����������/���
        transform.rotation = Quaternion.LookRotation(direct_rot); // ������� � ������� ������� "direct_pos"

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * Speed);
        // ".MoveTowards" (������� �) - ����������� �� ������ � �������� �����
        // "transform.position" - �������/��������� �������
        // "currentPoint.position" - �������/�������� �������
        // "Time.deltaTime*Speed" - ��� �����������
        // "Time.deltaTime" - ����� � ��������, ������� ������������� ��� ��������� ���������� �����

        if (transform.position == currentPoint.position)
        // ���� �������� ������� ����� �������� ����� (���� ��������), �.�. �������� ���������� ���� �������� ��������
        {
            index++; // ��������� � ��������� ����� �������� �����

            if (index == Points.Length) // ���� ����� ������� ����� �������� ����� ����� �� ������� ������� "Points"
            {
                
                Destroy(gameObject); // ����������� �������� �������
            }
            else
            {
                currentPoint = Points[index]; // ������� ����� �������� ����� - "index"-� ������� ������� "Points"
            }
        }
    }

    private void OnTriggerEnter(Collider other) // ������������ ��������
    {
        if (other.CompareTag("Bullet")) // ���� ��������� ����� ���������� � ��."Bullet"
        {
            
            Destroy(other.gameObject); // ������� ������, ������� ���������� � ������ (��."Bullet")
            
            HP -= other.GetComponent<Bullet>().Damage; // ��������� ������� �������� ����� �� �������� ����� ��."Bullet"        

            if (HP <= 0) //���� ������� �������� ����� <= 0
            {
                Destroy(gameObject); // ���������� ���� (���.���."Enemy")

                rm.EnemyKill(); // �������� ������ �� ����������� ����� 
            }
        } 
        else if (other.CompareTag("FreezeBullet"))
        {
            
            Destroy(other.gameObject);
            
            HP -= other.GetComponent<FreezeBullet>().Damage;

            if (HP <= 0)
            {
                Destroy(gameObject);

                rm.EnemyKill();
            }
        }

        else if (other.CompareTag("BombBullet"))
        {

            Destroy(other.gameObject);

            //Collider[] coll = Physics.OverlapSphere(transform.position, 1, gameObject);
            // создаём сферу "Physics.OverlapSphere" для поиска внутри неё всех коллайдеров юнитов
            // "transform.position" - центр сферы, "Radius" - радиус сферы, "EnemyLayer" юниты с коллайдерами на слое "Enemy"
            // "coll" - массив найденных коллайдеров юнитов слоя "Enemy"

            //if (coll.Length > 0) // если коллайдеры юнитов найдены
            //   enemy = coll[0].transform; // сохраняем координаты 1-го найденного юнита
            HP -= other.GetComponent<BombBullet>().Damage;
            
            if (HP <= 0)
            {
                Destroy(gameObject);

                rm.EnemyKill();
            }
        }
        
        else if (other.CompareTag("Castle"))
        {
            
            other.GetComponent<Castle>().TakeDamage(10);
            Destroy(gameObject); 
        }

    
    
    }

    public void TakeDamage(float damage)
    {
        HP -= damage; // уменьшаем текущее здоровье на величину полученного урона

        if (HP <= 0) // если здоровье меньше или равно нулю
        {
            Destroy(gameObject); // уничтожаем объект врага

            if (rm != null)
            {
                rm.EnemyKill(); // уведомляем ResourceManager о смерти врага
            }
        }
    }

    // ���������� ���������� �������� � ����� ������ (�������� � "HP=MaxHP;" � "void Start()")
    public void SetHP(float newHP) // "���������" �������� �� ���."Spawner"
    {
        HP = newHP; // ������������� "�����" ��������
    }

}
