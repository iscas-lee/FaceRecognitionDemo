#include <opencv2/opencv.hpp>
#include <cnnFace.h>


#define FACE_API extern "C" __declspec(dllexport)

FACE_API float FaceVerification(IplImage* imgFace1, IplImage* imgFace2, char* modelPath, int layerIdx, int featLen);