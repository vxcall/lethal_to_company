using UnityEngine;
using System;

namespace lethal_to_company
{
  partial class hack : MonoBehaviour
  {
    private Vector3 world_to_screen(Vector3 world)
    {
      Vector3 screen = camera.WorldToViewportPoint(world);

      screen.x *= Screen.width;
      screen.y *= Screen.height;

      screen.y = Screen.height - screen.y;

      return screen;
    }

    private float distance(Vector3 world_position)
    {
      return Vector3.Distance(camera.transform.position, world_position);
    }

    private void esp(Vector3 entity_position, Color color)
    {
      if (camera == null)
      {
        console.write_line("camera is null");
        return;
      }

      Vector3 entity_screen_pos = world_to_screen(entity_position);

      if (entity_screen_pos.z < 0 || Math.Abs(entity_position.y - local_player.transform.position.y) > 50)
      {
        return;
      }

      float distance_to_entity = distance(entity_position);
      float box_width = 300 / distance_to_entity;
      float box_height = 300 / distance_to_entity;

      float box_thickness = 3f;

      if (entity_screen_pos.x > 0 && entity_screen_pos.x < Screen.width && entity_screen_pos.y > 0 && entity_screen_pos.y < Screen.height)
      {
        render.draw_box_outline(
          new Vector2(entity_screen_pos.x - box_width / 2, entity_screen_pos.y - box_height / 2), box_width,
          box_height,
          color, box_thickness);
        render.draw_line(new Vector2(Screen.width / 2, Screen.height),
          new Vector2(entity_screen_pos.x, entity_screen_pos.y + box_height / 2), color, 2f);
      }
    }
  }
}