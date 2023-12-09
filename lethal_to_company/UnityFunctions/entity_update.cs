using GameNetcodeStuff;
using UnityEngine;

namespace lethal_to_company
{
  partial class hack : MonoBehaviour
  {
    // Setup a timer and a set time to reset to
    private readonly float entity_update_interval = 5f;
    private float entity_update_timer;

    private void EntityUpdate()
    {
      if (entity_update_timer <= 0f)
      {
        enemies = FindObjectsOfType<EnemyAI>();
        // You have to open menu to get local player lol
        local_player = HUDManager.Instance.localPlayer;

        assign_camera();

        clear_update_timer();
      }

      entity_update_timer -= Time.deltaTime;
    }

    private void clear_update_timer()
    {
      entity_update_timer = entity_update_interval;
    }
  }
}