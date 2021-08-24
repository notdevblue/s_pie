using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayManager : MonoBehaviour
{
    [Header("사운드 효과 프리팹을 SoundType 순서와 같게 넣어줘요.")]
    [SerializeField] private List<GameObject> soundEffectList = new List<GameObject>(); // Dictionary 초기화 용 soundEffectList

    private Dictionary<SoundType, List<GameObject>> soundEffectDict = new Dictionary<SoundType, List<GameObject>>(); // 실제로 사용하는 sound effect dictionary

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
                soundEffectDict.Add((SoundType)i, new List<GameObject>()); // 일단 메모리를 잡음

                for (int j = 0; j < instObjectCount; ++j)
                {
                    GameObject temp = Instantiate(soundEffectList[i], this.transform);
                    soundEffectDict[(SoundType)i].Add(temp);
                }
            }
            catch(System.Exception e) // 예외
            {
                Debug.LogError($"SoundPlayManager: Dictionary 값 입력 중 에러가 발생했어요."
                        + $"\r\nSoundEffectList.Count: {soundEffectList.Count}\r\nSonudType.END_OF_ENUM: {(int)SoundType.END_OF_ENUM}"
                        + "\r\n만약 이 두 숫자가 같지 않다면 Enum 또는 List 를 확인하세요.");
                Debug.LogError(e);

                this.enabled = false;
                gameObject.SetActive(false);
                return;
            }
        }
    }

    /// <summary>
    /// 사운드 효과음을 하나 가져옵니다.
    /// </summary>
    /// <param name="key">가져올 효과음의 타입</param>
    /// <returns>Gameobject of soundEffect<br>null when dictionary does not contains key</returns>
    public void PlaySound(SoundType key)
    {
        if (!soundEffectDict.ContainsKey(key))
        {
            Debug.LogWarning($"SoundPlayManager: 요청한 Key {key} 를 찾을 수 없습니다.");
            return;
        }

        GameObject sound = soundEffectDict[key].Find(x => !x.GetComponent<AudioSource>().isPlaying); // TODO : 이건 좀 에바지

        if(sound == null) // 다 플레이 중인 경우
        {
            sound = Instantiate(soundEffectList[(int)key], this.transform);
            soundEffectDict[key].Add(sound);
        }

        sound.GetComponent<AudioSource>().Play();
    }
}
