﻿using UnityEditor;
using UnityEngine;
using Systems.Config;
using Systems.EntitySystem.Database;
using Systems.EntitySystem.Enumerations;

namespace Systems.EntitySystem.Editor
{
    public partial class EntityEditor : EditorWindow
    {
        [MenuItem("Window/Systems/Entity System/Entity Editor %#E")]
        static public void ShowWindow()
        {
            var window = GetWindow<EntityEditor>();
            window.minSize = new Vector2(SystemsConfig.EDITOR_MIN_WINDOW_WIDTH, SystemsConfig.EDITOR_MIN_WINDOW_HEIGHT);
            window.titleContent.text = "Entity Editor";
            window.Show();
        }

        private Vector2 scrollPosition;
        private int activeID;

        private GUIStyle _toggleButtonStyle;
        private GUIStyle ToggleButtonStyle
        {
            get
            {
                if (_toggleButtonStyle == null)
                {
                    _toggleButtonStyle = new GUIStyle(EditorStyles.toolbarButton);
                    ToggleButtonStyle.alignment = TextAnchor.MiddleLeft;
                }
                return _toggleButtonStyle;
            }
        }

        public void OnGUI()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            for (int i = 0; i < EntityDatabase.GetAssetCount(); i++)
            {
                EntityAsset asset = EntityDatabase.GetAt(i) as EntityAsset;
                if (asset != null)
                {
                    GUILayout.BeginHorizontal(EditorStyles.toolbar);
                    GUILayout.Label(string.Format("ID: {0}", asset.ID.ToString("D3")), GUILayout.Width(60));

                    bool clicked = GUILayout.Toggle(asset.ID == activeID, asset.Name, ToggleButtonStyle);

                    if (clicked != (asset.ID == activeID))
                    {
                        if (clicked)
                        {
                            activeID = asset.ID;
                            GUI.FocusControl(null);
                        }
                        else
                        {
                            activeID = -1;
                        }
                    }

                    if (GUILayout.Button("-", EditorStyles.toolbarButton, GUILayout.Width(30)) && EditorUtility.DisplayDialog("Delete Entity", "Are you sure you want to delete " + asset.Name + " Entity?", "Delete", "Cancel"))
                    {
                        EntityDatabase.Instance.RemoveAt(i);
                    }

                    GUILayout.EndHorizontal();

                    if (activeID == asset.ID)
                    {
                        EditorGUI.BeginChangeCheck();

                        //START OF SELECTED VIEW
                        GUILayout.BeginVertical("Box");  //a
                        GUILayout.BeginHorizontal();     //b

                        //SPRITE ON LEFT OF HORIZONTAL
                        GUILayout.BeginVertical(GUILayout.Width(75)); //c
                        GUILayout.Label("Entity Icon", GUILayout.Width(72));
                        asset.Icon = (Sprite)EditorGUILayout.ObjectField(asset.Icon, typeof(Sprite), false, GUILayout.Width(72), GUILayout.Height(72));
                        GUILayout.EndVertical();   //c

                        GUILayout.BeginVertical(); //d

                        GUILayout.BeginHorizontal();  //e
                        GUILayout.Label("Name", GUILayout.Width(80));
                        asset.Name = EditorGUILayout.TextField(asset.Name);
                        GUILayout.EndHorizontal();   //e

                        GUILayout.BeginHorizontal(); //f
                        GUILayout.Label("Description", GUILayout.Width(80));
                        asset.Description = EditorGUILayout.TextArea(asset.Description, GUILayout.MinHeight(50));
                        GUILayout.EndHorizontal(); //f

                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Entity Class", GUILayout.Width(80));
                        asset.EClass = (EntityType)EditorGUILayout.EnumPopup(asset.EClass);
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Player Type", GUILayout.Width(80));
                        asset.PType = (PlayerType)EditorGUILayout.EnumPopup(asset.PType);
                        GUILayout.EndHorizontal();
                        
                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Starting Level", GUILayout.Width(80));
                        asset.StartLevel = (int)EditorGUILayout.IntSlider(asset.StartLevel, 0, 99);
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Cost", GUILayout.Width(80));
                        asset.Cost = EditorGUILayout.IntField(asset.Cost);
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Locked", GUILayout.Width(80));
                        asset.Locked = EditorGUILayout.Toggle(asset.Locked);
                        GUILayout.EndHorizontal();

                        GUILayout.Space(10);

                        GUILayout.EndVertical();  //d
                        GUILayout.EndHorizontal();  //b

                        GUILayout.EndVertical();  //a

                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(EntityDatabase.Instance);
                        }
                    }
                }
            }

            GUILayout.EndScrollView();

            GUILayout.BeginHorizontal();
            GUITaskBar();
            GUILayout.EndHorizontal();
        }
        
        public void GUITaskBar()
        {
            if (GUILayout.Button("New Entity", EditorStyles.toolbarButton))
            {
                EntityDatabase.Instance.Add(new EntityAsset(EntityDatabase.Instance.GetNextId()));
            }
        }

    }
}