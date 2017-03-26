//
// Created by Pavel on 19.03.17.
//

#ifndef NAVY_FRACTALS_MENDELBROTDRAWER_H
#define NAVY_FRACTALS_MENDELBROTDRAWER_H

#include "Drawer.h"

class MendelbrotDrawer : public Drawer{
public:
//    cv::Vec3f colors[15] = {
//            cv::Vec3f(1,0,0), cv::Vec3f(0,1,0), cv::Vec3f(0,0,1), cv::Vec3f(1,1,0), cv::Vec3f(0,1,1) ,
//            cv::Vec3f(1,0,0), cv::Vec3f(0,1,0), cv::Vec3f(0,0,1), cv::Vec3f(1,1,0), cv::Vec3f(0,1,1) ,
//            cv::Vec3f(1,0,0), cv::Vec3f(0,1,0), cv::Vec3f(0,0,1), cv::Vec3f(1,1,0), cv::Vec3f(0,1,1)
//    };

    std::vector<cv::Vec3f> colors;

    MendelbrotDrawer(int width, int height);

    cv::Mat getDrawing(int itterations) override;
    void redraw() override;
    void OnZoom(double ox, double oy, double zoom) override;
};


#endif //NAVY_FRACTALS_MENDELBROTDRAWER_H
