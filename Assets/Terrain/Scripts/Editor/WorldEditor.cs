using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(World))]
public class WorldEditor : Editor {
    World world;
    
    public override void OnInspectorGUI() {
        world = (World)target;

        if (DrawDefaultInspector()) {
            if (world.autoUpdate) {
                world.Run();
            }
        }
        
        if (GUILayout.Button("Generate")) {
            world.Run();
        }
    }
}
