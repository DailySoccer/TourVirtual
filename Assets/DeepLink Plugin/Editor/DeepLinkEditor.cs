////////////////////////////////////////////////////////////////////////////////
//  
// @module Android DeepLink Plugin for Unity
// @author CausalLink Assets
// @support causallink.assets@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Xml;

class DeepLinkEditor : EditorWindow
{

    string string_scheme = "myapp";
    string string_host = "";
    bool groupEnabled;

    public bool first_time_load = true;

 
    MessageType t;
    string status;
    bool texts_changed = false;
    bool enable_btn_enabled = true;
    bool disable_btn_enabled = true;
    Color msg_color;

    GUIContent SupportEmail = new GUIContent("Support:", "Please let us know if you have any questions.");
    GUIContent PluginVersion = new GUIContent("Version:", "Current version.");

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/DeepLinkEditor")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(DeepLinkEditor));
    }

    void Awake()
    {

        first_time_load=EditorPrefs.GetBool("not_first_time");
        if (first_time_load != true)
        {
            string_host = PlayerSettings.bundleIdentifier;// "com.comp.rails";
            first_time_load = false;
            string_scheme = "myapp";
          
      
            EditorPrefs.SetBool("not_first_time", true);

            EditorPrefs.SetBool("enable_btn_enabled", true);
            EditorPrefs.SetBool("disable_btn_enabled", false);
            disable_btn_enabled = false;
            msg_color = Color.red;

        }
        else
        {
            string_host=EditorPrefs.GetString("host_str");
            string_scheme = EditorPrefs.GetString("scheme_str");
        

            enable_btn_enabled=EditorPrefs.GetBool("enable_btn_enabled");
            disable_btn_enabled=EditorPrefs.GetBool("disable_btn_enabled");
        }
    }

    bool ManifestFileExists()
    {
        if (File.Exists(Application.dataPath + "/Plugins/Android/AndroidManifest.xml"))
        {
            return true;
        }

        return false;
    }

    //bool DeepLinkBlockExists()
    //{
    //    //find the block with scheme and host

    //    // in the block check to make sure there is view,default, and browsable is on


    //    return false;
    //}

    void MakeBackup(XmlDocument doc)
    {
        Directory.CreateDirectory(Application.dataPath + "/DeepLink Plugin/ManifestBackup");
        doc.Save(Application.dataPath + "/DeepLink Plugin/ManifestBackup/AndroidManifest_" + System.DateTime.Now.ToString("MM_dd_yyyy")+"_"+System.DateTime.Now.ToString("hh_mm_ss")+".xml");
        AssetDatabase.Refresh();
    }
    bool DeepLinkExists()
    {
        XmlDocument ManifestFile = new XmlDocument();
        ManifestFile.Load(Application.dataPath + "/Plugins/Android/AndroidManifest.xml");
        XmlNodeList xnl = ManifestFile.GetElementsByTagName("data");


        foreach (XmlNode n in xnl)
        {

            if (n.Attributes["android:scheme"].Value.Equals(string_scheme) && n.Attributes["android:host"].Value.Equals(string_host))
            {
                n.ParentNode.RemoveAll();
                //break;
            }
            //Debug.Log(n.Attributes[0].Value);
        }

        return false;
    }

    
    void DisableDeepLink()
    {
        XmlDocument ManifestFile = new XmlDocument();
        ManifestFile.Load(Application.dataPath + "/Plugins/Android/AndroidManifest.xml");
        XmlNodeList xnl = ManifestFile.GetElementsByTagName("data");


        foreach (XmlNode n in xnl)
        {

            if (n.Attributes["android:scheme"].Value.Equals(EditorPrefs.GetString("scheme_str")) && n.Attributes["android:host"].Value.Equals(EditorPrefs.GetString("host_str")))
            {
                //n.ParentNode.RemoveAll();
                XmlNode myparent = n.ParentNode.ParentNode;
                myparent.RemoveChild(n.ParentNode);
                //break;
            }
            //Debug.Log(n.Attributes[0].Value);
        }

        ManifestFile.Save(Application.dataPath + "/Plugins/Android/AndroidManifest.xml");
        AssetDatabase.Refresh();
    }

    void AddDeepLinkDataBLock(XmlDocument doc)
    {
        MakeBackup(doc);
        XmlNodeList xnl = doc.GetElementsByTagName("action");
        string ns = "http://schemas.android.com/apk/res/android";

        foreach (XmlNode n in xnl)
        {
            if (n.Attributes["android:name"].Value.Equals("android.intent.action.MAIN"))
            {
                XmlElement intent_filter_node = doc.CreateElement("intent-filter");

                XmlElement action_node = doc.CreateElement("action");
                XmlElement category_node = doc.CreateElement("category");
                XmlElement category_node2 = doc.CreateElement("category");
                XmlElement data_node = doc.CreateElement("data");
                //XmlNode tmpnode = ManifestFile.CreateElement("THARAKA");
                n.ParentNode.ParentNode.AppendChild(intent_filter_node);

                intent_filter_node.AppendChild(action_node);
                intent_filter_node.AppendChild(category_node);
                intent_filter_node.AppendChild(category_node2);
                intent_filter_node.AppendChild(data_node);

                action_node.SetAttribute("name", ns, "android.intent.action.VIEW");
                category_node.SetAttribute("name", ns, "android.intent.category.DEFAULT");
                category_node2.SetAttribute("name", ns, "android.intent.category.BROWSABLE");

                data_node.SetAttribute("scheme", ns, string_scheme);
                data_node.SetAttribute("host", ns, string_host);
            }
            else
            {
                Debug.Log("android.intent.action.MAIN was not found");
            }

        }


        doc.Save(Application.dataPath + "/Plugins/Android/AndroidManifest.xml");
        AssetDatabase.Refresh();
    }

    void EditManifest()
    {
        XmlDocument ManifestFile = new XmlDocument();
        ManifestFile.Load(Application.dataPath + "/Plugins/Android/AndroidManifest.xml");

        XmlNode rootNode = ManifestFile.SelectSingleNode("/manifest/@package");
        rootNode.Value = PlayerSettings.bundleIdentifier;

        AddDeepLinkDataBLock(ManifestFile);

    }

    void CopyManifest()
    {

        if(File.Exists (Application.dataPath+"/Plugins/Android/AndroidManifest.xml"))
        {
           //Debug.Log("file exist!!");
           DisableDeepLink();
           EditManifest();

        }
        else
        {
            Directory.CreateDirectory (Application.dataPath+"/Plugins/Android");

            File.Copy(Application.dataPath + "/DeepLink Plugin/AndroidManifest.xml", Application.dataPath+"/Plugins/Android/AndroidManifest.xml", true);
            EditManifest();

            AssetDatabase.Refresh();


            //Debug.Log("file does not exist!!");
        }
    }

    void EnablePlugin()
    {
        enable_btn_enabled = false;
        disable_btn_enabled = true;
        EditorPrefs.SetString("host_str", string_host);
        EditorPrefs.SetString("scheme_str", string_scheme);

        EditorPrefs.SetBool("enable_btn_enabled", false);
        EditorPrefs.SetBool("disable_btn_enabled", true);


        texts_changed = false;
        CopyManifest();
    }

    void DisablePlugin()
    {
        
        if (ManifestFileExists())
        {
            DisableDeepLink();
        }

        enable_btn_enabled = true;
        disable_btn_enabled = false;
        EditorPrefs.SetBool("disable_btn_enabled", false);
        EditorPrefs.SetBool("enable_btn_enabled", true);
       
    }

    void UpdatePlugin()
    {
        
        if (ManifestFileExists())
        {
            DisableDeepLink();
            EditManifest();
        }
        EditorPrefs.SetString("host_str", string_host);
        EditorPrefs.SetString("scheme_str", string_scheme);
        texts_changed = false;
    }

    void OnFocus()
    {
        if (!ManifestFileExists())
        {
            DisablePlugin();
        }

    }

    void OnGUI()
    {

        GUILayout.Label("DeepLink Settings", EditorStyles.boldLabel);
        
        string_scheme = EditorGUILayout.TextField("Scheme", string_scheme);
        string_host = EditorGUILayout.TextField("Host", string_host);

        Color c = GUI.color;
        GUI.color = msg_color;
        EditorGUILayout.HelpBox(status, t);
        GUI.color = c;
       
      
        

        GUILayout.BeginHorizontal();
        //selected=GUILayout.SelectionGrid(selected, options, options.Length, EditorStyles.toolbarButton);


        GUI.enabled = enable_btn_enabled;

        if (string_host != EditorPrefs.GetString("host_str") || string_scheme != EditorPrefs.GetString("scheme_str"))
        {
            texts_changed=true;
        }



        if (GUILayout.Button("Enable", EditorStyles.toolbarButton, GUILayout.Width(80)))
        {
            EnablePlugin();
        }
        GUI.enabled = disable_btn_enabled;
        if (GUILayout.Button("Disable", EditorStyles.toolbarButton, GUILayout.Width(80)))
        {
            DisablePlugin();
        }

        if (enable_btn_enabled == true)
        {
            status = "DeepLinking Disabled";
            t = MessageType.Error;
        }
        if (disable_btn_enabled == true)
        {
            status = "DeepLinking Enabled";
            t = MessageType.Info;
        }


        GUI.enabled = true;

        if (texts_changed && enable_btn_enabled ==false)
        {
            //c = GUI.color;
            GUI.color = Color.green;
            if (GUILayout.Button("UPDATE", EditorStyles.toolbarButton, GUILayout.Width(80)))
            {
                UpdatePlugin();
            }

            GUI.color = c;

        }
   
        GUILayout.EndHorizontal();

        if (!texts_changed && enable_btn_enabled == false)
        {
            GUILayout.Label("App will open with", EditorStyles.boldLabel);

            EditorGUILayout.SelectableLabel(string_scheme + "://" + string_host);//
        }


        if (enable_btn_enabled == false)
        {
            msg_color = Color.green;
        }
        if (disable_btn_enabled == false)
        {
            msg_color = Color.red;
        }


        

        EditorGUILayout.HelpBox("About", MessageType.None);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(PluginVersion, GUILayout.Width(180), GUILayout.Height(16));
        EditorGUILayout.SelectableLabel("1.1", GUILayout.Height(16));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(SupportEmail, GUILayout.Width(180), GUILayout.Height(16));
        EditorGUILayout.SelectableLabel("causallink.assets@gmail.com", GUILayout.Height(16));
        EditorGUILayout.EndHorizontal();

    
   }
}


//<intent-filter>
//        <action android:name="android.intent.action.VIEW" />
//        <category android:name="android.intent.category.DEFAULT" />
//        <category android:name="android.intent.category.BROWSABLE" />

//        <!--Following line determins how your deeplink will look like, 
//            Your app will start with following URI, 
//            myapp://com.companyname.projectname
//            You may change these values-->

//        <data android:scheme="myapp" android:host="com.companyname.projectname"/>

//      </intent-filter>