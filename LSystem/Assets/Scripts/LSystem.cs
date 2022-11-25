using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LSystem : MonoBehaviour
{
    [HideInInspector]
    public SystemVariables system;
    public float variance = 10f;
    public GameObject Tree = null;
    public Image loader;
    public bool animate;
    public TMP_Text lengthText;
    public TMP_Text angleText;
    public TMP_Text iterationText;
    public GameObject variables;

    public Slider lengthSlider;
    public Slider angleSlider;
    public Slider iterationSlider;

    private float modelAngle;
    private float iteration;
    private float length;


    [SerializeField] private GameObject treeParent;
    [SerializeField] private GameObject Drawing;
    [SerializeField] private GameObject branch;
    [SerializeField] private GameObject leaf;

    private List<TransformData> transformStack = new List<TransformData>();

    private TransformData _transformData;

    private int listSize = -1;
    private string currentString = string.Empty;
    private Vector3 initialPosition = Vector3.zero;
    private string substitution;
    private bool rotation = false;
    private GameObject line;

    public void GetModel(SystemVariables model)
    {
        StopAllCoroutines();
        system = model;
        currentString = system.axiom;
        rotation = false;
        length = 4;
        iteration = system.iterations;
        modelAngle = system.angle;
        iterationSlider.maxValue = iteration;
        iterationSlider.SetValueWithoutNotify(iteration);
        angleSlider.SetValueWithoutNotify(modelAngle);
        lengthSlider.SetValueWithoutNotify(length);
        lengthText.text = length.ToString();
        angleText.text = modelAngle.ToString();
        iterationText.text = iteration.ToString();
        variables.SetActive(true);
    }

    public void OnIterationValueChange()
    {
        iteration = iterationSlider.value;
        iterationText.text = iteration.ToString();
        SetUpModel();
        StartDrawing();
    }
    public void OnAngleValueChange()
    {
        modelAngle = angleSlider.value;
        angleText.text = modelAngle.ToString();
        StartDrawing();
    }
    public void OnLenthValueChange()
    {
        length = lengthSlider.value;
        lengthText.text = length.ToString();
        StartDrawing();
    }

    public bool SetUpModel()
    {
        currentString = system.axiom;
        StopAllCoroutines();
        for (int i = 1; i < iteration; i++)
        {
            foreach (char c in currentString)
            {
                if ((c.Equals('*') || c.Equals('/')) && !rotation)
                    rotation = true;
                if (system.rules[0].letter.Equals(c))
                    substitution = $"{substitution}{system.rules[0].substitution}";
                else if (system.rules.Count > 1)
                {
                    if (system.rules[1].letter.Equals(c))
                        substitution = $"{substitution}{system.rules[1].substitution}";
                    else
                        substitution = $"{substitution}{c.ToString()}";
                }
                else
                    substitution = $"{substitution}{c.ToString()}";
            }

            currentString = substitution.ToString();
            substitution = string.Empty;
        }
        return rotation;

    }


    public void StartDrawing()
    {
        StopAllCoroutines();
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        StartCoroutine(DrawSystem());
    }
    IEnumerator DrawSystem()
    {
        loader.fillAmount = 0f;
        Destroy(Tree);
        Tree = Instantiate(treeParent);

        for (int i = 0; i < currentString.Length; i++)
        {
            switch (currentString[i])
            {
                case 'F':
                    initialPosition = transform.position;
                    transform.Translate(Vector3.up * length);
                    if (!rotation)
                        line = Instantiate(Drawing);
                    else
                        line = currentString[(i + 1) % currentString.Length] == 'X' || currentString[(i + 3) % currentString.Length] == 'F' && currentString[(i + 4) % currentString.Length] == 'X' ? Instantiate(leaf) : Instantiate(branch);
                    line.transform.SetParent(Tree.transform);
                    line.GetComponent<LineRenderer>().SetPosition(0, initialPosition);
                    line.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    break;

                case 'X':
                    break;

                case '+':
                    transform.Rotate(Vector3.forward * modelAngle);
                    break;

                case '-':
                    transform.Rotate(Vector3.back * modelAngle);
                    break;

                case '*':
                    transform.Rotate(Vector3.up * 120);
                    break;

                case '/':
                    transform.Rotate(Vector3.down * 120);
                    break;

                case '[':
                    _transformData.position = transform.position;
                    _transformData.rotation = transform.rotation;
                    transformStack.Add(_transformData);
                    listSize++;
                    break;

                case ']':
                    _transformData = transformStack[listSize];
                    transform.position = _transformData.position;
                    transform.rotation = _transformData.rotation;
                    transformStack.RemoveAt(listSize--);
                    break;

                default:
                    break;
            }
            if (animate)
                yield return null;
            loader.fillAmount = (float)i / currentString.Length;
        }
        loader.fillAmount = 1f;
        yield return null;
    }
}
