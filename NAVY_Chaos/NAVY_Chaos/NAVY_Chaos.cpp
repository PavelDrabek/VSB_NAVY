// GaussianMixture.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

cv::Mat mat;

double evaluate(double r, double x)
{
	return r * x * (1 - x);
}

double clamp01(double a) {
	return a < 0 ? 0 : (a < 1) ? a : 1;
}

void redraw(double defR, int iterations, int drawCount) {
	double y[100];
	double range = 4;

	mat = cv::Mat(400, 800, CV_32FC1);

	for (int ri = 0; ri < mat.cols; ri++)
	{
		double x = defR;
		double r = ((double)ri / mat.cols) * range;
		for (int i = 0; i < 1000; i++)
		{
			x = evaluate(r, x);
			y[i % 100] = x;
		}
		for (int i = 0; i < 100; i++)
		{
			mat.at<float>((1 - clamp01(y[i])) * mat.rows - 1, ri) = 1;
		}
	}

	cv::imshow("chaos", mat);
}


int K = 30;
void on_change(int id)
{
	redraw(K / 100.0, 1000, 100);
}

int main()
{


	cvNamedWindow("chaos");
	cvCreateTrackbar("R = 0.01*", "chaos", &K, 100, on_change);

	cvWaitKey(0);

	return 0;
}

