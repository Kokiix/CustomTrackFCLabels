using System.Linq;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RhythmRift;
using RiftOfTheNecroManager;
using Shared.Leaderboard;
using Shared.TrackSelection;
using UnityEngine;

namespace CustomFC;

[BepInPlugin("rotn.koki.utils.CustomFC", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class CustomFCPlugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    internal static Harmony harmony;
    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();
    }
    private void OnDestroy()
    {
        harmony.UnpatchSelf();
    }

    internal static GameObject FCObject;
}