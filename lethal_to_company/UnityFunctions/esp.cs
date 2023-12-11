using UnityEngine;

namespace lethal_to_company
{
  partial class hack : MonoBehaviour
  {
    private Vector3 world_to_screen(Vector3 world_position)
    {
      return camera.WorldToScreenPoint(world_position);
    }

    private float distance(Vector3 world_position)
    {
      return Vector3.Distance(local_player.transform.position, world_position);
    }

    private void esp(Vector3 entity_position)
    {
      if (camera == null)
      {
        console.write_line("Camera is null!");
        return;
      }

      Vector3 screenPos = world_to_screen(entity_position);

      // Check if entity is in front of the camera
      if (screenPos.z < 0)
      {
        return;
      }

      // Normalize screen coordinates (0 to 1)
      screenPos.x /= Screen.width;
      screenPos.y /= Screen.height;

      // Scale based on the resolution it works nicely with
      float referenceWidth = 887;
      float referenceHeight = 503;
      screenPos.x *= referenceWidth;
      screenPos.y *= referenceHeight;

      // Calculate the size of the box based on the distance
      float distanceToEntity = distance(entity_position);
      Vector2 boxSize = new Vector2(50, 50) / distanceToEntity; // Adjust as needed

      // Set the color for the box
      Color boxColor = Color.red; // Change as needed

      // Correct the position to center the box
      Vector2 correctedPos = new Vector2(screenPos.x - boxSize.x / 2, referenceHeight - screenPos.y - boxSize.y / 2);

      // Check if the entity is within the screen
      if (correctedPos.x > 0 && correctedPos.x < referenceWidth && correctedPos.y > 0 &&
          correctedPos.y < referenceHeight)
      {
        // Draw the box around the entity
        lethal_to_company.render.draw_box(correctedPos, boxSize, boxColor);
      }
    }
  }
}