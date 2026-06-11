using BepInEx;
using CustomFCLabels;
using UnityEngine;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class CustomFCPlugin : BaseUnityPlugin
{
    internal static GameObject BaseFCLabel;
}

// Used for hot reload
// public class CustomFCPlugin : BaseUnityPlugin
// {
//     internal static new ManualLogSource Logger;
//     internal static Harmony harmony;
//     private void Awake()
//     {
//         Logger = base.Logger;
//         Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

//         harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);
//         harmony.PatchAll();
//     }
//     private void OnDestroy()
//     {
//         harmony.UnpatchSelf();
//     }

//     internal static GameObject BaseFCLabel;
// }