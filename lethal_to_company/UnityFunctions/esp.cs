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
    }
  }
}