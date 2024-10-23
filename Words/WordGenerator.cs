using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class WordGenerator : MonoBehaviour
{
    public StringList words;
    public GameObject letterPrefab, duplicateLettersPrefab;
    public Transform canvasTransform, panelTransform;
    public GameActionAdvanced checkLetterNum, nextWord, letterCompleted;
    public IntData letterNumber;
    public int poolSize = 100;

    [SerializeField] private List<LetterObject> letterPool;

    [SerializeField] private List<LetterObject> duplicateLetterPool;

    private readonly WaitForSeconds wait = new(0.1f), wait2 = new(1f);

    // Initialized here instead of Start function
    private Dictionary<char, NameId> letterIdObjects { get; } = new();

    private Queue<LetterObject> inactiveLetters = new(), inactiveDuplicateLetters = new();

    [SerializeField] private List<LetterObject> activeLetters = new(), activeDuplicateLetters = new();
    [SerializeField] private List<Vector3> letterPositions = new();
    private const string LETTER = "Letter", DUPLICATELETTER = "DuplicateLetter";
    private bool _isRunning = false;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        checkLetterNum.RaiseNoArgs += CheckLetterNum;
        nextWord.RaiseNoArgs += Generate;
        letterCompleted.Raise += ReturnLetter;

        // Replaced original list initializations with InitializePool
        letterPool = InitializePool(letterPrefab, LETTER, poolSize);
        duplicateLetterPool = InitializePool(duplicateLettersPrefab, DUPLICATELETTER, poolSize);

        Generate();
    }
    
    private List<LetterObject> InitializePool(GameObject prefab, string name, int poolSize)
    {
        var pool = new List<LetterObject>();
        for (var i = 0; i < poolSize; i++)
        {
            var letterObj = Instantiate(prefab, transform);
            var letter = letterObj.GetComponent<LetterObject>();
            GameObject o;
            (o = letter.gameObject).SetActive(false);
            o.name = name;
            inactiveLetters.Enqueue(letter); // Add to the queue of inactive letters.
            pool.Add(letter);
        }

        return pool;
    }
    
    private void ReturnLetter(object obj)
    {
        var letter = obj as LetterObject;
        if (letter == null) return;

        switch (letter.name)
        {
            case LETTER:
                ReturnLetterToPool(letter);
                break;
            case DUPLICATELETTER:
                ReturnDuplicateLetterToPool(letter);
                break;
        }
    }
    
    private void CheckLetterNum()
    {
        words.CheckNum(letterNumber);
    }

    public void Generate()
    {
        foreach (var letter in letterPool.Where(letter => letter.gameObject.activeSelf))
        {
            letter.gameObject.SetActive(false);
        }

        foreach (var letter in duplicateLetterPool.Where(letter => letter.gameObject.activeSelf))
        {
            letter.gameObject.SetActive(false);
        }

        StartCoroutine(GenerateWord());
    }

    private void CreateLetterForPool()
    {
        var letterObj = Instantiate(letterPrefab, transform);
        var letter = letterObj.GetComponent<LetterObject>();
        GameObject o;
        (o = letter.gameObject).SetActive(false);
        o.name = "Letter";
        inactiveLetters.Enqueue(letter); // Add to the queue of inactive letters.
    }

    private void CreateDuplicateLetterForPool()
    {
        var duplicateLetterObj = Instantiate(duplicateLettersPrefab, transform);
        var duplicateLetter = duplicateLetterObj.GetComponent<LetterObject>();
        GameObject o;
        (o = duplicateLetter.gameObject).SetActive(false);
        o.name = "DuplicateLetter";
        inactiveDuplicateLetters.Enqueue(duplicateLetter); // Add to the queue of inactive duplicate letters.
    }

    private LetterObject ObtainLetterFromPool()
    {
        // If there are no available inactive letters, create a new one
        if (inactiveLetters.Count == 0)
        {
            CreateLetterForPool();
        }

        // Dequeue an inactive letter from the queue of inactive letters
        var letter = inactiveLetters.Dequeue();
        letter.gameObject.SetActive(true);

        activeLetters.Add(letter); // Move this letter to the list of active letters.

        return letter;
    }

    private LetterObject ObtainDuplicateLetterFromPool()
    {
        // If there are no available inactive duplicate letters, create a new one
        if (inactiveDuplicateLetters.Count == 0)
        {
            CreateDuplicateLetterForPool();
        }
        // Dequeue an inactive duplicate letter from the queue of inactive duplicate letters
        var duplicateLetter = inactiveDuplicateLetters.Dequeue();
        duplicateLetter.gameObject.transform.position = RandomScreenPosition();
        duplicateLetter.gameObject.SetActive(true);
        activeDuplicateLetters.Add(duplicateLetter); // Move this duplicate letter to the list of active duplicate letters.
        return duplicateLetter;
    }
    
    private void ReturnLetterToPool(LetterObject letter)
    {
        activeLetters.Remove(letter); // Remove this letter from the list of active letters.
        inactiveLetters.Enqueue(letter); // Add this letter to the queue of inactive letters.
        ResetLetterAsset(letter);
    }

    private void ReturnDuplicateLetterToPool(LetterObject duplicateLetter)
    {
        duplicateLetter.gameObject.SetActive(false);
        duplicateLetter.transform.parent = panelTransform;
        activeDuplicateLetters.Remove(duplicateLetter); // Remove this duplicate letter from the list of active duplicate letters.
        inactiveDuplicateLetters.Enqueue(duplicateLetter); // Add this duplicate letter to the queue of inactive duplicate letters.
        ResetLetterAsset(duplicateLetter);
    }

    private void ResetLetterAsset(LetterObject letterObject)
    {
        letterObject.textMesh.enabled = true;
        letterObject.image.enabled = true;
        letterObject.boxCollider.enabled = true;
    }
    
    private IEnumerator GenerateWord()
    {
        if (_isRunning)
        {
            yield break;
        }

        _isRunning = true;
        yield return wait2;
        _isRunning = false;
        
        letterNumber.Value = 0;
        // Deactivate all letters and duplicate letters from the pools
        foreach (var letter in letterPool.Where(letter => letter.gameObject.activeSelf))
        {
            letter.gameObject.SetActive(false);
        }

        var index = 0;
        for (; index < duplicateLetterPool.Count; index++)
        {
            var duplicateLetter = duplicateLetterPool[index];
            if (duplicateLetter.gameObject.activeSelf)
            {
                duplicateLetter.gameObject.SetActive(false);
            }
        }

        // Check if there are words left in the list to generate
        if (!words.IsNotEmpty())
        {
            yield break;
        }

        var word = words.CurrentLine;
        var letters = word.ToCharArray();

        // Generate each letter in the word
        foreach (var t in letters)
        {
            var letter = ObtainLetterFromPool();

            AssignPropertiesToLetter(t, letter, false);

            yield return wait;
        }

        // Generate random duplicate letters
        foreach (var t in letters)
        {
            var duplicateLetter = ObtainDuplicateLetterFromPool();

            AssignPropertiesToLetter(t, duplicateLetter, true);

            yield return wait;
        }

    }

    private void AssignPropertiesToLetter(char t, LetterObject letterObject, bool isDuplicate)
    {
        // Assign the NameId based on current letter
        if (!letterIdObjects.ContainsKey(t))
        {
            var nameId = ScriptableObject.CreateInstance<NameId>();
            nameId.name = t.ToString();
            letterIdObjects[t] = nameId;
        }

        letterObject.idBehaviour.ChangeId(letterIdObjects[t]);

        // Assign value to the letter and deactivate it
        letterObject.textMesh.text = t.ToString();
        letterObject.textMesh.enabled = false;
        letterObject.draggableBehaviour.enabled = false;

        if (isDuplicate)
        {
            letterObject.gameObject.transform.SetParent(canvasTransform);
            letterObject.transform.position = RandomScreenPosition();
            letterObject.textMesh.enabled = true;
            letterObject.image.enabled = false;
            letterObject.draggableBehaviour.enabled = true;
        }

        letterObject.gameObject.SetActive(true);
    }

    // Let's say this is a class level variable to keep track of previous letter positions.
    private Vector3 RandomScreenPosition()
    {
        // Define buffers.
        const int edgeBuffer = 15; // The amount of space to leave near the edges of the screen.
        const int centerBuffer = 40; // The amount of space to leave near the center of the screen.
        const int letterBuffer = 30; // The amount of space to maintain between each letter.

        // Define ranges for x and y values.
        var xRanges = new (float, float)[]
        {
            (edgeBuffer, Screen.width * 0.5f - centerBuffer), // Left side.
            (Screen.width * 0.5f  + centerBuffer, Screen.width - edgeBuffer) // Right side.
        };

        var yRanges = new (float, float)[]
        {
            (edgeBuffer, Screen.height * 0.5f  - centerBuffer), // Bottom.
            (Screen.height * 0.5f + centerBuffer, Screen.height - edgeBuffer) // Top.
        };

        // Declaring the tuples here.
        (float, float) xRange;
        (float, float) yRange;

        // Convert the screen position to a world position.
        Vector3 worldPosition;
        var attempts = 100; // Maximum attempts to avoid infinite loop.
        do
        {
            xRange = xRanges[Random.Range(0, xRanges.Length)];
            var x = Random.Range(xRange.Item1, xRange.Item2);

            yRange = yRanges[Random.Range(0, yRanges.Length)];
            var y = Random.Range(yRange.Item1, yRange.Item2);

            var position = new Vector3(x, y, 0);
            worldPosition = Camera.main.ScreenToWorldPoint(position);
            worldPosition.z = 90;
        } while (attempts-- > 0 && IsTooCloseToOtherLetters(worldPosition, letterBuffer));

        letterPositions.Add(worldPosition);
        return worldPosition;
    }
    
    private bool IsTooCloseToOtherLetters(Vector3 position, float buffer)
    {
        return letterPositions.Any(letterPosition => Vector3.Distance(position, letterPosition) < buffer);
    }
}