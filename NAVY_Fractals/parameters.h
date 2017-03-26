//
// Created by Pavel on 18.03.17.
//

#ifndef NAVY_FRACTALS_PARAMETERS_H
#define NAVY_FRACTALS_PARAMETERS_H

enum FractalType { FERN, IFS, Tree };

// Barnsley Fern
float fern[4*7] = {
        0, 0, 0, 0.16, 0, 0, 0.01,                // stem
        0.85, 0.04, -0.04, 0.85, 0, 1.60, 0.85,   //successively smaller leaflets
        0.20, -0.26, 0.23, 0.22, 0, 1.60, 0.07,   // largest left-hand leaflet
        -0.15, 0.28, 0.26, 0.24, 0, 0.44, 0.07  //largest right-hand leaflet
};

float ifs[5*7] = {
     0.1950, -0.4880,  0.3440,  0.4430, 0.4431, 0.2452,
     0.4620,  0.4140, -0.2520,  0.3610, 0.2511, 0.5692,
    -0.6370,  0.0000,  0.0000,  0.5010, 0.8562, 0.2512,
    -0.0350,  0.0700, -0.4690,  0.0220, 0.4884, 0.5069,
    -0.0580, -0.0700,  0.4530, -0.1110, 0.5976, 0.0969,
};


#endif //NAVY_FRACTALS_PARAMETERS_H
