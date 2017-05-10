﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopfield
{
    public static class Letter
    {

        public static int[] A = {
            -1, 1, 1, 1, -1,
            -1, 1, -1, 1, -1,
            -1, 1, -1, 1, -1,
            -1, 1, 1, 1, -1,
            -1, 1, -1, 1, -1,
            -1, 1, -1, 1, -1,
            -1, 1, -1, 1, -1
        };

        public static int[] Ax = {
            -1, 1, 1, 1, -1,
            -1, 1, 1, 1, -1,
            -1, 1, 1, 1, -1,
            -1, 1, 1, 1, -1,
            -1, 1, -1, 1, -1,
            -1, 1, -1, 1, -1,
            -1, 1, -1, 1, -1
        };


        public static int[] C = {
            -1, 1, 1, 1, -1,
            1, -1, -1, -1, 1,
            1, -1, -1, -1, -1,
            1, -1, -1, -1, -1,
            1, -1, -1, -1, -1,
            1, -1, -1, -1, 1,
            -1, 1, 1, 1, -1
        };


        public static int[] Cx = {
            1, -1, -1, 1, -1,
            1, -1, -1, -1, 1,
            1, 1, 1, 1, -1,
            1, -1, -1, -1, -1,
            1, -1, -1, -1, -1,
            1, -1, -1, -1, 1,
            1, 1, 1, 1, -1
        };

        public static int[] S = {
            1, 1, 1, 1, 1,
            1, -1, -1, -1, -1,
            1, -1, -1, -1, -1,
            1, 1, 1, 1, 1,
            -1, -1, -1, -1, 1,
            -1, -1, -1, -1, 1,
            1, 1, 1, 1, 1
        };

        public static int[] Sx = {
            1, 1, 1, 1, 1,
            1, -1, -1, -1, 1,
            1, -1, -1, -1, 1,
            1, 1, 1, 1, 1,
            1, -1, -1, -1, 1,
            1, -1, -1, -1, 1,
            1, 1, 1, 1, 1
        };
    }
}
