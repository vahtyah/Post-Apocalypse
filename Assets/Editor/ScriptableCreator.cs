#if UNITY_EDITOR

using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

public class ScriptableCreator : OdinMenuEditorWindow
{
    [MenuItem("Tools/Scriptable Creator")]
    private static void Open()
    {
        var window = GetWindow<ScriptableCreator>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree(true);
        tree.DefaultMenuStyle.IconSize = 28.00f;
        tree.Config.DrawSearchToolbar = true;
        tree.Add("Projectile", new CreateNewScriptableObject<ProjectileData>());
        tree.Add("Level", new CreateNewScriptableObject<LevelData>());
        // tree.Add("Enemy", new CreateNewScriptableObject<EnemyData>());
        tree.AddAllAssetsAtPath("Projectile", "Assets/_Project/Scripts/ScriptableObjects/Projectiles", typeof(ProjectileData), true, true);
        tree.AddAllAssetsAtPath("Level", "Assets/_Project/Scripts/ScriptableObjects/Levels", typeof(LevelData), true, true);
        tree.AddAllAssetsAtPath("Enemies", "Assets/_Project/Scripts/ScriptableObjects/Enemies", typeof(EnemyData), true, true);

        // tree.EnumerateTree().AddIcons<ItemData>(x => x.Icon);
        return tree;
    }

    protected override void OnBeginDrawEditors()
    {
        var selected = this.MenuTree.Selection.FirstOrDefault();
        var toolbarHeight = this.MenuTree.Config.SearchToolbarHeight;

        SirenixEditorGUI.BeginHorizontalToolbar(toolbarHeight);
        {
            if (selected != null)
            {
                GUILayout.Label(selected.Name);
            }
            
            if (SirenixEditorGUI.ToolbarButton(new GUIContent("Create Enemy")))
            {
                ScriptableObjectCreator.ShowDialog<EnemyData>("Assets/_Project/Scripts/ScriptableObjects/Enemies", obj =>
                {
                    // obj.Name = obj.name;
                    base.TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }

        
            if (SirenixEditorGUI.ToolbarButton(new GUIContent("Delete Current")))
            {
                if (selected != null)
                {
                    if (selected.Value is UnityEngine.Object selectedObject)
                    {
                        AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(selectedObject));
                    }
                    base.TrySelectMenuItemWithObject(null);
                }
            }
        }
        SirenixEditorGUI.EndHorizontalToolbar();
    }

    public class CreateNewScriptableObject<T> where T : ScriptableObject
    {
        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public T Value = CreateInstance<T>();

        [Button("Create")]
        private void Create()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save ScriptableObject", typeof(T).Name + ".asset",
                "asset",
                "Please enter a file name to save the ScriptableObject to", $"Assets/_Project/Scriptable/{typeof(T).Name}s");

            if (path.Length > 0)
            {
                AssetDatabase.CreateAsset(this.Value, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Selection.activeObject = this.Value;
            }
        }
    }
}

#endif