using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    //GemCollected event
    public static event UnityAction GemCollected;
    public static void OnGemColllected() => GemCollected?.Invoke();
    //IncrementScore event
    public static event UnityAction<int> IncrementScore;
    public static void OnIncrementScore(int x) => IncrementScore?.Invoke(x);

    //WoodCollected event
    public static event UnityAction WoodCollected;
    public static void OnWoodCollected() => WoodCollected?.Invoke();
    //IncrementWood event
    public static event UnityAction IncrementWood;
    public static void OnIncrementWood() => IncrementWood?.Invoke();
}
