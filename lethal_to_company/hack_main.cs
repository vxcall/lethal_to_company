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
      //GUI.Label(new Rect(100, 80, 500, 30),
      //  $"{local_player.name} X: {local_player.transform.position.x}, Y: {local_player.transform.position.y}, Z: {local_player.transform.position.z}");

      //GUI.Label(new Rect(100, 50, 500, 30),
      //  $"Camera X: {camera.transform.position.x}, Y: {camera.transform.position.y}, Z: {camera.transform.position.z}");

      //GUI.Label(new Rect(100, 100, 500, 30), $"{camera.transform.forward.x}{camera.transform.forward.y}{camera.transform.forward.z}" );

      foreach (var go in grabbable_objects)
      {
        esp(go.transform.position, Color.green);
      }

      foreach (var enemy in enemies)
      {
        esp(enemy.transform.position, Color.red);
      }

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
    private Camera camera;
  }
}