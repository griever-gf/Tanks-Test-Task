using UnityEngine;
using System.Collections;

public class MonstersManager : MonoBehaviour {

    public MonstersData monstersData;

    public MonstersData.MonsterParameters GetMonsterParams(int idx)
    {
        return monstersData.GetMonsterParameters(idx);
    }
}
