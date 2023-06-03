using UnityEngine;


public class World : MonoBehaviour {
    [SerializeField]
    MeshFilter meshFilter;
    [SerializeField]
    MeshRenderer meshRenderer;


    [Space(10)]
    public bool autoUpdate = true;
    [Range(2, 512)]
    public int width = 16;
    [Range(2, 512)]
    public int height = 16;

    [Space(10)]
    public NoiseProps[] noiseProps;


    public void Run() {
        MeshData meshData = MeshGenerator.Generate2D(width,
            height,
            noiseProps
            );

        meshFilter.sharedMesh = meshData.CreateMesh();
        
        if(meshRenderer.sharedMaterial == null)
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
    }
}

[System.Serializable]
public class NoiseProps {
    public int seed = 32767;
    public FastNoise.NoiseType noiseType = FastNoise.NoiseType.Simplex;
    [Range(0.135f, 50.0f)]
    public float heightMultiplier = 2.0f;
    [Range(0.1f, 10.0f)]
    public float scale = 1.0f;
    
    [Space(10)]
    [Range(0.001f, 4.0f)]
    public float frequency = 1.0f;
    [Range(0.001f, 2.0f)]
    public float lacunarity = 1.0f;
    [Range(1, 8)]
    public int octaves = 2;
    [Range(0.0f, 10.0f)]
    public float gain = 1.0f;
    
    public FastNoise CreateNoise() {
        FastNoise noise = new FastNoise(seed);
        noise.SetNoiseType(noiseType);
        
        noise.SetFrequency(frequency);
        noise.SetFractalLacunarity(lacunarity);
        noise.SetFractalOctaves(octaves);
        noise.SetFractalGain(gain);

        return noise;
    }
}
