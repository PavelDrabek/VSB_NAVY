//
// Created by Pavel on 19.03.17.
//

#include "MendelbrotDrawer.h"

MendelbrotDrawer::MendelbrotDrawer(int width, int height) : Drawer(width, height) {
//    setOrigin(0, 0);
//    setZoom(1);

    setZoom(4);
    setOrigin(-width*2, -height*2);
}

cv::Mat MendelbrotDrawer::getDrawing(int itterations) {
    cv::Mat img(height, width, CV_32FC3);

    cv::Vec3f c = cv::Vec3f(0.5f, 0, 0);
    for (int i = 0; i < itterations; ++i) {
        cv::Vec3f rgb = cv::Vec3f(i/256.0f, 0, (i+0.1f)/(i+10.0f));
        colors.push_back(rgb);
    }

    for (int row = 0; row < height; row++) {
        for (int col = 0; col < width; col++) {
            double c_re = originX/width + col/((double)width) * zoom;
            double c_im = originY/width + row/((double)width) * zoom;

            double x = 0, y = 0;
            int iteration = 0;
            while (x*x+y*y <= 4 && iteration < itterations) {
                double x_new = x*x - y*y + c_re;
                y = 2*x*y + c_im;
                x = x_new;
                iteration++;
            }
            // img.at<float>(row, col) = iteration < itterations ? 1 : 0;
            img.at<cv::Vec3f>(row, col) = iteration < itterations ? colors[iteration] : cv::Vec3f(0,0,0);
        }
    }

    return img;
}

void MendelbrotDrawer::redraw() {
    printf("origin (%f, %f), zoom = %f\n", originX, originY, zoom);

    img = getDrawing(1000);
    saveImage("/Users/pavel/Documents/Projekty/NAVY/NAVY_Fractals/img.png");

    //cvDestroyWindow("fractal");
    imshow("fractal", img);
}

void MendelbrotDrawer::OnZoom(double ox, double oy, double zoom) {

    setOrigin(ox, oy);
    setZoom(zoom);
    //cvDestroyWindow("fractal");
    redraw();
}
