using System.Collections;
using System.Linq;
using UnityEngine;

public static class MeshGenerator
{
    public static MeshData Generate2D(int width, int height, NoiseProps[] noiseProps) {
        MeshData data = new MeshData(width, height);
        
        FastNoise[] noiseMaps = (from noiseProp in noiseProps select noiseProp.CreateNoise()).ToArray();

        float topLeftX = width / 2.0f;
        float topLeftZ = height / 2.0f;


        int vertexIndex = 0;
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                float h = 0.0f;
                for (int i = 0; i < noiseProps.Length; i++) {
                    h += noiseMaps[i].GetNoise(x / noiseProps[i].scale, y / noiseProps[i].scale) * noiseProps[i].heightMultiplier;
                }
                
                data.Vertices[vertexIndex] = new Vector3(topLeftX - x, h, topLeftZ - y);
                data.UV[vertexIndex] = new Vector2(x / (float)width, y / (float)height);

                if (x < width - 1 && y < height - 1) {
                    data.AddTriangle(vertexIndex, vertexIndex + width, vertexIndex + 1);
                    data.AddTriangle(vertexIndex + width, vertexIndex + width + 1, vertexIndex + 1);
                }
                

                vertexIndex++;
            }
        }
        
        
        return data;
    }
}
