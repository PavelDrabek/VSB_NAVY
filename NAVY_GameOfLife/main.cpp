#include <iostream>
#include <opencv/cv.hpp>
#include "GameOfLife.h"

void saveImage(cv::Mat mat, std::string path) {
    std::vector<int> compression_params;
    int x = (int)CV_IMWRITE_PNG_COMPRESSION;
    compression_params.push_back(x);
    compression_params.push_back(9);

    mat.convertTo(mat, CV_8UC3, 255.0);

    cv::imwrite( path, mat, compression_params );
}


int main() {
    std::cout << "Hello, World!" << std::endl;

    GameOfLife game(800, 800);
    cv::Mat img(800, 800, CV_32FC1);

    while(true) {
        cv::resize(game.getMatrix(), img, img.size(), 0, 0, CV_INTER_NN);
        cv::imshow("Game of life", img);
        char key = cv::waitKey(60);
        if(key == ' ') {
            break;
        }
        if(key == 's') {
            saveImage(img, "gameOfLife.png");
        }
        game.next();
    }

    return 0;
}