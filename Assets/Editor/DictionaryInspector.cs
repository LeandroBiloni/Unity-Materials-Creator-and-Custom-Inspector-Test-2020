using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class DictionaryInspector : Editor
{
    private Player _player;
    private int _currentPlayer;
    private List<string> _keyList;
    private List<string> _valueList;
    private void OnEnable()
    {
        _player = (Player)target;
        _player.mageDictionary.Clear();
        _player.healerDictionary.Clear();
        _player.warriorDictionary.Clear();
        _player.StartDictionary();
    }

    public override void OnInspectorGUI()
    {
        ShowDictionary();
    }


    private void ShowDictionary()
    {
        _currentPlayer = EditorGUILayout.Popup("Actual Player: ", _currentPlayer, _player.charName);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(_player.charName[_currentPlayer] + " dictionary.", EditorStyles.boldLabel);     
        EditorGUILayout.EndHorizontal();
        if (_keyList == null)
            _keyList = new List<string>();
        else _keyList.Clear();

        if (_valueList == null)
            _valueList = new List<string>();
        else _valueList.Clear();
        

        foreach (string key in _player.dictionaryArray[_currentPlayer].Keys)
        {
            _keyList.Add(key);
        }

        foreach (string value in _player.dictionaryArray[_currentPlayer].Values)
        {
            _valueList.Add(value);
        }

        for (int i = 0; i < _keyList.Count; i++)
        {
            EditorGUILayout.LabelField("Entry " + i + ":");
            EditorGUILayout.LabelField(_keyList[i] + "/" + _valueList[i]);
        }
    }
}
