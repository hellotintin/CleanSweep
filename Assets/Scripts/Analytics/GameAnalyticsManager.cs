using GameAnalyticsSDK;

/// <summary>
/// Static helper that wraps all GameAnalytics event calls.
/// Requires the GameAnalytics prefab to be present in the scene for SDK initialisation.
/// </summary>
public static class GameAnalyticsManager
{
    // -----------------------------------------------------------------------
    // Progression events
    // -----------------------------------------------------------------------

    /// <summary>Called when the player arrives on a floor (floor index is 0-based).</summary>
    public static void OnFloorStarted(int floorIndex)
    {
        string floorLabel = "Floor_" + (floorIndex + 1).ToString("D2");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Hotel", floorLabel);
    }

    /// <summary>Called when every room on the current floor has been cleared.</summary>
    public static void OnFloorCompleted(int floorIndex)
    {
        string floorLabel = "Floor_" + (floorIndex + 1).ToString("D2");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Hotel", floorLabel);
    }

    /// <summary>Called once the player clears the final floor — the whole hotel is done.</summary>
    public static void OnGameCompleted()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Hotel");
    }

    // -----------------------------------------------------------------------
    // Design event
    // -----------------------------------------------------------------------

    /// <summary>Called each time the player handles a room, tagged by room type.</summary>
    public static void OnRoomCleared(RoomStatus roomStatus)
    {
        GameAnalytics.NewDesignEvent("Room:Cleared:" + roomStatus.ToString());
    }
}
