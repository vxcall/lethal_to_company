using UnityEngine;

namespace lethal_to_company
{
  partial class hack : MonoBehaviour
  {
    Camera camera;

    private void assign_camera()
    {
      camera = local_player.gameplayCamera;
    }

    private Vector3 world_to_screen(Vector3 worldPosition)
    {
      return camera.WorldToScreenPoint(worldPosition);
    }

    private float distance(Vector3 worldPosition)
    {
      return Vector3.Distance(camera.transform.position, worldPosition);
    }

    private void esp(Vector3 worldPosition, string text)
    {
      if (camera == null)
      {
        console.write_line("Camera is null!");
        return;
      }

      Vector3 pos = world_to_screen(worldPosition);
      GUI.Label(new Rect(
          pos.x,
          Screen.height - pos.y,
          pos.x + (text.Length * GUI.skin.label.fontSize),
          Screen.height - pos.y + GUI.skin.label.fontSize * 2),
        text);
    }
  }
}