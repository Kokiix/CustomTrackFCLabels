using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RiftOfTheNecroManager;
using UnityEngine;

namespace CustomFC;

[BepInPlugin("rotn.koki.CustomFC", "Custom Track FC Label", "1.0.2")]
public class CustomFCPlugin : RiftPlugin
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