using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    public Vector3[] redCubeLocations, greenCubeLocations, blueCubeLocations;
    public List<GameObject> greenCubes = new List<GameObject>();
    public List<GameObject> redCubes = new List<GameObject>();
    public List<GameObject> blueCubes = new List<GameObject>();
    void Start()
    {

        for (int i = 0; i < redCubeLocations.Length; i++)
        {
            redCubes.Add(Instantiate(cube, redCubeLocations[i], Quaternion.identity));
            redCubes[i].GetComponent<CubeCollider>().controller=this;
        }
        for (int i = 0; i < greenCubeLocations.Length; i++)
        {
            greenCubes.Add(Instantiate(cube, greenCubeLocations[i], Quaternion.identity));
            greenCubes[i].GetComponent<CubeCollider>().controller = this;

        }
        for (int i = 0; i < blueCubeLocations.Length; i++)
        {
            blueCubes.Add(Instantiate(cube, blueCubeLocations[i], Quaternion.identity));
            blueCubes[i].GetComponent<CubeCollider>().controller = this;

        }

        resetCubes();

    }
    public void resetCubes()
    {
        foreach (GameObject cube in redCubes)
        {
            cube.GetComponent<SpriteRenderer>().color = Color.red;
        }
        foreach (GameObject cube in greenCubes)
        {
            cube.GetComponent<SpriteRenderer>().color = Color.green;
        }
        foreach (GameObject cube in blueCubes)
        {
            cube.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    public void randomizeCubesColor(GameObject c)
    {
        Color newColor = new Color(Random.value, Random.value, Random.value);
        if (redCubes.Contains(c))
        {
            foreach (GameObject cube in redCubes)
            {
                cube.GetComponent<SpriteRenderer>().color = newColor;
            }
        }
        else if (greenCubes.Contains(c))
        {
            foreach (GameObject cube in greenCubes)
            {
                cube.GetComponent<SpriteRenderer>().color = newColor;
            }
        }
        else if (blueCubes.Contains(c))
        {
            foreach (GameObject cube in blueCubes)
            {
                cube.GetComponent<SpriteRenderer>().color = newColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
