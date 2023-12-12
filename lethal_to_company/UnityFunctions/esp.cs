using UnityEngine;

namespace lethal_to_company
{
  partial class hack : MonoBehaviour
  {
    private Vector3 world_to_screen(Camera camera, Vector3 world)
    {
      Vector3 screen = camera.WorldToViewportPoint(world);

      screen.x *= Screen.width;
      screen.y *= Screen.height;

      screen.y = Screen.height - screen.y;

      return screen;
    }

    private float distance(Vector3 world_position)
    {
      return Vector3.Distance(local_player.gameplayCamera.transform.position, world_position);
    }

    private void esp(Vector3 entity_position)
    {
      if (camera == null)
      {
        console.write_line("camera is null");
        return;
      }

      Vector3 screen_pos = world_to_screen(camera, entity_position);

      if (screen_pos.z < 0)
      {
        return;
      }

      float distance_to_entity = distance(entity_position);
      float box_width = 300 / distance_to_entity;
      float box_height = 300 / distance_to_entity;

      Color box_color = Color.red;
      float box_thickness = 1f;

      if (screen_pos.x > 0 && screen_pos.x < Screen.width && screen_pos.y > 0 && screen_pos.y < Screen.height)
      {
        render.draw_box_outline(
          new Vector2(screen_pos.x - box_width / 2, screen_pos.y - box_height / 2), box_width,
          box_height,
          box_color, box_thickness);
      }
    }
  }
}