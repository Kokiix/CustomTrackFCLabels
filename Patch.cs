using System.IO;
using System.Linq;
using CustomFC;
using HarmonyLib;
using Shared;
using Shared.PlayerData;
using Shared.TrackSelection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[HarmonyPatch(typeof(CustomTrackSelectionOption))]
public static class CustomTrackSelectionPatch
{
    [HarmonyPatch(nameof(CustomTrackSelectionOption.SetDifficulty))]
    [HarmonyPostfix]
    public static void SetDifficulty(CustomTrackSelectionOption __instance, Difficulty selectedDifficulty)
    {
        Transform FCTagTransform = __instance.transform.Find("BounceContainer/Background/FCTag(Clone)");
        if (FCTagTransform)
        {
            GameObject FCTag = FCTagTransform.gameObject;
            FCTag.SetActive(PlayerDataUtil.GetWasFullClearedByDifficulty(__instance._levelId, selectedDifficulty));
            return;
        }

        if (!CustomFCPlugin.CustomFCLabel)
            InitFCTagGameObj();

        Transform background = __instance.transform.Find("BounceContainer/Background");
        GameObject FCInstance = Object.Instantiate(CustomFCPlugin.CustomFCLabel);
        FCInstance.transform.SetParent(background);
        FCInstance.SetActive(false);
        RectTransform rect = FCInstance.GetComponent<RectTransform>();
        rect.pivot = new Vector2(1f, 0f);
        rect.anchorMin = new Vector2(0.991f, 0.9116f);
        rect.anchorMax = new Vector2(0.991f, 0.9116f);
        rect.sizeDelta = new Vector2(239.0032f, 28.9733f);
        rect.localEulerAngles = new Vector3(0f, 0f, 360f);
        rect.anchoredPosition = new Vector2(-0.5136f, -0.93f);
    }

    private static void InitFCTagGameObj()
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
        tmp.margin = new Vector4(40, 5, 0, 0); // Hand tuned!

        CustomFCPlugin.CustomFCLabel = myFCTag;
    }
}

