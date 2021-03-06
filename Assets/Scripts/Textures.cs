﻿using UnityEngine;
using System.Collections;

public static class Textures {

	public static Texture2D HeightMapTexture(float[,] heightMap) {
		int width = heightMap.GetLength (0);
		int height = heightMap.GetLength (1);

		Color[] colourMap = new Color[width * height];
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				colourMap [y * width + x] = Color.Lerp (Color.black, Color.white, heightMap [x, y]);
			}
		}

		return ColorTexture (colourMap, width, height);
	}

	public static Texture2D ColorTexture(Color[] colourMap, int width, int height) {
		Texture2D texture = new Texture2D (width, height);
		texture.SetPixels (colourMap);
		texture.Apply ();
		return texture;
	}


	

}
