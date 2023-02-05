using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultLayers;
using UnityEngine.Promise;


public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private string saveName;
    [SerializeField] private Stats stats;
    [SerializeField] private Skills skills;

    private void Awake()
    {
        if(File.Exists($"{Application.persistentDataPath}/{saveName}.save"))
        {
            Debug.Log("[SaveManager]: Save Found. Loading data...");
            Load($"{Application.persistentDataPath}/{saveName}.save");
        }
        else
        {
            Debug.Log("[SaveManager]: No Save Found");
            stats.Initialize(true);
            skills.Initialize();
        }
    }

    public void Save()
    {
        Dictionary<string, object> dict;
        if (File.Exists($"{Application.persistentDataPath}/{saveName}.save"))
        {
            dict = LoadFile($"{Application.persistentDataPath}/{saveName}.save");
        }
        else
        {
            dict = new Dictionary<string, object>();
        }
        foreach (var savable in FindObjectsOfType<SavableEntity>())
        {
            dict[savable.Id] = savable.SaveData();
        }
        SaveFile($"{Application.persistentDataPath}/{saveName}.save",dict); 
        
        // Get the persistence data layer used during Game Foundation initialization.
        if (!(GameFoundationSdk.dataLayer is PersistenceDataLayer dataLayer))
            return;

        // - Deferred is a struct that helps you track the progress of an asynchronous operation of Game Foundation.
        // - We use a using block to automatically release the deferred promise handler.
        using (Deferred saveOperation = dataLayer.Save())
        {
            // Check if the operation is already done.
            if (saveOperation.isDone)
            {
                LogSaveOperationCompletion(saveOperation);
            }
            else
            {
                StartCoroutine(WaitForSaveCompletion(saveOperation));
            }
        }
       
    }
    private IEnumerator WaitForSaveCompletion(Deferred saveOperation)
    {
        // Wait for the operation to complete.
        yield return saveOperation.Wait();

        LogSaveOperationCompletion(saveOperation);
    }

    private void LogSaveOperationCompletion(Deferred saveOperation)
    {
        // Check if the operation was successful.
        if (saveOperation.isFulfilled)
        {
            Debug.Log("Saved!");
        }
        else
        {
            Debug.LogError($"Save failed! Error: {saveOperation.error}");
        }
    }
    public void Load(string path)
    {
        Dictionary<string, object> dict = LoadFile(path);

        foreach (var savable in FindObjectsOfType<SavableEntity>())
        {
            if (dict.TryGetValue(savable.Id, out object data))
            {
                savable.LoadData(data);
            }
        }
    }
    
    private void SaveFile(string path, object saveData)
    {
        using (FileStream file = File.Open(path,FileMode.Create))
        {
            BinaryFormatter formatter = GetBinaryFormatter();
            try
            {
                formatter.Serialize(file, saveData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                file.Close();
            }
        }
    }

    private Dictionary<string, object> LoadFile(string path)
    {
        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path,FileMode.Open);
        try
        {
            object saveData = formatter.Deserialize(file);
            return saveData as Dictionary<string, object>;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Dictionary<string, object>();
        }
        finally
        {
            file.Close();
        }
    }
    private BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        SurrogateSelector selector = new SurrogateSelector();

        Vector3SerializationSurrogate vector3Surrogate = new Vector3SerializationSurrogate();
        QuaternionSerializationSurrogate quaternionSurrogate = new QuaternionSerializationSurrogate();
        
        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All),vector3Surrogate);
        selector.AddSurrogate(typeof(Quaternion),new StreamingContext(StreamingContextStates.All),quaternionSurrogate);

        formatter.SurrogateSelector = selector;
        return formatter;

    }
    
}
