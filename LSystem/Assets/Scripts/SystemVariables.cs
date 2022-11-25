using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "L-System", menuName = "L-System/New L-System", order = 1)]
public class SystemVariables : ScriptableObject
{

    public int iterations;
    public float angle;
    public string axiom;
    [SerializeField]
    public List<Dictionary<string, object>> keys = new List<Dictionary<string, object>>();
    [SerializeField]
    public List<Rules> rules = new List<Rules>();
  
}
[System.Serializable]
public class Rules
{
    public char letter;
    public string substitution;
}
