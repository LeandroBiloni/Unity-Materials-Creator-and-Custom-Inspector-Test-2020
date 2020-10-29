using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PositionLog))]
public class WaypointsInspector : Editor
{
    private PositionLog _targetLog;
    GUIStyle _labelStyle;
    FontStyle _font;
    private float _distance;
    private bool _createButton;
    private void OnEnable()
    {
        _font = new FontStyle();
        _font = FontStyle.Bold;
        _labelStyle = new GUIStyle();
        _labelStyle.normal.textColor = Color.red;
        _labelStyle.fontStyle = _font;
        _targetLog = (PositionLog)target;
        if (_targetLog.positions != null)
            _targetLog.positions.Clear();
        _targetLog.Start();
    }

    public override void OnInspectorGUI()
    {
        Options();
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);
        EditorGUILayout.Space();
        ShowPositions();
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);
        EditorGUILayout.Space();
        ShowWaypoints();
    }

    private void Options()
    {
        EditorGUILayout.BeginHorizontal();
        _distance = EditorGUILayout.FloatField("Record position after:", _distance);
        _targetLog.distance = _distance;
        EditorGUILayout.LabelField("units.");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);

        EditorGUILayout.Space();

        //Las posiciones guardadas las convierto en waypoints del player
        EditorGUILayout.LabelField("Create Waypoints with the recorded positions.", _labelStyle);
        _createButton = GUILayout.Button("Create");
        if (_createButton)
        {
            foreach (var position in _targetLog.positions)
            {
                _targetLog.player.waypoints.Add(position);
            }
            _createButton = false;
        }

        EditorGUILayout.Space();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);

        EditorGUILayout.Space();

        //Limpio la lista de posiciones (por ej por si quiero cambiar la distancia de guardado y guardar nuevas posiciones)
        EditorGUILayout.LabelField("Clear all the recorded positions (not waypoints).", _labelStyle);
        bool clearButton = GUILayout.Button("Clear Positions");
        if (clearButton)
            _targetLog.positions.Clear();

        EditorGUILayout.Space();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);

        EditorGUILayout.Space();

        //Limpio la lista de waypoints
        EditorGUILayout.LabelField("Clear all the recorded waypoints.", _labelStyle);
        bool clearWaypoints = GUILayout.Button("Clear Waypoints");
        if (clearWaypoints)
            _targetLog.player.waypoints.Clear();
    }

    private void ShowPositions()
    {
        EditorGUILayout.LabelField("Recorded Positions", _labelStyle);
        EditorGUILayout.Space();
        for (int i = 0; i < _targetLog.positions.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Pos " + i + ":");
            EditorGUILayout.LabelField("X: " + _targetLog.positions[i].x + " Y: " + _targetLog.positions[i].y + " Z: " + _targetLog.positions[i].z);
            EditorGUILayout.EndHorizontal();
        }
    }

    private void ShowWaypoints()
    {
        EditorGUILayout.LabelField("Recorded Waypoints", _labelStyle);
        EditorGUILayout.Space();
        for (int i = 0; i < _targetLog.player.waypoints.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Waypoint " + i + ":");
            EditorGUILayout.LabelField("X: " + _targetLog.player.waypoints[i].x + " Y: " + _targetLog.player.waypoints[i].y + " Z: " + _targetLog.player.waypoints[i].z);
            EditorGUILayout.EndHorizontal();
        }
    }
}
