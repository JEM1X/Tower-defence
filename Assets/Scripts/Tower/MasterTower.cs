using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Item")] // Атрибут для создания нового ScriptableObject через меню

public class MasterTower : ScriptableObject // Объявление класса MasterTower, который наследуется от ScriptableObject
{
    public Sprite TowerIcon; // Публичное поле для спрайта иконки башни
    public GameObject Tower; // Публичное поле для объекта башни
    public int ID; // Публичное поле для идентификатора башни
}
