﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateSceneButtons : MonoBehaviour
{
    // Where to place the button
    public Transform spawnButtonAt;
    // The button to place
    public GameObject buttonPrefab;
    // The instance of the individually spawned button(s)
    GameObject sceneButton;

    // This is the only thing I do
    // Wake up [load scene] 
    // Pass out [load scene]
    // Faded [load scene]

    private void Start()
    {
        GenerateSceneButtons();
    }

    void GenerateSceneButtons()
    {
        // Make a button for each scene in File -> Build Settings
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            // Only create a button for enabled scenes
            if (scene.enabled)
            {
                // Create the button at the proper transform (in our scroll view content)
                sceneButton = Instantiate(buttonPrefab, spawnButtonAt);
                // Make the button say which scene it is
                sceneButton.GetComponentInChildren<TextMeshProUGUI>().text = GetSceneName(scene.path);
                sceneButton.GetComponent<Button>().onClick.AddListener(() => LoadScene(scene.path));
            }
        }
    }

    // Give me a path, i'll get u a scene name mofucker
    string GetSceneName(string path)
    {
        // Expects a path, we want the scene name
        string sceneName = "";
        // Split on /
        string[] split = path.Split('/');
        // Get the last section, which is the scene name
        sceneName = split[split.Length - 1];
        return sceneName;
    }

    // Loads the scene
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}