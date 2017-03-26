cmake_minimum_required(VERSION 3.6)
project(NAVY_GameOfLife)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(SOURCE_FILES main.cpp GameOfLife.cpp GameOfLife.h)

find_package(OpenCV REQUIRED) # ---

include_directories(${OpenCV_INCLUDE_DIRS}) # ---


add_executable(NAVY_GameOfLife ${SOURCE_FILES})
target_link_libraries(NAVY_GameOfLife ${OpenCV_LIBS}) # ---
