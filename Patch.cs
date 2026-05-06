using System.IO;
using System.Linq;
using CustomFC;
using HarmonyLib;
using Shared.TrackSelection;
using UnityEngine;
using UnityEngine.UI;

[HarmonyPatch(typeof(InfiniteTrackSelectionOption))]
public static class InfiniteTrackSelectionPatch
{
    [HarmonyPatch(nameof(InfiniteTrackSelectionOption.SetDifficulty))]
    [HarmonyPostfix]
    public static void SetDifficulty(InfiniteTrackSelectionOption __instance)
    {
        __instance._fullComboObject.SetActive(true);
    }
}


// FC tag stuff is in 85c0a625a889de8148364ad1944f5df8.bundle
[HarmonyPatch(typeof(CustomTrackSelectionOption))]
public static class CustomTrackSelectionPatch
{
    [HarmonyPatch(nameof(CustomTrackSelectionOption.SetDifficulty))]
    [HarmonyPostfix]
    public static void SetDifficulty(CustomTrackSelectionOption __instance)
    {
        if (!CustomFCPlugin.FCSprite)
            CustomFCPlugin.FCSprite = Resources.FindObjectsOfTypeAll<Sprite>().First(sprite => sprite.name == "ComboTag");

        Transform background = __instance.transform.Find("BounceContainer/Background");
        GameObject myFCTag = new("FCTag", typeof(RectTransform));
        myFCTag.transform.SetParent(background, false);
        myFCTag.AddComponent<Image>().sprite = CustomFCPlugin.FCSprite;
        myFCTag.GetComponent<RectTransform>().anchoredPosition = new Vector2(506.1145f, 61.1621f);
    }
}