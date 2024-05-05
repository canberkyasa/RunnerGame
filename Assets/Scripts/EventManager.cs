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

    //COLLECTIBLE EVENTS
    //CollectibleCollected event
    public static event UnityAction CollectibleCollected;
    public static void OnCollectibleCollected() => CollectibleCollected?.Invoke();
    //IncrementCollectiblePoints event
    public static event UnityAction IncrementCollectiblePoints;
    public static void OnIncrementCollectiblePoints() => IncrementCollectiblePoints?.Invoke();
    //DecrementCollectiblePointsORChangeColor event
    public static event UnityAction<GameController.Color> DecrementCollectiblePointsORChangeColor;
    public static void OnDecrementCollectiblePointsORChangeColor(GameController.Color newColor) => DecrementCollectiblePointsORChangeColor?.Invoke(newColor);
    //SetColor event
    public static event UnityAction<GameController.Color> SetColor;
    public static void OnSetColor(GameController.Color newColor) => SetColor?.Invoke(newColor);
    //ChangeColor event (WILL USE THIS LATER IF NO NEEDED DELETE)
    public static event UnityAction<GameController.Color> ChangeColor;
    public static void OnChangeColor(GameController.Color newColor) => ChangeColor?.Invoke(newColor);

    //GameOver event
    public static event UnityAction GameOver;
    public static void OnGameOver() => GameOver?.Invoke();


    //WoodCollected event
    public static event UnityAction WoodCollected;
    public static void OnWoodCollected() => WoodCollected?.Invoke();
    //IncrementWood event
    public static event UnityAction IncrementWood;
    public static void OnIncrementWood() => IncrementWood?.Invoke();
}
