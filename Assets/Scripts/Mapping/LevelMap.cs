using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    public float[] MapLevel1 = new float[]
{
       9.604207f, 10.51318f, 11.67496f, 12.33195f, 12.86195f, 13.99764f, 14.58965f, 15.20194f,
    15.73268f, 16.26008f, 16.83283f, 17.44492f, 18.01296f, 18.60599f, 19.85686f, 20.95654f,
    23.19416f, 23.78788f, 24.37799f, 25.01545f, 25.60839f, 27.84754f, 28.35668f, 28.92618f,
    30.13483f, 30.68699f, 31.26083f, 32.42392f, 32.99582f, 33.52352f, 34.72945f, 35.25789f,
    35.84932f, 37.07681f, 37.6265f, 38.1168f, 39.3658f, 39.91845f, 40.40533f, 41.5928f,
    42.1899f, 42.74044f, 43.9683f, 44.53799f, 45.07123f, 46.25828f, 48.03228f, 48.60577f,
    50.27384f, 50.86784f, 52.59684f, 53.21115f, 54.94287f, 55.66629f, 57.21086f, 57.78436f,
    59.56561f, 60.18021f, 61.32087f, 62.43888f, 63.60185f, 64.78725f, 66.03713f, 67.03063f,
    67.73122f, 68.28562f, 69.36264f, 69.99757f, 70.61086f, 71.1185f, 71.71177f, 72.2858f,
    72.83721f, 73.41184f, 73.98442f, 75.20902f, 76.28734f, 78.516f, 79.10934f, 79.74299f,
    80.2933f, 80.95087f, 83.19565f
};


    public float[] MapLevel2 = new float[]
   {
        0.3558038f, 1.16153f, 1.753502f, 2.283593f, 3.237315f, 4.142226f, 5.133306f, 5.658375f,
    6.248289f, 7.197284f, 8.147362f, 9.136614f, 9.684444f, 10.21227f, 11.248f, 12.11325f,
    13.0804f, 13.67341f, 14.24222f, 14.81132f, 15.2973f, 16.2641f, 17.23559f, 18.22851f,
    19.19833f, 20.19041f, 21.20238f, 22.21217f, 23.20172f, 24.17158f, 25.14224f, 25.66837f,
    26.23688f, 27.26695f, 28.17366f, 29.16394f, 29.66959f, 30.1976f, 31.14792f, 32.13901f,
    33.06696f, 33.61439f, 34.20454f, 35.23944f, 36.10901f, 37.05821f, 37.65018f, 38.19663f,
    38.76517f, 39.29102f, 40.34113f, 41.30893f, 42.32017f, 44.33989f, 45.3088f, 46.29766f,
    48.25916f, 49.21115f, 49.92733f, 50.41285f, 51.27715f, 52.27001f, 53.15525f, 53.68269f,
    54.23262f, 55.19985f, 56.19f, 57.07421f, 57.66534f, 58.25441f, 59.22189f, 60.19472f,
    61.16356f, 61.73267f, 62.27902f, 62.74233f, 63.24736f, 64.28098f, 65.16953f, 66.28745f,
    67.27696f, 68.26792f, 69.25398f, 70.26976f, 71.32593f, 72.22988f, 72.90698f, 73.39262f,
    73.6261f, 74.236f, 74.7639f, 75.31372f, 75.56815f, 76.24552f, 76.7282f, 77.29869f,
    77.50856f, 78.24512f, 78.60482f, 78.87964f, 79.19767f
   };

    public float[] MapLevel3 = new float[]
   {

       0.2745181f, 2.008828f, 2.642051f, 4.584166f, 5.25978f, 5.896485f, 6.48755f, 7.124531f,
        7.80077f, 8.413867f, 9.024087f, 9.704713f, 10.31867f, 10.93196f, 11.52265f, 12.13341f,
        12.80869f, 13.42256f, 14.10013f, 14.73415f, 15.36874f, 16.02728f, 16.59924f, 17.21389f,
        17.84633f, 18.48259f, 19.16033f, 19.77459f, 20.45342f, 21.04638f, 21.677f, 22.28992f,
        22.92369f, 23.53565f, 24.19134f, 24.8248f, 25.46143f, 27.02271f, 27.84935f, 29.60428f,
        30.4499f, 32.17126f, 32.97904f, 33.63792f, 34.27282f, 35.53584f, 37.18248f, 38.00764f,
        39.7152f, 40.52188f, 42.25073f, 43.03036f, 43.70644f, 44.31794f, 45.71196f, 46.34332f,
        46.9189f, 47.51023f, 48.1858f, 48.79792f, 49.43387f, 50.08844f, 50.74379f, 51.29741f,
        51.97598f, 52.60898f, 53.22185f, 53.8132f, 54.47008f, 55.12574f, 55.78472f, 56.41836f,
        57.05169f, 57.62471f, 58.28331f, 58.89831f, 59.5532f, 60.14501f, 60.82498f, 61.44044f,
        62.05231f, 62.69053f, 63.34681f, 63.9366f, 64.57192f, 65.18802f, 65.90683f, 67.41064f,
        68.25671f, 70.03245f, 70.85789f, 72.63858f, 73.4215f, 74.03372f, 74.68985f, 75.9117f,
        77.71075f, 78.45177f, 80.07804f, 80.8393f, 82.61206f, 83.43437f, 84.13064f, 84.76323f

   };

    public float[] MapLevel4 = new float[]
   {
        0.3079802f, 4.669865f, 8.906034f, 10.13179f, 11.03952f, 12.13685f, 13.17108f, 14.39394f,
        15.38572f, 16.46287f, 17.5574f, 18.69579f, 19.78791f, 20.86859f, 21.92181f, 23.03754f,
        24.15143f, 25.22389f, 26.25589f, 26.80392f, 27.94381f, 30.76699f, 31.27266f, 32.32593f,
        33.54877f, 35.23375f, 35.636f, 36.70971f, 39.23685f, 39.91285f, 40.98652f, 42.16386f,
        45.0728f, 48.33983f, 48.69751f, 50.42679f, 50.86985f, 51.4808f, 52.53679f, 53.02477f,
        53.6138f, 54.70727f, 55.23539f, 55.80552f, 56.90189f, 57.40777f, 57.91499f, 59.09636f,
        59.58165f, 60.21585f, 61.26685f, 61.77171f, 62.31896f, 63.41485f, 63.92065f, 64.49122f,
        69.97597f, 70.52479f, 71.04871f, 72.14529f, 72.67274f, 73.28699f, 73.54185f, 73.71298f
   };




}
