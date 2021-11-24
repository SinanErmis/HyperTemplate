using System;
using Rhodos.Core;
using Rhodos.Toolkit.Extensions;
using UnityEditor;
using UnityEngine;

namespace Rhodos.Editor
{
    [CustomEditor(typeof(GameManager))]
    public class GameManagerEditor : UnityEditor.Editor
    {
        private SerializedProperty _canPlay;
        private SerializedProperty _managers;
        private SerializedProperty _assets;
        private SerializedProperty _references;
        private GameManager _gameManager;
        private GameManager.GameType _gameTypeCache;
        private void OnEnable()
        {
            _canPlay = serializedObject.FindProperty("canPlay");
            _managers = serializedObject.FindPropertyByAutoPropertyName("Managers");
            _assets = serializedObject.FindPropertyByAutoPropertyName("Assets");
            _references = serializedObject.FindPropertyByAutoPropertyName("References");
            _gameManager = FindObjectOfType<GameManager>();
            _gameTypeCache = _gameManager.gameType;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawCanPlayToggle();
            
            EditorGUILayout.Space();
            
            DrawGameTypeEnum();
            
            EditorGUILayout.Space();
            
            DrawSerializableClasses();
            
            serializedObject.ApplyModifiedProperties();
        }
        
        private void DrawGameTypeEnum()
        {
            _gameManager.gameType = (GameManager.GameType) EditorGUILayout.EnumPopup("Game Type", _gameManager.gameType);
            
            if (_gameTypeCache == _gameManager.gameType) return;
            _gameTypeCache =  _gameManager.gameType;

            if (_gameManager.gameType == GameManager.GameType.UniqueLevels)
            {
                _gameManager.Managers.LevelManager.gameObject.SetActive(true);
                _gameManager.Managers.MechanicManager.isGameTypeUniqueMechanics = false;
            }
            else
            {
                _gameManager.Managers.LevelManager.gameObject.SetActive(false);
                _gameManager.Managers.MechanicManager.isGameTypeUniqueMechanics = true;
            }
        }

        private void DrawSerializableClasses()
        {
            EditorGUILayout.PropertyField(_managers  , new GUIContent("Managers"  ));
            EditorGUILayout.PropertyField(_assets    , new GUIContent("Assets"    ));
            EditorGUILayout.PropertyField(_references, new GUIContent("References"));
        }

        private void DrawCanPlayToggle()
        {
            _canPlay.boolValue =
                EditorGUILayout.Toggle(new GUIContent("Take Input",
                        "When it's true, Mechanic Manager starts taking input and calling active mechanic's corresponding methods."),
                    _canPlay.boolValue);
        }
    }
}