//
// Created by Pavel on 18.03.17.
//

#ifndef NAVY_FRACTALS_FRACTALDRAWER_H
#define NAVY_FRACTALS_FRACTALDRAWER_H

#include "Drawer.h"

class FractalDrawer : public Drawer {
public:
    FractalDrawer(int width, int height);

    cv::Mat getDrawing(int itterations) override;
    void redraw() override;
};


#endif //NAVY_FRACTALS_FRACTALDRAWER_H
