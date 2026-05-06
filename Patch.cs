using CustomFC;
using HarmonyLib;
using Shared.TrackSelection;

[HarmonyPatch(typeof(InfiniteTrackSelectionOption))]
public static class Patch
{
    [HarmonyPatch(nameof(InfiniteTrackSelectionOption.SetDifficulty))]
    [HarmonyPostfix]
    public static void SetEntryData(InfiniteTrackSelectionOption __instance)
    {
        CustomFCPlugin.Logger.LogError("tring patch");
        __instance._fullComboObject.SetActive(true);
    }
}