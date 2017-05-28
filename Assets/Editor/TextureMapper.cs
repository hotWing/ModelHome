using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TextureMapper : EditorWindow 
{
    private static List<Transform> transforms;
    private static string texSubFolder = "";
    private static string shaderPath = "Legacy Shaders/Lightmapped/Diffuse";
    private static Shader shader;
    //private static string texSubFolder;
    [MenuItem("彼慕插件/自动材质...",false,1)]
    private static void showWindow()
    {
        //if (Selection.gameObjects.ToList().Count != 1)
        //{
        //    EditorUtility.DisplayDialog("选择数量不对！", "请单选一个GameObject!", "确定");
        //    return;
        //}

        EditorWindow.GetWindow<TextureMapper>(false, "自动材质");
        
        if (Selection.activeGameObject != null)
            transforms = getAllTransforms(Selection.activeGameObject.transform);

        shader = Shader.Find(shaderPath);

        //bool start = EditorUtility.DisplayDialog("确认", "一共有"+transforms.Count+"个模型需要贴材质，确认继续？", "确定","取消");
        //if (start)
        //{
        //    foreach(Transform trans in transforms)
        //    {
        //        setLightMap(trans);
        //    }
        //}
        //SceneView.RepaintAll();
    }

    private static List<Transform> getAllTransforms(Transform trans)
    {
        List<Transform> res = new List<Transform>();
        if (hasRenderer(trans))
            res.Add(trans);
        foreach (Transform transform in trans)
        {
            res.AddRange(getAllTransforms(transform));
        }
        return res;
        
    }

    void OnSelectionChange()
    {
        if (Selection.activeGameObject != null)
            transforms = getAllTransforms(Selection.activeGameObject.transform);

        shader = Shader.Find(shaderPath);
    }

    void OnGUI()
    {
        string nameSelected = "";
        if (Selection.activeTransform != null)
            nameSelected = Selection.activeTransform.name;

        EditorGUILayout.LabelField("选择的模型: ", nameSelected);

        texSubFolder = EditorGUILayout.TextField("材质文件夹: Textures\\", texSubFolder);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("确定", GUILayout.Width(100)) && Selection.activeTransform != null)
            {
                string temSubFoleder = texSubFolder;
                if (!string.IsNullOrEmpty(temSubFoleder))
                    temSubFoleder = temSubFoleder + "\\";

                for (int i = 0; i < transforms.Count; i++)
                {
                    Transform trans = transforms[i];

                    if (EditorUtility.DisplayCancelableProgressBar("进度", "正在处理:" + trans.name, (float)i / transforms.Count))
                    {
                        break;
                    }

                    setLightMap(trans, "Assets\\Textures\\" + temSubFoleder);
                }
                EditorUtility.ClearProgressBar();
                EditorUtility.DisplayDialog("自动贴图","完成！","确定");
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        this.Repaint();
    }

    //private static bool hasLightMap(Transform go)
    //{
    //    Renderer renderer = go.GetComponent<Renderer>();
    //    if(renderer == null)
    //        return false;
    //    Material mat = renderer.sharedMaterial;
    //    if (mat == null)
    //        return false;
    //    return mat.HasProperty("_LightMap");
    //}

    private static bool hasRenderer(Transform go)
    {
        Renderer renderer = go.GetComponent<Renderer>();
        return renderer != null;
        
        //Material mat = renderer.sharedMaterial;
        //return mat != null;
    }


    private static void setLightMap(Transform trans, string texFolder)
    {
        Material mat = new Material(shader);
        string matPath = "Assets/Materials/" + trans.name + ".mat";
        if(!string.IsNullOrEmpty(texSubFolder))
        {
            string folder = "Assets/Materials/" + texSubFolder;
            if (!AssetDatabase.IsValidFolder(folder))
                AssetDatabase.CreateFolder("Assets/Materials", texSubFolder);
            matPath = folder + "/" + trans.name + ".mat";
        }

        AssetDatabase.CreateAsset(mat, matPath);
        Renderer renderer = trans.GetComponent<Renderer>();
        renderer.sharedMaterial = mat;
        //Material mat = renderer.sharedMaterial;
        //mat.shader = Shader.Find(shaderPath);
        Texture tex = AssetDatabase.LoadAssetAtPath<Texture>(texFolder + trans.name + "VRay 全部灯光贴图.jpg");
        mat.SetTexture("_LightMap", tex);
    }
}
