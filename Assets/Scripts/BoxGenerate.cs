using UnityEngine;

public class BoxGenerate : MonoBehaviour
{
	public BoxCollider ground;
	public Vector3 boxSize;

	int[] numOfBlock = {5, 0};
	char[,,] map = new [,,]
	{
		{
			{' ', ' ', ' ', ' ', '*'},
			{' ', ' ', ' ', ' ', '*'},
			{'*', '*', '*', ' ', '*'},
			{'*', ' ', ' ', ' ', '*'},
			{'*', ' ', ' ', ' ', '*'},
			{'*', ' ', '*', '*', '*'},
			{'*', ' ', ' ', ' ', '*'},
			{'*', ' ', ' ', ' ', '*'},
			{'*', '*', ' ', '*', '*'},
			{'*', ' ', ' ', ' ', '*'},
			{'*', ' ', ' ', ' ', '*'},
			{'*', '*', '*', ' ', '*'},
			{'*', ' ', ' ', ' ', '*'},
			{'*', ' ', ' ', ' ', '*'},
			{'*', '*', '*', '*', '*'},
		}
	};

	// Use this for initialization
	void Start()
	{
		boxSize = ground.size;
		CreateObstacle();
	}

	void CreateObstacle()
	{
		int currentMap = 0;
		int widthBlock = map.GetLength (2);
		int heightBlock = map.GetLength (1);
		Debug.Log (widthBlock + " " + heightBlock);
		for(int i=0; i<heightBlock; i++){
			for(int j=0; j<widthBlock; j++){
				if (map [currentMap, i, j] == '*') {
					float y = (boxSize.y * -1) * i;
					float x = boxSize.x * 3 * j;
					BoxCollider clone = (BoxCollider)Instantiate (ground, new Vector3 (x, y, 0), Quaternion.identity);
				}
			}
		}
	}
}