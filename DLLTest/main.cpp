#include <stdio.h>

#include <opencv2/opencv.hpp>
#include <cnnFace.h>



#pragma comment(lib,"D:\\code\\FaceRecognitionDemo\\Release\\FaceVerificationDLL.lib")
extern "C"__declspec(dllimport) float FaceVerification(IplImage* imgFace1, IplImage* imgFace2, char* modelPath, int layerIdx, int featLen);

void main()
{
	/*Mat imgFace1 = imread("D:\\test\\Aaron_Peirsol_0002.bmp", CV_LOAD_IMAGE_GRAYSCALE);
	Mat imgFace2 = imread("D:\\test\\Aaron_Peirsol_0003.bmp", CV_LOAD_IMAGE_GRAYSCALE);
	;*/

	IplImage* imgFace1 = cvLoadImage( "D:\\test\\Aaron_Peirsol_0002.bmp",  CV_LOAD_IMAGE_GRAYSCALE);
	IplImage* imgFace2 = cvLoadImage( "D:\\test\\Aaron_Peirsol_0003.bmp",  CV_LOAD_IMAGE_GRAYSCALE);
	char* modelPath = "D:\\code\\cnnFace\\model\\cnnFace.bin";
	const int layerIdx = 44;
	const int len = 256;

	float score = FaceVerification(imgFace1, imgFace2, modelPath, layerIdx, len);
	std::cout << score;
}


