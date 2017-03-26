#include "drawers/FractalDrawer.h"
#include "drawers/MendelbrotDrawer.h"

int main() {
//    imshow("fractal", getFractalDrawing(400, 200, FERN, 100000));

    MendelbrotDrawer drawer(400, 400);
//    drawer.setZoom(140, 140);
//    drawer.setOrigin(100, 0);
    drawer.redraw();
    cv::waitKey(0);

    return 0;
}