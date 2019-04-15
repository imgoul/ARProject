using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {

    private VideoPlayer video;
    private AudioSource Audiosource;
    public Slider videoslider;
    public Slider audioslider;
    public Text maxtime;
    public Text nowtime;
    public Text audiotext;
    public float number = 20;
    public GameObject PlayVideogame;
    private RawImage rawImage;

    private float time;
    private int hour;
    private int mint;

    private float time_count;
    private float time_current;
    private string url;
    private string url1;
    private bool isshow = false;
    private bool isvideo = false;

    public GameObject[] setui;
    private bool conceal = false;
    // Use this for initialization
    void Start()
    {
        rawImage = PlayVideogame.GetComponent<RawImage>();
        video = PlayVideogame.AddComponent<VideoPlayer>();
        Audiosource = PlayVideogame.AddComponent<AudioSource>();

        video.playOnAwake = false;
        
        Audiosource.playOnAwake = false;
        Audiosource.Pause();
       

        url1 = Application.dataPath + "/StreamingAssets/" + "video.mp4";
        url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
        Init(url);//初始化

        audioslider.value = Audiosource.volume;
        audiotext.text= string.Format("{0:0}%", Audiosource.volume * 100);
        audioslider.onValueChanged.AddListener(delegate { ChangeAudioSource(audioslider.value); });
        StartCoroutine(Conceal());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(video.isPlaying&&isshow)
        {
            rawImage.texture = video.texture;
            videoslider.maxValue = video.frameCount / video.frameRate;//总时长= 帧数/帧速率   如果是本地直接赋值的视频，我们可以通过VideoClip.length获取总时长

            time = videoslider.maxValue;
            hour = (int)time / 60;
            mint = (int)time % 60;
            maxtime.text= string.Format("  {0:D2}:{1:D2}", hour.ToString(), mint.ToString());
            videoslider.onValueChanged.AddListener(delegate { ChangeVideo(videoslider.value); });

            isshow = !isshow;
        }
        if (Mathf.Abs((int)video.time - (int)videoslider.maxValue) == 0)
        {
            video.frame = (long)video.frameCount;
            video.Stop();
            isvideo = false;
            return;
        }
        else if (isvideo && video.isPlaying)
        {
            time_count += Time.deltaTime;
            if ((time_count - time_current) >= 1)
            {
                videoslider.value += 1;
               // Debug.Log("value:" + videoslider.value);
                time_current = time_count;
            }
        }

    }

    public void Init(string urlpath)
    {
        isshow = true;
        isvideo = true;
        time_count = 0;
        time_current = 0;
        videoslider.value = 0;
        video.source = VideoSource.Url;
        video.url = urlpath;
        video.audioOutputMode = VideoAudioOutputMode.AudioSource;
        video.controlledAudioTrackCount = 1;
        video.SetTargetAudioSource(0, Audiosource);
        video.prepareCompleted += VideoprepareCompleted;//播放
        video.Prepare();//启动播放器

    }

    private void VideoprepareCompleted(VideoPlayer source)
    {
        source.Play();
    }

    public void ChangeAudioSource(float value)
    {
        Audiosource.volume = value;
        audiotext.text = string.Format("{0:0}%", value * 100);
    }

    public void ChangeVideo(float value)
    {
        if (video.isPrepared)
        {
            video.time = (long)value;
            //Debug.Log("VideoPlayer Time:" + video.time);
            time = (float)video.time;
            hour = (int)time / 60;
            mint = (int)time % 60;
            nowtime.text = string.Format("{0:D2}:{1:D2}", hour.ToString(), mint.ToString());
        }
    }

    public void Playvideos()
    {
        video.Play();
    }
    public void Pausevideo()
    {
        video.Pause();   
    }
    public void Stopvideo()
    {
        video.Stop();
    }
    public void Kuai()
    {
        videoslider.value += number;
    }
    public void Tui()
    {
        videoslider.value -= number;
    }
    public void Nextvideo()
    {
        video.Stop();
        Init(url1);
    }
    public void Back()
    {
        video.Stop();
        SceneManager.LoadScene(0);
       
    }

    public void Isconceal()
    {
        
        for (int i = 0; i < setui.Length; i++)
        {
            setui[i].SetActive(conceal);
        }
        conceal = !conceal;
    }
    
    IEnumerator Conceal()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < setui.Length; i++)
        {
            setui[i].SetActive(false);
        }
    }
}
