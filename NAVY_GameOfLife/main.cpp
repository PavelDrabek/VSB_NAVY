#include <iostream>
#include <opencv/cv.hpp>
#include "GameOfLife.h"

int main() {
    std::cout << "Hello, World!" << std::endl;

    GameOfLife game(800, 800);
    cv::Mat img(800, 800, CV_32FC1);

    while(true) {
        cv::resize(game.getMatrix(), img, img.size(), 0, 0, CV_INTER_NN);
        cv::imshow("Game of life", img);
        if(cv::waitKey(60) == ' ') {
            break;
        }
        game.next();
    }

    return 0;
}