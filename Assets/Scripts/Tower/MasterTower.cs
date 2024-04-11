using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Item")] // ������� ��� �������� ������ ScriptableObject ����� ����

public class MasterTower : ScriptableObject // ���������� ������ MasterTower, ������� ����������� �� ScriptableObject
{
    public Sprite TowerIcon; // ��������� ���� ��� ������� ������ �����
    public GameObject Tower; // ��������� ���� ��� ������� �����
    public int ID; // ��������� ���� ��� �������������� �����
}
