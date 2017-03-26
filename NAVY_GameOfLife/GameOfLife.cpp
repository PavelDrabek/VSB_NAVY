//
// Created by Pavel on 26.03.17.
//

#include <opencv/cv.hpp>
#include "GameOfLife.h"

GameOfLife::GameOfLife(int width, int height) {
    this->width = width;
    this->height = height;
    matrixA = cv::Mat(height, width, CV_32FC1);
    matrixB = cv::Mat(height, width, CV_32FC1);

    fillRandom(0.25f);
}

void GameOfLife::fillRandom(float ratio) {
    int max = ratio * 100;
    clear(matrixA);
    for (int y = 0; y < height; ++y) {
        for (int x = 0; x < width; ++x) {
            int r = rand() % 100;
            matrixA.at<float>(y, x) = (r > max) ? 1 : 0;
        }
    }
}

void GameOfLife::next() {

    clear(matrixB);
    for (int x = 1; x < width - 1; ++x) {
        for (int y = 1; y < height - 1; ++y) {
            int okoli = A(x-1,y-1)+A(x-1,y)+A(x-1,y+1)+A(x,y-1)+A(x,y+1)+A(x+1,y-1)+A(x+1,y)+A(x+1,y+1);
            if(A(x,y) == 1) {
                if(okoli == 2 || okoli == 3) {
                    B(x, y, 1);
                } else {
                    B(x, y, 0);
                }
            } else {
                if(okoli == 3) {
                    B(x, y, 1);
                } else {
                    B(x, y, 0);
                }
            }
        }
    }

    matrixA = matrixB.clone();
}

cv::Mat GameOfLife::getMatrix() {
    return matrixA;
}

int GameOfLife::A(int x, int y) {
    return (int)matrixA.at<float>(y, x);
}

void GameOfLife::B(int x, int y, int value) {
    matrixB.at<float>(y, x) = value;
}

void GameOfLife::clear(cv::Mat &mat) {
    for (int y = 0; y < height; ++y) {
        for (int x = 0; x < width; ++x) {
            mat.at<float>(y, x) = 0;
        }
    }
}