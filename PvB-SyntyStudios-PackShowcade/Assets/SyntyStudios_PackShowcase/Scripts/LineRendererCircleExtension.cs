using UnityEngine;

//Credit: Kurtdekker - https://github.com/kurtdekker/makegeo/blob/master/makegeo/Assets/2d/makeringlinerenderer/LineRendererUtility.cs
public class LineRendererCircleExtension
{
	public static void MakeRing(Vector3 center, LineRenderer lineRenderer, float radius, int segments)
	{
		Vector3[] points = new Vector3[segments];

		for (int i = 0; i < segments; i++)
		{
			float angle = (i * Mathf.PI * 2) / segments;

			float x = Mathf.Cos( angle) * radius;
			float z = Mathf.Sin( angle) * radius;

			points[i] = new Vector3( x, 0, z) + center;
		}

		lineRenderer.positionCount = segments;
		lineRenderer.SetPositions( points);
	}
}