using BepInEx;
using RiftOfTheNecroManager;
using UnityEngine;

namespace CustomFC;

[BepInPlugin("rotn.koki.CustomFC", "Custom Track FC Label", "1.0.1")]
public class CustomFCPlugin : RiftPlugin
{
    internal static GameObject BaseFCLabel;
}