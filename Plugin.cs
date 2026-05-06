using BepInEx;
using RiftOfTheNecroManager;
using UnityEngine;

namespace CustomFC;

[BepInPlugin("rotn.koki.CustomFC", "Custom Track FC Label", "1.0.0")]
public class CustomFCPlugin : RiftPlugin
{
    internal static GameObject CustomFCLabel;
}