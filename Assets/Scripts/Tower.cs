using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    public float Radius, FireDelay, Damage; // ������ ��������, �������� ��������, ������� ����������� (����)
    public LayerMask EnemyLayer; // ���� ������ (��� �� ������/�����������)
    public Transform BulletPrefab; // ���������/������ �� ������ �������
    private float timeToFire; // ����� �� ��������
    private Transform gun, enemy, firePoint; // ������ �� ���������� ��������

    void Start()
    {
        timeToFire = FireDelay; // �������������� ����� �� �������� (timeToFire) �� ��������� (FireDelay)
        gun = transform.GetChild(0); // ������ �� ���������� ������ (1-� �������� ������ �������-������� "Tower")
        firePoint = gun.GetChild(0); // ������ �� ���������� ������� (1-� �������� ������ ������� "Gun")
    }

    void Update()
    {
        if (timeToFire > 0)
            timeToFire -= Time.deltaTime; // ������ ������ (���������� ���������� �������)
        else if (enemy) // ���� ���� ��������� � ��������/������� ��������/��������
            Fire(); // ������ �������

        if (enemy) // ���� ���� � ��������/������� ��������/��������
        {
            Vector3 lookAt = enemy.position; // ��������� ������� �����
            lookAt.y = gun.position.y; // �������� ���������� "Y" ����� �� ���������� "Y" ������,
                                       // ����� �� ������������ ������ �� ��� "Y" (�� ������)
            gun.rotation = Quaternion.LookRotation(lookAt - gun.position); // ������������ ������
                                                                           //Vector3 dir = Vector3.RotateTowards(gun.transform.forward, lookAt - gun.position, Time.deltaTime * 5, 0);
                                                                           //gun.rotation = Quaternion.LookRotation (dir); // ������� ������� ������

            if (Vector3.Distance(transform.position, enemy.position) > Radius) // ���� ���� �� ��������� ��������
                                                                               // "Vector3.Distance" - ��������� ���������� ����� ����������� (����� � �����)
                                                                               // "transform.position" - ���������� �����
                                                                               // "enemy.position" - ���������� �����
                enemy = null; // �������� ������ �� ���� ��� ������� �����
        }
        else if (enemy == null) // ���� ������ �� ����� ���
        {
            Collider[] coll = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);
            // ������ ����� "Physics.OverlapSphere" ��� ������ ������ �� ���� ����������� ������
            // "transform.position" - ����� �����, "Radius" - ������ �����, "EnemyLayer" ����� � ������������ �� ���� "Enemy"
            // "coll" - ������ ��������� ����������� ������ ���� "Enemy"

            if (coll.Length > 0) // ���� ���������� ������ �������
                enemy = coll[0].transform; // ��������� ���������� 1-�� ���������� �����
        }
    }

    void Fire() // ������ �������
    {
        Transform bullet = Instantiate(BulletPrefab, firePoint.position, Quaternion.identity); // ������ ������

        bullet.LookAt(enemy.GetChild(0)); // ������ "�������" �� ����� ��."Capsule" �����
        bullet.GetComponent<Bullet>().Damage = Damage; // ���������� ���� ����� � ���� ������� (�������������� ���������� "Damage" ������� "Bullet")

        timeToFire = FireDelay; // ��������������� ����� �� ��������
    }
}
