using BepInEx;
using CustomFCLabels;
using HarmonyLib;
using RiftOfTheNecroManager;
using UnityEngine;

// [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
// [BepInDependency("com.lalabuff.necrodancer.necromanager", BepInDependency.DependencyFlags.SoftDependency)]
// class CustomFCPlugin : RiftPlugin
// {
//     internal static GameObject BaseFCLabel;
// }

// Non Necromanager version
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
class CustomFCPlugin : BaseUnityPlugin
{
    internal static Harmony harmony;

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