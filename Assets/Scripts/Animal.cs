using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "Scriptable Objects/Animal")]
public class Animal : ScriptableObject
{
    public int id;
    public int health;
    public int strength;
    public string nama;
    [TextArea] public string deskripsi;
    public GameObject prefab;

}
