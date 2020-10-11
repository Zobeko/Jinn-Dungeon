using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] playlist;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioMixerGroup soundEffectsMixer;

    //Singleton de AudioManager
    public static AudioManager instance;


    private int musicIndex = 0;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il n'y a plus d'instance d'AudioManager dans la scene");
            return;
        }
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!audioSource.isPlaying)
        {
            PlayNextMusic();
        }
        
    }

    private void PlayNextMusic()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    //Methode remplacant PlayClipAtPoint() afin que l'AudioSoucre créée ait le bon Output (SoundEffects dansnotre cas)
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        //On crée le GameObject
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        //Création de l'audio source de tempGO
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();

        //On ajout le clip et le MixerGroup à tempGO
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectsMixer;
        //Onjoue le clip audio
        audioSource.Play();

        //On detruit tempGO apres que le son ait été joué (clip.length donne la durée du clip)
        Destroy(tempGO, clip.length);

        //On retourn l'audioSource de tempGO
        return audioSource;
    }

}
