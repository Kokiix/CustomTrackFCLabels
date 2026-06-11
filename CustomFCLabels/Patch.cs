using System.IO;
using System.Linq;
using HarmonyLib;
using Shared;
using Shared.PlayerData;
using Shared.TrackSelection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[HarmonyPatch(typeof(CustomTrackSelectionOption), "SetDifficulty")]
static class CustomTrackSelectionPatch
{
    static GameObject LabelObj;

    static void Postfix(CustomTrackSelectionOption __instance, Difficulty selectedDifficulty)
    {
        Transform FCLabel = __instance.transform.Find("BounceContainer/Background/FCTag(Clone)");
        if (FCLabel == null)
        {
            if (!LabelObj)
                BuildCustomFCLabel();

            FCLabel = InstantiateFCLabel(parent: __instance.transform.Find("BounceContainer/Background"));
        }

        FCLabel.gameObject.SetActive(PlayerDataUtil.GetWasFullClearedByDifficulty(__instance._levelId, selectedDifficulty));
    }

    static void BuildCustomFCLabel()
    {
        GameObject myFCTag = new("FCTag", typeof(RectTransform))
        {
            name = "FCTag"
        };

        Image img = myFCTag.AddComponent<Image>();
        img.sprite = Resources.FindObjectsOfTypeAll<Sprite>().First(sprite => sprite.name == "ComboTag");
        img.color = new Color(0.0353f, 0.6784f, 1);

        GameObject txtObj = new("FCTag_text", typeof(RectTransform));
        txtObj.transform.SetParent(myFCTag.transform);

        // Values are copied from inspecting object in base game..
        TextMeshProUGUI tmp = txtObj.AddComponent<TextMeshProUGUI>();
        tmp.text = "FULL COMBO!";
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.horizontalAlignment = HorizontalAlignmentOptions.Center;
        tmp.font = Resources.FindObjectsOfTypeAll<TMP_FontAsset>().First(font => font.name == "Oxanium-Bold SDF - SoftMaskable");
        tmp.fontMaterial = Resources.FindObjectsOfTypeAll<Material>().First(mat => mat.name == "Oxanium-Bold SDF - SoftMaskable - DropShadow");
        tmp.fontSize = 20;
        tmp.enableAutoSizing = false;
        tmp.fontStyle = FontStyles.Italic | FontStyles.UpperCase;
        tmp.color = new Color(1, 1, 1);
        // ..with exception of margin, as rotation below likely messed it up. 
        // This had to be hand tuned to nudge text into center from left
        tmp.margin = new Vector4(40, 5, 0, 0);

        LabelObj = myFCTag;
    }

    static Transform InstantiateFCLabel(Transform parent)
    {
        // Values are copied from inspecting object in base game..
        GameObject FCInstance = Object.Instantiate(LabelObj);
        FCInstance.transform.SetParent(parent);
        FCInstance.SetActive(false);
        RectTransform rect = FCInstance.GetComponent<RectTransform>();
        rect.pivot = new Vector2(1f, 0f);
        rect.anchorMin = new Vector2(0.991f, 0.9116f);
        rect.anchorMax = new Vector2(0.991f, 0.9116f);
        rect.sizeDelta = new Vector2(239.0032f, 28.9733f);
        rect.anchoredPosition = new Vector2(-0.5136f, -0.93f);
        // ..with exception of rotation, as the shape of customs requires a tiny bit more rotation (0.5f)
        rect.localEulerAngles = new Vector3(0f, 0f, 360f);

        return FCInstance.transform;
    }
}

