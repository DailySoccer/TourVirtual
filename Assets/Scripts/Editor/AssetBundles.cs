using UnityEditor;
using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class CreateAssetBundles {
	public const string ASSET_BUNDLES_JSON = "assetbundles.json";
    public const string ANDROID_FOLDER = "Assets/WebPlayerTemplates/AssetBundles/Android";
    public const string WINDOWS_FOLDER = "Assets/WebPlayerTemplates/AssetBundles/Windows";    
    public const string IOS_FOLDER = "Assets/WebPlayerTemplates/AssetBundles/iOS";
	public const BuildAssetBundleOptions BundleOptions = BuildAssetBundleOptions.None;

	[MenuItem ("Assets/AssetBundles/Clean Cache")]
	static void CleanCache () {
		Caching.CleanCache();
	}

	[MenuItem ("Assets/AssetBundles/Assets List")]
	static void GetNames ()	{
		foreach (var name in AssetDatabase.GetAllAssetBundleNames()) {
			string[] assets = AssetDatabase.GetAssetPathsFromAssetBundle(name);
			if (assets.Length > 0) {
				string info = "AssetBundle: " + name + " Count: " + assets.Length + "\n";
				foreach(var asset in assets) {
					info += asset + "\n";
				}
				Debug.Log (info);
			}
		}
	}

    [MenuItem("Assets/AssetBundles/Build Android")]
    static void BuildAllAssetBundles_Android()
    {
        // FIX: crash en Unity, cuando BuildAssetBundles sin cargar el escenario anteriormente
        if (OpenScenesBefore())
        {
            string basePath = Application.dataPath.Remove(Application.dataPath.IndexOf("/Assets"));
            System.IO.Directory.CreateDirectory(basePath + "/" + ANDROID_FOLDER);
            BuildPipeline.BuildAssetBundles(ANDROID_FOLDER, BundleOptions, BuildTarget.Android);

            Debug.Log(">>>> " + ANDROID_FOLDER + "/Android.manifest");
            Debug.Log( ">>>> " + AssetDatabase.AssetPathToGUID(ANDROID_FOLDER + "/Android.manifest") );
            //CreateVersionJSON(basePath + "/" + ANDROID_FOLDER, Application.dataPath + "/Resources/Android/" + ASSET_BUNDLES_JSON);
            CreateVersionJSON(basePath + "/" + ANDROID_FOLDER, "Assets/WebPlayerTemplates/AssetBundles/Android/" + ASSET_BUNDLES_JSON);
        }
    }
    [MenuItem("Assets/AssetBundles/Build Windows")]
    static void BuildAllAssetBundles_Windows()
    {
        // FIX: crash en Unity, cuando BuildAssetBundles sin cargar el escenario anteriormente
        if (OpenScenesBefore())
        {
            string basePath = Application.dataPath.Remove(Application.dataPath.IndexOf("/Assets"));
            System.IO.Directory.CreateDirectory(basePath + "/" + WINDOWS_FOLDER);
            BuildPipeline.BuildAssetBundles(WINDOWS_FOLDER, BundleOptions, BuildTarget.WSAPlayer);
            //CreateVersionJSON(basePath + "/" + WINDOWS_FOLDER, Application.dataPath + "/Resources/Windows/" + ASSET_BUNDLES_JSON);
            CreateVersionJSON(basePath + "/" + WINDOWS_FOLDER, "Assets/WebPlayerTemplates/AssetBundles/Windows/" + ASSET_BUNDLES_JSON);

        }
    }

    [MenuItem ("Assets/AssetBundles/Build iOS")]
	static void BuildAllAssetBundles_iOS () {
		// FIX: crash en Unity, cuando BuildAssetBundles sin cargar el escenario anteriormente
		if (OpenScenesBefore()) {
			string basePath = Application.dataPath.Remove (Application.dataPath.IndexOf("/Assets"));
			System.IO.Directory.CreateDirectory(basePath + "/" + IOS_FOLDER);
			BuildPipeline.BuildAssetBundles (IOS_FOLDER, BundleOptions, BuildTarget.iOS);
//			CreateVersionJSON(basePath + "/" + IOS_FOLDER, Application.dataPath + "/Resources/iOS/" + ASSET_BUNDLES_JSON);
            CreateVersionJSON(basePath + "/" + IOS_FOLDER, "Assets/WebPlayerTemplates/AssetBundles/iOS/" + ASSET_BUNDLES_JSON);

        }
    }

	static bool OpenScenesBefore() {
		bool ok = EditorApplication.SaveCurrentSceneIfUserWantsTo();

		if (ok) {
			string currentScene = EditorApplication.currentScene;
			foreach (var name in AssetDatabase.GetAllAssetBundleNames()) {
				string[] assets = AssetDatabase.GetAssetPathsFromAssetBundle(name);
				foreach(var asset in assets) {
					if (asset.Contains(".unity")) {
						EditorApplication.OpenScene(asset);
					}
				}
			}

			if (!EditorApplication.currentScene.Equals(currentScene)) {
				EditorApplication.OpenScene(currentScene);
			}
		}

		return ok;
	}

	static void CreateVersionJSON(string assetBundlesPath, string sitemapPath) {
		Dictionary<string, string> manifestHashes =  GetManifestHashes(assetBundlesPath); // GetManifestHashesFromAssetBundles(path);
		string sitemapText = System.IO.File.Exists(sitemapPath) ? System.IO.File.ReadAllText(sitemapPath) : "";

		if (string.IsNullOrEmpty(sitemapText)) {
			Debug.Log ("Creating... " + sitemapPath);

			StringBuilder text = new StringBuilder();

			text.Append("{\n" + "\"assets\"" + ":\n [\n");
			List<string> assets = new List<string>();
			foreach(KeyValuePair<string, string> entry in manifestHashes) {
				assets.Add (string.Format("{{ \"id\": \"{0}\",\t\t\"hash\": \"\",\t\t\"version\": 0,\t\t\"date\": \"\" }}", entry.Key));
			}
			text.Append (string.Join (",\n", assets.ToArray()));

			text.Append ("\n]\n}");

			sitemapText = text.ToString();
		}

		Debug.Log ("AssetBundles: Version JSON: " + sitemapPath);

		string datePatt = @"d/M/yyyy hh:mm:ss tt";
		
		foreach(KeyValuePair<string, string> entry in manifestHashes) {
			Match hashMatch = new Regex(@".id.:\s*." + entry.Key + @".,\s*.hash.:\s*.(\w*).").Match(sitemapText);
			if (hashMatch.Success) {
				// Si el hash no coincide con el del manifest
				if (!hashMatch.Groups[1].Value.Equals(entry.Value)) {
					Match versionMatch = new Regex(@".id.:\s*." + entry.Key + @".,\s*.hash.:\s*.\w*.*version.:\s*(\d*)").Match(sitemapText);
					if (versionMatch.Success) {
						// Subimos la versión
						int version = Int32.Parse(versionMatch.Groups[1].Value) + 1;

						// Modificamos el texto con el nuevo hash y versión
						sitemapText = new Regex(@".id.:\s*." + entry.Key + @".,\s*.hash.:\s*.(?<hash>\w*).").ReplaceGroup(sitemapText , "hash", entry.Value);
						sitemapText = new Regex(@".id.:\s*." + entry.Key + @".,\s*.hash.:\s*.\w*.*version.:\s*(?<version>\d*).").ReplaceGroup(sitemapText , "version", version.ToString());
						sitemapText = new Regex(@".id.:\s*." + entry.Key + @".,\s*.hash.:\s*.\w*.*version.:\s*\d*.*date.:\s*.(?<date>[A-Z0-9:\s\/]*).\s*}").ReplaceGroup(sitemapText , "date", DateTime.Now.ToString(datePatt));

						Debug.Log (entry.Key + ": Hash: " + entry.Value + " Version: " + version.ToString() + " Date: " + DateTime.Now.ToString(datePatt));
					}
				}
			}
			else {
				string newAsset = string.Format(",\n{{ \"id\": \"{0}\",\t\t\"hash\": \"{1}\",\t\t\"version\": 1,\t\t\"date\": \"{2}\" }}\n", entry.Key, entry.Value, DateTime.Now.ToString(datePatt));
				sitemapText = new Regex(@"}(?<insert>\s)\s*]\s*}").ReplaceGroup(sitemapText , "insert", newAsset);
				Debug.Log("+ Asset Bundle: " + newAsset);
			}
		}

		System.IO.StreamWriter file = new System.IO.StreamWriter(sitemapPath);
		file.WriteLine(sitemapText);
		file.Close();
	}

	static Dictionary<string, string> GetManifestHashes(string path) {
		Dictionary<string, string> manifestHashes = new Dictionary<string, string>();
        var files = GetManifestFiles(path);
        foreach (string tfile in files) {
            var file = tfile.Replace('\\', '/');
            string text = System.IO.File.ReadAllText(file);
			Match bundleNameMatch = new Regex(@"AssetBundles\/(?:Android|iOS|Windows)\/(.*)\.manifest$").Match(file);
			Match hashMatch = new Regex(@"\bAssetFileHash\b:\s*serializedVersion:\s*\d*\s*Hash:\s(\w*)").Match(text);
            if (bundleNameMatch.Success && hashMatch.Success) {
				manifestHashes.Add (bundleNameMatch.Groups[1].Value, hashMatch.Groups[1].Value);
				Debug.Log(bundleNameMatch.Groups[1].Value + " Hash: " + hashMatch.Groups[1].Value);
			}
			else {
				// No tenemos en cuenta el fichero del manifest de la plataforma
				if (!new Regex(@"(Android|iOS|Windows)\.manifest$").Match(file).Success) {
					Debug.LogError("Hash not found: " + file);
				}
			}
		}

		return manifestHashes;
	}

	static Dictionary<string, string> GetManifestHashesFromAssetBundles(string path) {
		Dictionary<string, string> manifestHashes = new Dictionary<string, string>();

		var names = AssetDatabase.GetAllAssetBundleNames();
		foreach (var name in names) {
			Hash128 hash;
			BuildPipeline.GetHashForAssetBundle(path + "/" + name, out hash);
			manifestHashes.Add (name, hash.ToString());
			Debug.Log ("Name: " + (path + "/" + name) + " Hash: " + hash.ToString());
		}

		return manifestHashes;
	}

	static List<string> GetManifestFiles(string directory) {
		return Directory.GetFiles(directory).Where(item => item.Contains("manifest"))
			.Union (Directory.GetDirectories(directory).Aggregate(new List<string>(), (a, b) => a.Union(GetManifestFiles(b)).ToList ()))
			.ToList();
	}

	/*
	[MenuItem("Assets/Build AssetBundle Android")]
	static void ExportResource () {
		string path = "AssetBundles/Android/";
		Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
		BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, 
		                               BuildAssetBundleOptions.CollectDependencies 
		                               | BuildAssetBundleOptions.CompleteAssets);
	}
	*/
}
