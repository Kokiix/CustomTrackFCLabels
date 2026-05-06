<img width="586" height="338" alt="Untitled-2026-04-24-0136" src="https://github.com/user-attachments/assets/a976658b-a94b-44b6-84d0-e0f8eabd0089" />

**how does it work**
- The base game combo label is a `GameObject` that's toggled w `SetActive()` in `TrackSelection.InfiniteTrackSelectionOption.SetDifficulty()`. I have no idea where the `GameObject` comes from so I just build it from scratch :p
- My new `GameObject` is just made of the below components, and created / toggled after the `SetDifficulty()` parallel for custom tracks, `TrackSelection.CustomTrackSelectionOption.SetDifficulty()`.
    - `RectTransform`
    - `TextMeshProUGUI`
    - `Image`
- I did a bunch of manual work w https://github.com/sinai-dev/UnityExplorer to:
    - Get all the exact numbers for positioning
    - Find font/sprite resource names, then retrieved w `Resources.FindObjectsOfTypeAll<TYPE>()`
    - Figure out where in the hierarchy to place the object