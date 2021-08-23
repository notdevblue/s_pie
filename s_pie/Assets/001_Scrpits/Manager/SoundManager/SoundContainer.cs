using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundContainer : MonoBehaviour
{
    [Header("사운드 효과 프리팹을 SoundType 순서와 같게 넣어줘요.")]
    [SerializeField] private List<GameObject> soundEffectList = new List<GameObject>(); // Dictionary 초기화 용 soundEffectList

    private Dictionary<SoundType, GameObject> soundEffectDict = new Dictionary<SoundType, GameObject>(); // 실제로 사용하는 sound effect dictionary

    private int instObjectCount = 5; // inst 할 soundEffect 갯수

    void Awake()
    {
        InitDictionary();
    }

    // soundEffectDict 초기화 함수
    private void InitDictionary()
    {
        for (int i = 0; i < (int)SoundType.END_OF_ENUM; ++i)
        {
            try
            {
                for (int j = 0; j < instObjectCount; ++j)
                {
                    soundEffectDict.Add((SoundType)i, Instantiate(soundEffectList[i], this.transform));
                }
            }
            catch // 예외
            {
                Debug.LogError($"SoundContainer: Dictionary 값 입력 중 에러가 발생했어요."
                        + "\r\nSoundEffectList.Count: {soundEffectList.Count}\r\nSonudType.END_OF_ENUM: {(int)SoundType.END_OF_ENUM}"
                        + "\r\n만약 이 두 숫자가 같지 않다면 Enum 또는 List 를 확인하세요.");
                
                this.enabled = false;
            }
        }
    }

    /// <summary>
    /// 사운드 효과음을 하나 가져옵니다.
    /// </summary>
    /// <param name="key">가져올 효과음의 타입</param>
    /// <returns>Gameobject of soundEffect<br>null when dictionary does not contains key</returns>
    public GameObject GetSound(SoundType key)
    {
        if(!soundEffectDict.ContainsKey(key))
        {
            Debug.LogWarning($"SoundContainer: 요청한 Key {key} 를 찾을 수 없습니다.");
            return null;
        }

        return null; // TODO : GetSound
    }
}
