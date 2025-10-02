using System;
using UnityEditor;
using UnityEngine;

namespace Shoelace.SOVariables.Editor
{
    [CustomEditor(typeof(SONumericVariable<>), true)]
    public class NumericVariableEditor : UnityEditor.Editor
    {
        SerializedProperty valueProp;
        SerializedProperty readOnlyProp;
        SerializedProperty debuggingProp;

        SerializedProperty useMinClampProp;
        SerializedProperty minProp;

        SerializedProperty useMaxClampProp;
        SerializedProperty maxProp;

        void OnEnable()
        {
            valueProp = serializedObject.FindProperty("value");
            readOnlyProp = serializedObject.FindProperty("readOnly");
            debuggingProp = serializedObject.FindProperty("debugging");

            useMinClampProp = serializedObject.FindProperty("useMinClamp");
            minProp = serializedObject.FindProperty("minClamp");

            useMaxClampProp = serializedObject.FindProperty("useMaxClamp");
            maxProp = serializedObject.FindProperty("maxClamp");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(valueProp);
            EditorGUILayout.PropertyField(readOnlyProp);
            EditorGUILayout.PropertyField(debuggingProp);
            

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Clamp Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(useMinClampProp);
            if (useMinClampProp.boolValue)
                EditorGUILayout.PropertyField(minProp, GUIContent.none);

            EditorGUILayout.PropertyField(useMaxClampProp);
            if (useMaxClampProp.boolValue)
                EditorGUILayout.PropertyField(maxProp, GUIContent.none);

            if(useMinClampProp.boolValue && useMaxClampProp.boolValue)
            {
                if (target is SONumericVariable<float> floatVar)
                {
                    DrawProgressBar(floatVar.GetNormalizedValue());
                }
                if(target is SONumericVariable<int> intVar)
                {
                    DrawProgressBar(intVar.GetNormalizedValue());
                }
               
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawProgressBar(float progress)
        {
            Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(rect, progress, "Normalized Value");
            EditorGUILayout.Space(10);
        }
    }
}