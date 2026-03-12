using System;
using CleanSweep.Core;

namespace CleanSweep.Core
{
    public static class GameEvents
    {
        // room events
        public static event Action<RoomController> OnRoomInteracted;
        public static event Action<RoomController, InteractionResult> OnRoomResolved;
        public static event Action<int> OnFloorCleared;         // passes floor index

        // timer events
        public static event Action<float> OnTimerTick;          // passes remaining time
        public static event Action OnTimerExpired;

        // penalty events
        public static event Action<float, string> OnPenaltyApplied; // seconds, reason

        // game state events
        public static event Action<GameState> OnGameStateChanged;

        // VIP events
        public static event Action<int, RoomController> OnVIPRequestTriggered; // floor, room

        // score events
        public static event Action<int> OnScoreChanged;

        public static void RoomInteracted(RoomController room) =>
            OnRoomInteracted?.Invoke(room);

        public static void RoomResolved(RoomController room, InteractionResult result) =>
            OnRoomResolved?.Invoke(room, result);

        public static void FloorCleared(int floorIndex) =>
            OnFloorCleared?.Invoke(floorIndex);

        public static void TimerTick(float remaining) =>
            OnTimerTick?.Invoke(remaining);

        public static void TimerExpired() =>
            OnTimerExpired?.Invoke();

        public static void PenaltyApplied(float seconds, string reason) =>
            OnPenaltyApplied?.Invoke(seconds, reason);

        public static void GameStateChanged(GameState state) =>
            OnGameStateChanged?.Invoke(state);

        public static void VIPRequestTriggered(int floorIndex, RoomController room) =>
            OnVIPRequestTriggered?.Invoke(floorIndex, room);

        public static void ScoreChanged(int newScore) =>
            OnScoreChanged?.Invoke(newScore);
    }
}