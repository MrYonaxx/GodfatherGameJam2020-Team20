using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;

	public List<AudioSource> MusicSource = new List<AudioSource>();
	public AudioSource SoundFx;
	float _volume = 0.5f;
	float _generalVolume = 1;
	float _sfxVolume = 0.5f;

	private int CurrentAudio = 0;

	// Use this for initialization
	void Awake()
	{
		if (Instance) Destroy(gameObject);
		else { Instance = this;
			DontDestroyOnLoad(Instance);
		}
		
		MusicSource[0].volume = 1;
		MusicSource[1].volume = 1;
	}

	private void Start()
	{
		if (GameManager.instance.musicMute)
		{
			MusicSource[0].mute = true;
			MusicSource[1].mute = true;
		}
		else
		{
			MusicSource[0].mute = false;
			MusicSource[1].mute = false;
		}

		if (GameManager.instance.sfxMute)
		{
			SoundFx.mute = true;
		}
		else
		{
			SoundFx.mute = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		/*
		if (MusicSource[CurrentAudio].volume < _volume)
		{
			if (CurrentAudio == 0)
			{
				MusicSource[1].volume -= Time.deltaTime;
			}
			else
			{
				MusicSource[0].volume -= Time.deltaTime;
			}
			MusicSource[CurrentAudio].volume += Time.deltaTime;
		}
		else
		{
			MusicSource[CurrentAudio].volume = _volume * _generalVolume;
		}

		//-- Gere le mute du Son et de la Musique --//
		if (GameManager.instance.musicMute)
		{
			MusicSource[0].mute = true;
			MusicSource[1].mute = true;
		}
		else
		{
			MusicSource[0].mute = false;
			MusicSource[1].mute = false;
		}

		if (GameManager.instance.sfxMute)
		{
			SoundFx.mute = true;
		}
		else
		{
			SoundFx.mute = false;
		}
		*/

	}

	public void PlayMusic(AudioClip Music, bool Loop = true, ulong Time = 0)
	{
		if (MusicSource[CurrentAudio].clip == Music)
		{
			return;
		}
		CurrentAudio = 0;
		MusicSource[0].clip = Music;
		MusicSource[0].loop = Loop;
		MusicSource[0].Play(Time);
		/*if (CurrentAudio == 0)
		{
			CurrentAudio = 1;
			MusicSource[1].clip = Music;
			MusicSource[1].loop = Loop;
			MusicSource[1].Play(Time);
		}
		else
		{
			CurrentAudio = 0;
			MusicSource[0].clip = Music;
			MusicSource[0].loop = Loop;
			MusicSource[0].Play(Time);
		}*/
	}
	public void StopMusic()
	{
		MusicSource[CurrentAudio].Pause();
	}
	public void PlayMusic()
	{
		MusicSource[CurrentAudio].Play();
	}

	public void PlaySfX(AudioClip SFX)
	{
		SoundFx.PlayOneShot(SFX);
	}

	public void SetVolume(float volume)
	{
		_volume = volume;
		MusicSource[CurrentAudio].volume = _volume;
	}

	public void SetSFXVolume(float volume)
	{
		_sfxVolume = volume;
		
		SoundFx.volume = _sfxVolume;
	}

	public void SetGeneralVolume(float volume)
	{
		_generalVolume = volume;
		MusicSource[CurrentAudio].volume = _volume * _generalVolume;
		
		SoundFx.volume = _sfxVolume * _generalVolume;
	}
}
