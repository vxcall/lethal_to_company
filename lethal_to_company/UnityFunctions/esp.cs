using UnityEngine;

namespace lethal_to_company
{
  partial class hack : MonoBehaviour
  {
    Camera camera;

    private void assign_camera()
    {
      camera = local_player.visorCamera;
    }

    private Vector3 world_to_screen(Vector3 world_position)
    {
      return camera.WorldToScreenPoint(world_position);
    }

    private float distance(Vector3 world_position)
    {
      return Vector3.Distance(camera.transform.position, world_position);
    }

    private void esp(Vector3 world_position)
    {
      if (camera == null)
      {
        console.write_line("Camera is null!");
        return;
      }

      Vector3 screen_foot_pos = world_to_screen(world_position);
      Vector3 headpos; headpos.x = screen_foot_pos.x; headpos.y = screen_foot_pos.y + 3f; headpos.z = screen_foot_pos.z;
      float height = headpos.y - screen_foot_pos.y;
      float width = height / 2f;
      render.draw_box(screen_foot_pos.x - (width / 2), (float)Screen.height - screen_foot_pos.y - height, width, height, Color.red, 2f);
    }
  }
}