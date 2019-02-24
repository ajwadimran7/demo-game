using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Add this component to your Cinemachine Virtual Camera to have it shake when calling its ShakeCamera methods.
/// </summary>
public class CinemachineCameraShaker : MonoBehaviour
{
	/// the amplitude of the camera's noise when it's idle
	public float IdleAmplitude = 0.1f;
	/// the frequency of the camera's noise when it's idle
	public float IdleFrequency = 1f;
	
	/// The default amplitude that will be applied to your shakes if you don't specify one
	public float DefaultShakeAmplitude = .5f;
	/// The default frequency that will be applied to your shakes if you don't specify one
	public float DefaultShakeFrequency = 10f;

	protected Vector3 _initialPosition;
	protected Quaternion _initialRotation;

	protected Cinemachine.CinemachineBasicMultiChannelPerlin _perlin;
	protected Cinemachine.CinemachineVirtualCamera _virtualCamera;

	/// <summary>
	/// On awake we grab our components
	/// </summary>
	protected virtual void Awake () 
	{
		_virtualCamera = GameObject.FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
		_perlin = _virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin> ();
	}		

	/// <summary>
	/// On Start we reset our camera to apply our base amplitude and frequency
	/// </summary>
	protected virtual void Start()
	{		
		CameraReset ();
	}

	/// <summary>
	/// Use this method to shake the camera for the specified duration (in seconds) with the default amplitude and frequency
	/// </summary>
	/// <param name="duration">Duration.</param>
	public virtual void ShakeCamera (float duration)
	{
		StartCoroutine (ShakeCameraCo (duration, DefaultShakeAmplitude, DefaultShakeFrequency));
	}

	/// <summary>
	/// Use this method to shake the camera for the specified duration (in seconds), amplitude and frequency
	/// </summary>
	/// <param name="duration">Duration.</param>
	/// <param name="amplitude">Amplitude.</param>
	/// <param name="frequency">Frequency.</param>
	public virtual void ShakeCamera (float duration, float amplitude, float frequency)
	{
		StartCoroutine (ShakeCameraCo (duration, amplitude, frequency));
	}

	/// <summary>
	/// This coroutine will shake the 
	/// </summary>
	/// <returns>The camera co.</returns>
	/// <param name="duration">Duration.</param>
	/// <param name="amplitude">Amplitude.</param>
	/// <param name="frequency">Frequency.</param>
	protected virtual IEnumerator ShakeCameraCo(float duration, float amplitude, float frequency)
	{
		_perlin.m_AmplitudeGain = amplitude;
		_perlin.m_FrequencyGain = frequency;
		yield return new WaitForSeconds (duration);
		CameraReset ();
	}

	/// <summary>
	/// Resets the camera's noise values to their idle values
	/// </summary>
	public virtual void CameraReset()
	{
		_perlin.m_AmplitudeGain = IdleAmplitude;
		_perlin.m_FrequencyGain = IdleFrequency;
	}

}