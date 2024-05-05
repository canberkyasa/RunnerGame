using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameController.Color playerColor;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material yellowMaterial;
    [SerializeField] private Material blueMaterial;
    [SerializeField] private GameObject ColorChangeEffectPrefab;


    public string GetColor() => playerColor.ToString();
    
    // Start is called before the first frame update
    void Start()
    {
        switch (playerColor)
        {
            case GameController.Color.Red:
                GetComponent<Renderer>().material = redMaterial;
                GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = redMaterial;
                //GetComponentInChildren<TrailRenderer>().material = redMaterial;
                break;
            case GameController.Color.Yellow:
                GetComponent<Renderer>().material = yellowMaterial;
                GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = yellowMaterial;
                //GetComponentInChildren<TrailRenderer>().material = yellowMaterial;
                break;
            case GameController.Color.Blue:
                GetComponent<Renderer>().material = blueMaterial;
                GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = blueMaterial;
                //GetComponentInChildren<TrailRenderer>().material = blueMaterial;
                
                break;
            case GameController.Color.NoColor:
                break;
            default:
                Debug.LogError("Invalid color");
                break;
        }
    }

    private void SetColor(GameController.Color newColor)
    {
        playerColor = newColor;
        switch (playerColor)
        {
            case GameController.Color.Red:
                GetComponent<Renderer>().material = redMaterial;
                GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = redMaterial;
                //GetComponentInChildren<TrailRenderer>().material = redMaterial;
                break;
            case GameController.Color.Yellow:
                GetComponent<Renderer>().material = yellowMaterial;
                GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = yellowMaterial;
                //GetComponentInChildren<TrailRenderer>().material = yellowMaterial;
                break;
            case GameController.Color.Blue:
                GetComponent<Renderer>().material = blueMaterial;
                GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = blueMaterial;
                //GetComponentInChildren<TrailRenderer>().material = blueMaterial;
                break;
            case GameController.Color.NoColor:
                break;
            default:
                Debug.LogError("Invalid color");
                break;
        }
    }

    private void SplashEffect(GameController.Color newColor)
    {
        Debug.Log("Splash Effect");

        Color color;

        switch (newColor)
        {
            case GameController.Color.Red:
                color = Color.red;
                break;
            case GameController.Color.Yellow:
                color = Color.yellow;
                break;
            case GameController.Color.Blue:
                color = Color.blue;
                break;
            case GameController.Color.NoColor:
                color = Color.white;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        GameObject particleEffect = Instantiate(ColorChangeEffectPrefab, transform.position + transform.forward * .7f, Quaternion.identity);
        
        //Change Particle Effect Color by main.startColor
        ParticleSystem.MainModule main = particleEffect.GetComponent<ParticleSystem>().main;
        main.startColor = color;
        int childCound = particleEffect.transform.childCount;
        for (int i = 0; i < childCound; i++)
        {
            ParticleSystem childParticleSystem = particleEffect.transform.GetChild(i).GetComponent<ParticleSystem>();
            ParticleSystem.MainModule childMain = childParticleSystem.main;
            childMain.startColor = color;
        }

        Destroy(particleEffect, 4f);
    }


    private void OnEnable()
    {
        EventManager.SetColor += SetColor;
        EventManager.ChangeColor += SplashEffect;
    }

    private void OnDisable()
    {
        EventManager.SetColor -= SetColor;
        EventManager.ChangeColor -= SplashEffect;
    }
}
