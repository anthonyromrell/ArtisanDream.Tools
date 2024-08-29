using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class NewColorGenerator : MonoBehaviour
{
    public ColorDataList colors;
    public GameObject colorPrefab;
    public GameObject duplicateColorsPrefab;
    public Transform canvasTransform;
    private float minDistance = 30f;
    private List<Vector3> usedPositions = new List<Vector3>();
    private WaitForSeconds wait = new(0.1f), wait2 = new(1f);
    private Dictionary<string, NameId> colorIdObjects = new Dictionary<string, NameId>();
    public GameAction checkColorNum, nextColor, destroyAllColors;
    public IntData colorNumber;

    private List<GameObject> colorPool = new List<GameObject>();
    private List<GameObject> duplicateColorPool = new List<GameObject>();
    private List<Vector3> colorPositions;

    private void Start()
    {
        colorPositions = new List<Vector3>();
        checkColorNum.RaiseNoArgs += CheckColorNum;
        nextColor.RaiseNoArgs += Generate;
        InitializeObjectPools();
        Generate();
    }

    private void InitializeObjectPools()
    {
        for (int i = 0; i < 50; i++)
        {
            CreateColorForPool();
            CreateDuplicateColorForPool();
        }
    }

    private void CreateColorForPool()
    {
        GameObject color = Instantiate(colorPrefab, transform);
        color.SetActive(false);
        colorPool.Add(color);
    }

    private void CreateDuplicateColorForPool()
    {
        GameObject duplicateColor = Instantiate(duplicateColorsPrefab, transform);
        duplicateColor.SetActive(false);
        duplicateColorPool.Add(duplicateColor);
    }

    private GameObject ObtainColorFromPool()
    {
        if (colorPool.Count > 0)
        {
            GameObject pooledColor = colorPool[0];
            colorPool.RemoveAt(0);
            return pooledColor;
        }
        else
        {
            CreateColorForPool();
            return ObtainColorFromPool();
        }
    }

    private GameObject ObtainDuplicateColorFromPool()
    {
        if (duplicateColorPool.Count > 0)
        {
            GameObject pooledColor = duplicateColorPool[0];
            duplicateColorPool.RemoveAt(0);
            return pooledColor;
        }
        else
        {
            CreateDuplicateColorForPool();
            return ObtainDuplicateColorFromPool();
        }
    }

    private void ReturnColorToPool(GameObject color)
    {
        color.SetActive(false);
        color.transform.SetParent(transform);
        colorPool.Add(color);
    }

    private void ReturnDuplicateColorToPool(GameObject duplicateColor)
    {
        duplicateColor.SetActive(false);
        duplicateColor.transform.SetParent(transform);
        duplicateColorPool.Add(duplicateColor);
    }

    private void CheckColorNum()
    {
        colors.CheckNum(colorNumber);
    }

    public void Generate()
    {
        StartCoroutine(GenerateColor());
    }

    private IEnumerator GenerateColor()
    {
        colorNumber.Value = 0;
        yield return wait2;
        destroyAllColors.RaiseAction();
        yield return wait2;

        if (!colors.IsNotEmpty())
            yield break;

        ColorData color = colors.CurrentColor;

        if (!colorIdObjects.ContainsKey(color.name))
        {
            var nameId = ScriptableObject.CreateInstance<NameId>();
            nameId.name = color.name;
            colorIdObjects[color.name] = nameId;
        }

        yield return wait;
        var colorElement = ObtainColorFromPool();
        colorElement.name = color.name;
        colorElement.SetActive(true);

        yield return wait;
        var duplicateColorElement = ObtainDuplicateColorFromPool();
        duplicateColorElement.name = color.name;
        duplicateColorElement.SetActive(true);

        var colorIdBehaviour = colorElement.GetComponent<IdBehaviour>();
        var duplicateColorIdBehaviour = duplicateColorElement.GetComponent<IdBehaviour>();

        if (colorIdBehaviour != null)
        {
            colorIdBehaviour.ChangeId(colorIdObjects[color.name]);
        }

        if (duplicateColorIdBehaviour != null)
        {
            duplicateColorIdBehaviour.ChangeId(colorIdObjects[color.name]);
        }

        colors.IncrementLineNumber();
    }

    Vector3 RandomScreenPosition()
    {
        // Define buffers.
        float edgeBuffer = 15; // The amount of space to leave near the edges of the screen.
        float centerBuffer = 40; // The amount of space to leave near the center of the screen.
        float letterBuffer = 30; // The amount of space to maintain between each letter.

        // Define ranges for x and y values.
        (float, float)[] xRanges = new (float, float)[]
        {
            (edgeBuffer, Screen.width / 2 - centerBuffer), // Left side.
            (Screen.width / 2 + centerBuffer, Screen.width - edgeBuffer) // Right side.
        };

        (float, float)[] yRanges = new (float, float)[]
        {
            (edgeBuffer, Screen.height / 2 - centerBuffer), // Bottom.
            (Screen.height / 2 + centerBuffer, Screen.height - edgeBuffer) // Top.
        };

        // Declaring the tuples here.
        (float, float) xRange;
        (float, float) yRange;

        // Convert the screen position to a world position.
        Vector3 worldPosition;
        int attempts = 100; // Maximum attempts to avoid infinite loop.
        do
        {
            xRange = xRanges[Random.Range(0, xRanges.Length)];
            float x = Random.Range(xRange.Item1, xRange.Item2);

            yRange = yRanges[Random.Range(0, yRanges.Length)];
            float y = Random.Range(yRange.Item1, yRange.Item2);

            var position = new Vector3(x, y, 0);
            worldPosition = Camera.main.ScreenToWorldPoint(position);
            worldPosition.z = 90;
        } while (attempts-- > 0 && IsTooCloseToOtherLetters(worldPosition, letterBuffer));

        // Add the position into list after making sure it's not too close to other letters.
        colorPositions.Add(worldPosition);

        return worldPosition;
    }

    bool IsTooCloseToOtherLetters(Vector3 position, float buffer)
    {
        foreach (Vector3 letterPosition in colorPositions)
        {
            if (Vector3.Distance(position, letterPosition) < buffer)
            {
                return true; // It's too close.
            }
        }

        return false; // It's not too close.
    }
}