


using UnityEngine;

public class BoxGenerate : MonoBehaviour
{
	public BoxCollider ground;
	public BoxCollider enermy;
	public Vector3 boxSize;

	int[] numOfBlock = {5, 0};
	char[,,] map = new [,,]
	{
		{
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
			{'*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
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
		int lengthBlock = map.GetLength (1);
		Debug.Log (widthBlock + " " + lengthBlock);
		for(int i=0; i<lengthBlock; i++){
			for(int j=0; j<widthBlock; j++){
				if (map [currentMap, i, j] == '*') {
					float z = boxSize.z * i;
					float x = boxSize.x * j;
					//if (j < widthBlock / 2) {
					//	x = boxSize.x * -3 * j;
					//} else {
					//	x = boxSize.x * 3 * j;
					//}
					BoxCollider clone = (BoxCollider)Instantiate (ground, new Vector3 (x - (widthBlock/2), -2, z - (lengthBlock/2)), Quaternion.identity);
				}
			}
		}
	}
}