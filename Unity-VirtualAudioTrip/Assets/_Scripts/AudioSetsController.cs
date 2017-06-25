using UnityEngine;

public class AudioSetsController : MonoBehaviour {
    [SerializeField] AudioSource[] sources;

    [SerializeField] AudioClip[] set1;
    [SerializeField] AudioClip[] set2;
    [SerializeField] AudioClip[] set3;

    AudioClip[][] sets = new AudioClip[3][];

    const int JumpTimeInSeconds = 60;

    void Awake() {
        sets[0] = set1;
        sets[1] = set2;
        sets[2] = set3;
        SkipFirstMinuteForAllSources();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            LoadSet(0);
        if(Input.GetKeyDown(KeyCode.Alpha2))
            LoadSet(1);
        if(Input.GetKeyDown(KeyCode.Alpha3))
            LoadSet(2);
        if(Input.GetKeyDown(KeyCode.Plus))
            UpVolumeForAllSources();
        if(Input.GetKeyDown(KeyCode.Minus))
            DownVolumeForAllSources();
        if (Input.GetKeyDown(KeyCode.Comma))
            JumpInTimeForAllSources(-JumpTimeInSeconds);
        if (Input.GetKeyDown(KeyCode.Period))
            JumpInTimeForAllSources(JumpTimeInSeconds);
    }

    void LoadSet(int id) {
        for (var i = 0; i < 6; i++) {
            sources[i].Stop();
            sources[i].clip = sets[id][i];
            sources[i].Play();
        }
        SkipFirstMinuteForAllSources();
    }

    void SkipFirstMinuteForAllSources() {
        foreach (var source in sources)
            SkipFirstMinute(source);
    }

    void SkipFirstMinute(AudioSource source) {
        source.time = 60;
    }

    void JumpInTimeForAllSources(int seconds) {
        foreach (var source in sources)
            JumpInTime(source, seconds);
    }

    void JumpInTime(AudioSource source, int seconds) {
        if (!(source.time + seconds < source.clip.length))
            return;
        if (source.time + seconds < 0) {
            source.time = 0;
            return;
        }
        source.time += seconds;
    }

    void DownVolumeForAllSources() {
        foreach (var source in sources)
            DownVolume(source);
    }

    void DownVolume(AudioSource source) {
        source.volume -= 0.1f;
    }

    void UpVolumeForAllSources() {
        foreach (var source in sources)
            UpVolume(source);
    }

    void UpVolume(AudioSource source) {
        source.volume += 0.1f;
    }
}
