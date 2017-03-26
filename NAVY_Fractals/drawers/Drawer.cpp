//
// Created by Pavel on 19.03.17.
//

#include "Drawer.h"
#include <math.h>

Drawer::Drawer(int width, int height) {
    this->width = width;
    this->height = height;

    ZoomEntry ze(0, 0, 60);
    zoomHistory.push_back(ze);

    cv::namedWindow("fractal");
    cv::setMouseCallback("fractal", onMouse, this);
}

cv::Mat Drawer::getDrawing(int itterations) {
    return cv::Mat();
}

void Drawer::redraw() {
//    imshow("fractal", getDrawing(100000));
//    cv::waitKey(0);
}

void Drawer::setOrigin(double x, double y) {
    originX = x;
    originY = y;
}

void Drawer::setZoom(double value) {
    zoom = value;
}

void Drawer::onMouse(int event, int x, int y, int flags, void* userdata) {
    Drawer *drawer = reinterpret_cast<Drawer *>(userdata);

    if (event == CV_EVENT_LBUTTONDOWN) {
        drawer->fromX = x;
        drawer->fromY = y;
        printf("start dragging\n");
    }
    if (event == CV_EVENT_LBUTTONUP) {
        printf("stop dragging\n");

        double areaX = abs(drawer->fromX - x);
        if(areaX < 20) {
            return;
        }

        areaX * drawer->zoom;
        double newZoom = (areaX / drawer->width) * drawer->zoom;

        double nox = drawer->originX + drawer->fromX * drawer->zoom;
        double noy = drawer->originY + drawer->fromY * drawer->zoom;

        printf("from (%d, %d), to(%d, %d)\n", drawer->fromX, drawer->fromY, x, y);
        printf("area = %f, zoom = %f\n", areaX, newZoom);

        ZoomEntry ze(drawer->originX, drawer->originY, drawer->zoom);
        drawer->zoomHistory.push_back(ze);

        drawer->OnZoom(nox, noy, newZoom);
    }
    if(event == CV_EVENT_RBUTTONUP) {
        printf("zooming back\n");

        if(drawer->zoomHistory.size() <= 1) {
            printf("zoom history is empty\n");
            return;
        }

        ZoomEntry ze = drawer->zoomHistory.back();
        drawer->OnZoom(ze.originX, ze.originY, ze.zoom);
        drawer->zoomHistory.pop_back();
    }
}

void Drawer::OnZoom(double ox, double oy, double zoom) {

}

void Drawer::saveImage(std::string path) {
    std::vector<int> compression_params;
    int x = (int)CV_IMWRITE_PNG_COMPRESSION;
    compression_params.push_back(x);
    compression_params.push_back(9);

    img.convertTo(img, CV_8UC3, 255.0);

    cv::imwrite( path, img, compression_params );
}
