using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class QueststepSO : ScriptableObject {
    public float XpReward = 50;
    
    #if UNITY_EDITOR
    void OnValidate() {
         if (UID != 0) return;
        UID = Mathf.Abs(System.Guid.NewGuid().GetHashCode());
        UnityEditor.EditorUtility.SetDirty(this); 
    }
    #endif

    public string Scene;
    public string Description;
    [SerializeField] private int _id = 0;
    public int UID { get => _id; set => _id = value; }
    public List<ItemStack> ItemRewards = new();
    public int CurrencyRewards;

    public List<SceneObjects> DisabledObjects = new(); // List of UIDs that get disabled when step is completed
    public List<SceneObjects> EnabledObjects = new(); // List of UIDs that get enabled when step is completed

    #if UNITY_INCLUDE_TESTS
    public void TestInit(int index) {
        _id = index;
        Description = ((char)('a' + index)).ToString();
    }
    #endif
}

[Serializable]
public class SceneObjects
{
    public List<int> Objects;
    public string Scene;
}