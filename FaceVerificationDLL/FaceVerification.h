#include <opencv2/opencv.hpp>
#include <cnnFace.h>


#define FACE_API extern "C" __declspec(dllexport)

FACE_API float FaceVerification(IplImage* imgFace1Path, IplImage* imgFace2Path, char* modelPath, int layerIdx, int featLen);

//#pragma comment(linker, "/export:FaceVerification=_FaceVerification@20")