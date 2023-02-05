using System;
using System.Collections;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultCatalog;
using UnityEngine.GameFoundation.DefaultLayers;
using UnityEngine.GameFoundation.DefaultLayers.Persistence;
using UnityEngine.Promise;


public class GameManager : MonoBehaviour
{
    private CatalogAsset currentCatalog;
    private readonly string localPersistenceFilename = "GameFoundationSave";

    private void OnDestroy()
    {
        if (!GameFoundationSdk.IsInitialized)
        {
            Debug.Log("Game Foundation is not initialized");
            return;
        }
        GameFoundationSdk.Uninitialize();
    }

    private IEnumerator Start()
    {
        PersistenceDataLayer dataLayer = new PersistenceDataLayer(
            new LocalPersistence(
               localPersistenceFilename,
               new JsonDataSerializer()
               ),
            currentCatalog
            );
        
        using (Deferred initialization = GameFoundationSdk.Initialize(dataLayer))
        {
            if (!initialization.isDone)
                yield return initialization.Wait();
            if (!initialization.isFulfilled)
            {
                Debug.LogError(initialization.error);
                yield break;
            }
        }
    }
    
}
