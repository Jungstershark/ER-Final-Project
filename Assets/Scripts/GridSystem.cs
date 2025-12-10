using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

/* 
Ini
*/

public class GridSystem : MonoBehaviour
{
    public static GridSystem Instance;
    public Dictionary<List<(int, int)>, UnityEvent> spellBook;
    public List<(int, int)> currentCombi;
    public bool activated;
    public List<List<(int, int)>> grid;
    public List<List<GameObject>> objectGrid;
    public (int, int) startPoint;
    public int totalRows;
    public int totalCols;
    public OrbConnector orbConnector;
    public UnityEvent Shatter;
    public UnityEvent Magnet;
    public UnityEvent Restart;
    public GameObject orb00;
    public GameObject orb01;
    public GameObject orb02;
    public GameObject orb10;
    public GameObject orb11;
    public GameObject orb12;
    public GameObject orb20;
    public GameObject orb21;
    public GameObject orb22;


    public void Start()
    {
        this.spellBook = new Dictionary<List<(int, int)>, UnityEvent>
        {
            { new List<(int, int)> { (0, 1), (1, 0), (1, 1), (1, 2), (2, 1) }, Shatter },
            { new List<(int, int)> { (0, 0), (0, 1), (0, 2), (1, 1), (2, 0), (2, 1), (2, 2), (1, 1), (0, 0)}, Restart },
            { new List<(int, int)> { (2, 0), (1, 0), (0, 0), (0, 1), (0, 2), (1, 2), (2, 2) }, Magnet }
        };

        this.activated = false;
        this.startPoint = (-1, -1);
        this.grid = new List<List<(int, int)>>();
        this.currentCombi = new List<(int, int)>();
        this.objectGrid = ObjectGridCreate();
        this.totalRows = 3;
        this.totalCols = 3;

        for (int i = 0; i < this.totalRows; i++)
        {
            List<(int, int)> sublist = new List<(int, int)>();
            for (int j = 0; j < this.totalCols; j++)
            {
                sublist.Add((-1, -1));
            }
            this.grid.Add(sublist);
        }
    }

    public void Test()
    {
        Debug.Log("Grid System working");
    }

    public List<List<GameObject>> ObjectGridCreate()
    {
        objectGrid = new List<List<GameObject>>();
        List<GameObject> row1 = new List<GameObject>();
        row1.Add(orb00);
        row1.Add(orb01);
        row1.Add(orb02);
        objectGrid.Add(row1);
        List<GameObject> row2 = new List<GameObject>();
        row2.Add(orb10);
        row2.Add(orb11);
        row2.Add(orb12);
        objectGrid.Add(row2);
        List<GameObject> row3 = new List<GameObject>();
        row3.Add(orb20);
        row3.Add(orb21);
        row3.Add(orb22);
        objectGrid.Add(row3);
        return objectGrid;
    }

    public void RegisterOrbClick(int row, int col)
    {
        Debug.Log("Registered Click on " + row.ToString() +  ' ' + col.ToString());
        this.currentCombi.Add((row, col));
        if (this.startPoint.Item1 == -1 && this.startPoint.Item2 == -1)
        {
            this.startPoint = (row, col);
            orbConnector.NewNode(objectGrid[row][col]);
        }
        else
        {
            var prev = (-1, -1);
            var curr = this.startPoint;
            while (curr != (-1, -1))
            {
                prev = curr;
                curr = this.grid[curr.Item1][curr.Item2];
            }
            if (prev.Item1 != row && prev.Item2 != col)
            {
                this.drawLine(prev, (row, col));
            }
        }
    }

    public bool isActivated()
    {
        return this.activated;
    }

    public void toggleActivation()
    {
        if (this.activated)
        {
            this.activated = false;
            Debug.Log("Grid System deactivated");
        }
        else
        {
            this.activated = true;
            Debug.Log("Grid System activated");
        }
    }

    private bool validatePointBounds(int row, int col)
    {
        if (row > this.totalRows - 1 || col > this.totalCols - 1)
        {
            return false;
        }
        return true;
    }

    public void drawLine((int, int) from, (int, int) to)
    {
        // add a line to the combination

        if (this.validatePointBounds(to.Item1, to.Item2) && this.validatePointBounds(from.Item1, from.Item2))
        {
            if (!from.Equals(to))
            {
                this.grid[from.Item1][from.Item2] = to;
                if (this.startPoint == (-1, -1))
                {
                    this.startPoint = from;
                    //this.objectGrid[from.Item1][from.Item2].OrbSelected();
                }
                //this.objectGrid[to.Item1][to.Item2].OrbSelected();
                orbConnector.NewNode(this.objectGrid[to.Item1][to.Item2]);
                Debug.Log($"Line drawn from {from} to {to}");
            }
        }
    }

    public void removeLine((int, int) from, (int, int) to)
    {
        // remove a line in the combination
        if (from == (this.startPoint))
        {
            this.startPoint = (-1, -1);
        }
        this.grid[from.Item1][from.Item2] = (-1, -1);
    }

    public List<(int, int)> currentCombination()
    {
        // returns current combination of points as a List
        List<(int, int)> output = new List<(int, int)>();
        (int, int) currentPoint = this.startPoint;

        while (currentPoint != (-1, -1))
        {
            output.Add(currentPoint);
            currentPoint = this.grid[currentPoint.Item1][currentPoint.Item2];
        }
        return output;
    }

    public void checkSpell()
    {
        // check if current combination matches any spells in spellBook. 
        // if yes, invoke UnityEvent of spell

        //List<(int, int)> current = this.currentCombination();
        List<(int, int)> current = this.currentCombi;
        foreach (KeyValuePair<List<(int, int)>, UnityEvent> spell in this.spellBook)
        {
            if (spell.Key.SequenceEqual(current))
            {
                this.spellBook[spell.Key].Invoke();
                Debug.Log("Casting something...");
            }
        }
    }
}