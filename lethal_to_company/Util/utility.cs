using UnityEngine;

namespace lethal_to_company
{
    partial class hack : MonoBehaviour
    {
        // We setup our console and output log in here
        debug_console console = new debug_console();
        debug_log log = new debug_log(true);
    }
}
