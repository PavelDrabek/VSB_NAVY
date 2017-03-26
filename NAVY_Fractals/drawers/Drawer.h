//
// Created by Pavel on 19.03.17.
//

#ifndef NAVY_FRACTALS_DRAWER_H
#define NAVY_FRACTALS_DRAWER_H

#include <opencv/cv.hpp>
#include <opencv2/core/mat.hpp>

class ZoomEntry {
public:
    double originX, originY;
    double zoom;

    ZoomEntry(double oX, double oY, double z) {
        originX = oX;
        originY = oY;
        zoom = z;
    }
};

class Drawer {
public:
    int width, height;
    double originX, originY;
    double zoom;

    Drawer(int width, int height);
    void setZoom(double value);
    void setOrigin(double x, double y);

    virtual cv::Mat getDrawing(int itterations);
    virtual void redraw();

    void saveImage(std::string path);

protected:
    cv::Mat img;

    std::vector<ZoomEntry> zoomHistory;
    virtual void OnZoom(double ox, double oy, double zoom);
    static void onMouse(int event, int x, int y, int, void*);

private:
    int fromX, fromY;
};


#endif //NAVY_FRACTALS_DRAWER_H
