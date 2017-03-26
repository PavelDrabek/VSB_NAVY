//
// Created by Pavel on 18.03.17.
//

#include "FractalDrawer.h"
#include "../parameters.h"

FractalDrawer::FractalDrawer(int width, int height) : Drawer(width, height) {
    setOrigin(0, 0);
    setZoom(60);
}

cv::Mat FractalDrawer::getDrawing(int itterations) {
    cv::Mat img(height, width, CV_32F);
    float *func = &fern[0];
    int funcCount = sizeof(fern) / (sizeof(float) * 7);

    double x = 0;
    double y = 0;

    for (int i = 0; i < itterations; ++i) {
        int r = rand() % funcCount;
        int s = r * 7;

        float a = func[s + 0];
        float b = func[s + 1];
        float c = func[s + 2];
        float d = func[s + 3];
        float e = func[s + 4];
        float f = func[s + 5];

        x = a * x + b * y + e;
        y = c * x + d * y + f;

        int X = (int)(x * zoom) + originX;
        int Y = (int)(y * zoom) + originY;

        if(X >= 0 && X < width && Y > 0 && Y <= height) {
            img.at<float>(height - Y, X) = 1;
        }
    }

    return img;
}

void FractalDrawer::redraw() {
    imshow("fractal", getDrawing(100000));
    cv::waitKey(0);
}