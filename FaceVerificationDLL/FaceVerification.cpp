#include "FaceVerification.h"

FACE_API float FaceVerification(IplImage* imgFace1, IplImage* imgFace2, char* modelPath, int layerIdx, int featLen){
	float* feat1 = (float*)malloc(featLen*sizeof(float));
	float* feat2 = (float*)malloc(featLen*sizeof(float));

	if(NULL == feat1)
		std::cout << "feat1 malloc error" << std::endl;
	if(NULL ==feat2)
		std::cout << "feat2 malloc error" << std::endl;

	cnnFace cnn(modelPath, layerIdx, featLen);

	if (cnn.cnnFaceInit() != 0) {
		return 0;
	}

	Mat img1(imgFace1);
	Mat img2(imgFace2);

	cnn.getFeature(img1, feat1);

	cnn.getFeature(img2, feat2);

	float score = cnn.getScore(feat1, feat2);

	cnn.~cnnFace();
	free(feat1);
	free(feat2);

	return score;
}