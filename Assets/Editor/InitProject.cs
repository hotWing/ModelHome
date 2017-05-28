using UnityEngine;
using UnityEditor;

public class InitProject : EditorWindow  {

    [MenuItem("彼慕插件/初始化项目",false,0)]
	private static void Start () {
        //string guid = AssetDatabase.CreateFolder("Assets", "My Folder");
        //string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        if(!AssetDatabase.IsValidFolder("Assets\\Scenes"))
            AssetDatabase.CreateFolder("Assets", "Scenes");

        if (!AssetDatabase.IsValidFolder("Assets\\Models"))
            AssetDatabase.CreateFolder("Assets", "Models");

        if (!AssetDatabase.IsValidFolder("Assets\\Materials"))
            AssetDatabase.CreateFolder("Assets", "Materials");

        if (!AssetDatabase.IsValidFolder("Assets\\Textures"))
            AssetDatabase.CreateFolder("Assets", "Textures");

        if (!AssetDatabase.IsValidFolder("Assets\\Scripts"))
            AssetDatabase.CreateFolder("Assets", "Scripts");

        if (!AssetDatabase.IsValidFolder("Assets\\Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Prefabs");
	}
}
