using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// VisualiseSoundManager
/// 
/// This script is used to recieve an audio source and process that though the audio analyser. 
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class VisualiseSoundManager : Singleton<VisualiseSoundManager>
{
    public int bumperNo; //bumper number set within unity inspector; represents the number of bumpers on the visualiser
    public int sampleNo; //sampple size to be set within unity inspector
    public FFTWindow FFTWindow; //FFTWindow represents the type of windowing function used to measure the signals
    public float[] bumperRange; //the bumper range is the frequency range of samples
    public float[] bumpers; // bumpers holds the amplitude of the bumpers, for audio channel 0
    public float[] bumpers1; // bumpers holds the amplitude of the bumpers, for audio channel 1
    public float[] samples; //array of floats used to pass in the windowed samples
    public float decay = .35f;

    private float minFreq;
    private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        //get audio component to recieve current sound
        audioSource = GetComponent<AudioSource>();
        //initalise samples array
        samples = new float[sampleNo];
        CreateFrequencyBumpers();
    }

    // Update is called once per frame
    void Update()
    {
        //getSpectrumData is making use of an FFT windowing function to break down the current audio into the samples float array
        //FFTWindow represents the windowing function used to measure a signal
        //Runs over both audio channels
        audioSource.GetSpectrumData(samples, 0, FFTWindow);
        bumperSamples();
        audioSource.GetSpectrumData(samples, 1, FFTWindow);
        bumperSamples1();

    }

    private void bumperSamples()
    {
        //runs through all of the bumpers, multiplying each ones amplitude by the decay value on audio channel 0
        for (int i = 0; i < bumperNo; i++)
        {
            bumpers[i] *= decay;
        }
        //create new var bumper to be passed into 
        var bumper = 0;
        for (int i = 0; i < sampleNo; i++)
        {
            bumper = bumperSample(bumper, i);
        }
    }

    private int bumperSample(int bumper, int i)
    {

        if (i * minFreq < bumperRange[bumper])
        {
            bumpers[bumper] += samples[i];
            return bumper;
        }
        else
        {
            return bumperSample(bumper + 1, i);
        }
    }

    private void bumperSamples1()
    {
        //runs through all of the bumpers, multiplying each ones amplitude by the decay value on audio channel 1
        for (int i = 0; i < bumperNo; i++)
        {
            bumpers1[i] *= decay;
        }
        var bin = 0;
        for (int i = 0; i < sampleNo; i++)
        {
            bin = bumperSample1(bin, i);
        }
    }

    private int bumperSample1(int bumper, int i)
    {
        if (i * minFreq < bumperRange[bumper])
        {
            bumpers1[bumper] += samples[i];
            return bumper;
        }
        else
        {
            return bumperSample1(bumper + 1, i);
        }
    }
    /// <summary>
    /// CreateFrequencyBumpers
    /// 
    /// The function creates the frequency range that converts our data from linear samples to a set number of bumpers.
    /// 
    /// This is utilised within Unity by setting our visualiser bumper value to 10 - therefore splitting the frequencies across 10 distinct coloured bumpers.
    /// </summary>
    private void CreateFrequencyBumpers()
    {
        //determines the max sample rate for audio data
        var maxFreq = AudioSettings.outputSampleRate / 2.0f;

        //calculates the minimum frequency
        minFreq = maxFreq / sampleNo;

        //bumperNo determines the number of bumpers featured on the visualiser, placing bumperNO into the arrays
        bumperRange = new float[bumperNo];
        bumpers = new float[bumperNo];
        bumpers1 = new float[bumperNo];
    
        //loops through all the bumpers
        for (int i = 0; i < bumperNo; i++)
        {
            //calculates the bumper range using LogSpace to convert the linear scale to a log scale
            bumperRange[i] = LogSpace(minFreq, maxFreq, i, bumperNo);
        }
    }

   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="start">start frequency</param>
    /// <param name="stop">stop s</param>
    /// <param name="pointToCompute">point to be computed </param>
    /// <param name="divideFrequency"> no. of points to divide the frequency range over</param>
    /// <returns></returns>
    float LogSpace(float start, float stop, int pointToCompute, int divideFrequency)
    {
        return start * Mathf.Pow(stop / start, pointToCompute / (float)(divideFrequency - 1));
    }
}
