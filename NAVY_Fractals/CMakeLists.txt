cmake_minimum_required(VERSION 3.6)
project(NAVY_Fractals)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(SOURCE_FILES main.cpp parameters.h drawers/FractalDrawer.cpp drawers/FractalDrawer.h drawers/MendelbrotDrawer.cpp drawers/MendelbrotDrawer.h drawers/Drawer.cpp drawers/Drawer.h)

find_package(OpenCV REQUIRED) # ---

include_directories(${OpenCV_INCLUDE_DIRS}) # ---


add_executable(NAVY_Fractals ${SOURCE_FILES})
target_link_libraries(NAVY_Fractals ${OpenCV_LIBS}) # ---
