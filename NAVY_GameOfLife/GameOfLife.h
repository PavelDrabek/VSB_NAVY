//
// Created by Pavel on 26.03.17.
//

#ifndef NAVY_GAMEOFLIFE_GAMEOFLIFE_H
#define NAVY_GAMEOFLIFE_GAMEOFLIFE_H


#include <opencv2/core/mat.hpp>

class GameOfLife {
public:
    int width, height;
    GameOfLife(int width, int height);
    void fillRandom(float ratio);

    void next();
    cv::Mat getMatrix();


protected:
    cv::Mat matrixA;
    cv::Mat matrixB;
    int A(int x, int y);
    void B(int x, int y, int value);
    void clear(cv::Mat &mat);
};


#endif //NAVY_GAMEOFLIFE_GAMEOFLIFE_H
