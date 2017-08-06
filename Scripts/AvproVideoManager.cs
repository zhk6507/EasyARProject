using UnityEngine;
using System.Collections;
using RenderHeads.Media.AVProVideo;
using UnityEngine.UI;

public class AvproVideoManager : MonoBehaviour {

    [SerializeField]
    MediaPlayer media;
    [SerializeField]
    Toggle startTog;
    [SerializeField]
    Slider seekSlider;
    [SerializeField]
    Button closeBtn;
    [SerializeField]
    Sprite[] sprits;
    [SerializeField]
    Image statt;
    private float _setVideoSeekSliderValue;
	// Use this for initialization
	void Start () {
        startTog.onValueChanged.AddListener(delegate(bool isOn)
        {
            if (isOn)
            {
                OnPlayButton();
                statt.sprite = sprits[0];
            }
            else
            {
                OnPauseButton();
                statt.sprite = sprits[1];
            }
        });
        seekSlider.onValueChanged.AddListener(delegate
        {
            OnVideoSeekSlider();
        });
        closeBtn.onClick.AddListener(delegate
        {
            OnRewindButton();
            OnStopButton();
            gameObject.SetActive(false);

        });
        media.m_VideoPath = "zhouxiangzhusaibeng.mp4";
        media.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, media.m_VideoPath, true);
	}
	
	// Update is called once per frame
	void Update () {
        if (media && media.Info != null && media.Info.GetDurationMs() > 0f)
        {
            float time = media.Control.GetCurrentTimeMs();
            float d = time / media.Info.GetDurationMs();
            _setVideoSeekSliderValue = d;
            seekSlider.value = d;
        }
	}
    public void OnPlayButton()
    {
        if (media)
        {
            media.Control.Play();
        }
    }
    public void OnPauseButton()
    {
        if (media)
        {
            media.Control.Pause();
        }
    }

    public void OnVideoSeekSlider()
    {
        if (media && seekSlider && seekSlider.value != _setVideoSeekSliderValue)
        {
            media.Control.Seek(seekSlider.value * media.Info.GetDurationMs());
        }
    }

    public void OnRewindButton()
    {
        if (media)
        {
            media.Control.Rewind();
        }
    }

    public void OnStopButton()
    {
        if (media)
        {
            media.Control.Stop();
        }
    }
}
