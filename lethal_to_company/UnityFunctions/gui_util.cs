using UnityEngine;

namespace lethal_to_company
{
    partial class hack : MonoBehaviour
    {
        private void set_gui_font_style(int fontSize, Color color)
        { // used to set the GUI font and color style
            GUISkin skin = GUI.skin;
            GUIStyle newStyle = skin.GetStyle("Label");
            newStyle.fontSize = fontSize;
            GUI.color = color;
        }
        
    }
}