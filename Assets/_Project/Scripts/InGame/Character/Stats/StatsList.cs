using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using System.Collections;
#endif

[Serializable]
public class StatsList
{
    [SerializeField]
    [ValueDropdown("CustomAddStatsButton", IsUniqueList = true, DrawDropdownForListElements = false,
        DropdownTitle = "Modify Stats")]
    [ListDrawerSettings(DraggableItems = false, ShowFoldout = false)]
    private List<StatsValue> stats = new();

    public StatsValue this[int index]
    {
        get => stats[index];
        set => stats[index] = value;
    }

    public List<StatsValue> Stats => stats;

    public int Count => stats.Count;
#if UNITY_EDITOR
    // Finds all available stat-types and excludes the types that the statList already contains, so we don't get multiple entries of the same type.
    private IEnumerable CustomAddStatsButton()
    {
        return Enum.GetValues(typeof(StatsType)).Cast<StatsType>()
            .Except(this.stats.Select(x => x.Type))
            .Select(x => new StatsValue(x))
            .AppendWith(this.stats)
            .Select(x => new ValueDropdownItem(x.Type.ToString(), x));
    }
#endif
}

#if UNITY_EDITOR

// 
// Since the StatList is just a class that contains a list, all StatLists would contain an extra 
// label with a foldout in the inspector, which we don't want.
// 
// So with this drawer, we simply take the label of the member that holds the StatsList, and render the 
// actual list using that label.
//
// So instead of the "private List<StatValue> stats" field getting a label named "Stats"
// It now gets the label of whatever member holds the actual StatsList
// 
// If this confuses you, try out commenting the drawer below, and take a look at an item in the RPGEditor to see 
// the difference.
// 

internal class StatListValueDrawer : OdinValueDrawer<StatsList>
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        // This would be the "private List<StatValue> stats" field.
        this.Property.Children[0].Draw(label);
    }
}

#endif

public enum StatsType
{
    Health,
    Damage,
    Speed,
    Mana,
    AttackRange,
    AttackSpeed,
    Armor,
    Critical,
    CriticalDamage,
}