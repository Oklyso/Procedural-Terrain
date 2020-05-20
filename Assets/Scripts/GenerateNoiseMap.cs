using UnityEngine;
using System.Collections;

public class GenerateNoiseMap : MonoBehaviour {

	public enum DisplayMode {NoiseMap, ColourMap};
	public int seed;
	public Vector2 offset;

	public bool autoUpdate;
	public DisplayMode displayMode;

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	
	public float amplitude;
	public float frequency;

	

	public HeightTypes[] heights;

	public void GenerateMap() {
		float[,] noiseMap = PerlinNoise.NoiseMap (
			mapWidth, 
			mapHeight, 
			seed, 
			noiseScale, 
			octaves, 
			amplitude, 
			frequency, 
			offset);

		Color[] colorMode = new Color[mapWidth * mapHeight];
		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				float currentHeight = noiseMap [x, y];
				for (int i = 0; i < heights.Length; i++) {
					if (currentHeight <= heights [i].height) {
						colorMode [y * mapWidth + x] = heights [i].colour;
						break;
					}
				}
			}
		}

		DisplayNoise display = FindObjectOfType<DisplayNoise> ();
		if (displayMode == DisplayMode.NoiseMap) {
			display.DrawTexture (Textures.HeightMapTexture(noiseMap));
		} else if (displayMode == DisplayMode.ColourMap) {
			display.DrawTexture (Textures.ColorTexture(
				colorMode, 
				mapWidth, 
				mapHeight
				));
		}
	}

	void OnValidate() {
		if (mapWidth < 1) {
			mapWidth = 1;
		}
		if (mapHeight < 1) {
			mapHeight = 1;
		}					//CONSTRAINTS
		if (frequency < 1) {
			frequency = 1;
		}
		if (octaves < 0) {
			octaves = 0;
		}
	}
}

[System.Serializable]
public struct HeightTypes {
	public string name;
	public float height;
	public Color colour;
}