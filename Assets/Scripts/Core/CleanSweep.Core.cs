namespace CleanSweep.Core
{
    public enum RoomStatus
    {
        NeedsService,       // Must be serviced — penalty if skipped
        ReadyForCheckout,   // Must process checkout — penalty if skipped
        VIPRequest,         // Priority task — bigger penalty if skipped
        DoNotDisturb        // Leave it alone — penalty if you interact
    }

    public enum InteractionResult
    {
        Success,
        Penalty,
        Ignored
    }

    public enum GameState
    {
        Idle,
        Running,
        Paused,
        GameOver
    }

    public enum RatingTier
    {
        S,
        A,
        B,
        C,
        F
    }
}