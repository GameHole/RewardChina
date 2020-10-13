using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.ProjectWindowCallback;
using System.Text.RegularExpressions;
using System.Text;
using UnityEditor.Callbacks;
[InitializeOnLoad]
public class EntitiesEditor : MonoBehaviour
{
    /*
        1.快捷键
        % - CTRL 在Windows / CMD在OSX
        # - Shift
        & - Alt
        LEFT/RIGHT/UP/DOWN-光标键
        F1…F12
        HOME,END,PGUP,PDDN 
     */

    //[MenuItem("Assets/Create/SimpleEntities/Component/ControlComponent #R")]
    //public static void CreateControlCmpScript()
    //{
    //    var path = AssetDatabase.GUIDToAssetPath("5a4f567469c13e540a86f8fced1d83bf");
    //    ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
    //    ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
    //    GetSelectedPathOrFallback() + "/NewComponent.cs", null, path);
    //}
    [MenuItem("Assets/Create/Interface",false,1)]
    public static void CreateCmpScript()
    {
        var path = AssetDatabase.GUIDToAssetPath("2ab4c1d5848abc845a9a47d7276209a8");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
        GetSelectedPathOrFallback() + "/NewInterface.cs", null, path);
    }
    //[MenuItem("Assets/Create/SimpleEntities/Component/ComponentProvider #Q")]
    //public static void CreateCmpProviderScript()
    //{
    //    var path = AssetDatabase.GUIDToAssetPath("65b4689b4dc1a5b4da96cf422ba631fb");
    //    ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
    //    ScriptableObject.CreateInstance<MyDoCreateAdaptorScriptAsset>(),
    //    GetSelectedPathOrFallback() + "/NewComponent.cs", null, path);
    //}
    //[MenuItem("Assets/Create/SimpleEntities/Component/LinkComponentProvider #E")]
    //public static void CreateCmpLinkProviderScript()
    //{
    //    var path = AssetDatabase.GUIDToAssetPath("0d48b5c3f8939dd41a77658ec87f6fd8");
    //    ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
    //    ScriptableObject.CreateInstance<MyDoCreateAdaptorScriptAsset>(),
    //    GetSelectedPathOrFallback() + "/NewLinkComponent.cs", null, path);
    //}
    //[MenuItem("Assets/Create/SimpleEntities/System/ControlSystem<..> #A")]
    //public static void CreateUpdateG1Script()
    //{
    //    var path = AssetDatabase.GUIDToAssetPath("fa566025cb6dcab4cad5cb9a09c96dcd");
    //    ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
    //    ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
    //    GetSelectedPathOrFallback() + "/NewSystem.cs", null, path);
    //}
    //[MenuItem("Assets/Create/SimpleEntities/System/AsyncSystem<..> #W")]
    //public static void CreateAsyncUpdateG1Script()
    //{
    //    var path = AssetDatabase.GUIDToAssetPath("52bcb8515cf86b545a98f1ff25df2eb1");
    //    ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
    //    ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
    //    GetSelectedPathOrFallback() + "/NewAsyncSystem.cs", null, path);
    //}
    //[MenuItem("Assets/Create/SimpleEntities/ShareComponent")]
    //public static void CreateShareComponentScript()
    //{
    //    var path = AssetDatabase.GUIDToAssetPath("2aca1f47fa02ac0459c1395769f2e07f");
    //    ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
    //    ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
    //    GetSelectedPathOrFallback() + "/NewShareComponent.cs", null, path);
    //}
   
    public static string GetSelectedPathOrFallback()
    {
        string path = "Assets";
        foreach (Object obj in Selection.GetFiltered< Object >(SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }
    static EntitiesEditor()
    {
        string[] guids = AssetDatabase.FindAssets("namespace");
        if (guids.Length > 0)
        {
            nameSpace = File.ReadAllText(AssetDatabase.GUIDToAssetPath(guids[0]));
        }
        //SetOrder("095a6725417571149bf564fb1e5f61f1", -200);
    }
    static void SetOrder(string guid, int order)
    {
        var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(AssetDatabase.GUIDToAssetPath(guid));
        if (MonoImporter.GetExecutionOrder(mono) != order)
            MonoImporter.SetExecutionOrder(mono, order);
    }
    public readonly static string nameSpace = "Default";
}


class MyDoCreateScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(o);
    }

    internal static Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
    {
       
        string fullPath = Path.GetFullPath(pathName);
        //StreamReader streamReader = new StreamReader(resourceFile);
        string text = File.ReadAllText(resourceFile);// streamReader.ReadToEnd();
        //streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
        streamWriter.Write(text);
        streamWriter.Close();
        AssetDatabase.ImportAsset(pathName);
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
    }
}
class MyDoCreateAdaptorScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(o);
    }

    internal static Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
    {

        string fullPath = Path.GetFullPath(pathName);
        fullPath = fullPath.Replace(".cs", "Provider.cs");
        //StreamReader streamReader = new StreamReader(resourceFile);
        string text = File.ReadAllText(resourceFile);// streamReader.ReadToEnd();
        //streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
        pathName = pathName.Replace(".cs", "Provider.cs");
        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
        streamWriter.Write(text);
        streamWriter.Close();
        AssetDatabase.ImportAsset(pathName);
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
    }
}