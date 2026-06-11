using BepInEx;
using CustomFCLabels;
using HarmonyLib;
using UnityEngine;

// [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
// public class CustomFCPlugin : BaseUnityPlugin
// {
//     internal static GameObject BaseFCLabel;
// }

// Non Necromanager version
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class CustomFCPlugin : BaseUnityPlugin
{
    internal static Harmony harmony;
    internal static GameObject BaseFCLabel;

    void Awake()
    {
        harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();
    }
    void OnDestroy()
    {
        harmony.UnpatchSelf();
    }
}