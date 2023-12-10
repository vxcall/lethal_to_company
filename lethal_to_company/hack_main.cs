using System;
using System.Diagnostics.CodeAnalysis;
using GameNetcodeStuff;
using UnityEngine;

namespace lethal_to_company
{
  partial class hack : MonoBehaviour
  {
    /* - Initializing Methods - */
    // This function is called when the class is loaded by the game (prior to attachment)
    public void Awake()
    {
    }

    // This function is called when the script is enabled by the parent object
    public void OnEnable()
    {
    }

    public void Start()
    {
      console.write_line("lethal_to_company");
    }

    /* - Game Loop Methods - */

    // This function is called once per frame, it's frequency depends on the frame rate.
    // This is at the beginning of the game logic cycle.
    public void Update()
    {
      EntityUpdate();
    }

    // This function is called once per frame, it's frequency depends on the frame rate.
    // This is at the beginning of the game logic cycle.
    public void LateUpdate()
    {
    }

    // This function is called at the end of the frame, after all game logic.
    // It is called twice per frame: Once for rendering, and once for GUI Events
    public void OnGUI()
    {
      // Y is player's foot position
      GUI.Label(new Rect(100, 80, 500, 30),
        $"{local_player.name} X: {local_player.transform.position.x}, Y: {local_player.transform.position.y}, Z: {local_player.transform.position.z}");

      console.write_line($"{camera.transform.forward}");
      GUI.Label(new Rect(100, 100, 500, 30), $"{camera.transform.forward.x}{camera.transform.forward.y}{camera.transform.forward.z}" );

      // GUI.Label(new Rect(100, 100, 500, 30), $"items count: {grabbable_objects.Length}");
      // int index = 1;
      // foreach (var go in grabbable_objects)
      // {
      //   GUI.Label(new Rect(100, 130 + (20 * index), 500, 30),
      //     $"{go.itemProperties.itemName} X: {go.transform.position.x}, Y: {go.transform.position.y}, Z: {go.transform.position.z}");
      //   index++;
      // }

      // index = 1;

      // GUI.Label(new Rect(810, 100, 500, 30), $"Enemies count: {enemies.Length}");
      // int index2 = 1;
      // foreach (var enemy in enemies)
      // {
      //   GUI.Label(new Rect(810, 100 + (20 * index2), 1000, 30),
      //     $"{enemy.enemyType.enemyName} X: {enemy.transform.position.x}, Y: {enemy.transform.position.y}, Z: {enemy.transform.position.z}");
      //   esp(enemy.transform.position);
      //   index2++;
      // }

      // index2 = 1;
    }

    /* - Physics Method - */
    public void FixedUpdate()
    {
      // This function is called at a fixed frequency (Typically 100hz) and is independent of the frame rate.
      // For physics operations.
    }

    /* - Closing Methods - */
    public void OnDisable()
    {
      // This function is called when the instance of the class is disabled by it's parent.
      // The component remains attached, but disabled (Component.ENABLED = false)
    }

    public void OnDestroy()
    {
      // This function is called when the instance of the class is destroyed by it's parent.
      // The component and all it's data are destroyed and must be created again.
    }

    private EnemyAI[] enemies;
    private PlayerControllerB local_player;
    private GrabbableObject[] grabbable_objects;
  }
}