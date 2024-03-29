using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Scriptable Item")]

public class BaseTower : ScriptableObject
{
    public float Radius, FireDelay, Damage;
    public Transform BulletPrefab;
    public Sprite TowerIcon;
    public GameObject Tower;
}
