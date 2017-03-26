#!/usr/bin/python3
# -*- coding: utf-8 -*-

"""
author: Pavel Drabek
last edited: March 2017
"""

import sys, random, math
from PyQt5.QtWidgets import QWidget, QApplication
from PyQt5.QtGui import QPainter, QColor, QPen, QPolygon
from PyQt5.QtCore import Qt, QPoint, QRect

# Barnsley Fern
fern = [
    [0,     0,        0,  0.16, 0,    0, 0.01], #stem
    [0.85,  0.04, -0.04,  0.85, 0, 1.60, 0.85], #successively smaller leaflets
    [0.20, -0.26,  0.23,  0.22, 0, 1.60, 0.07], #largest left-hand leaflet
    [-0.15, 0.28,  0.26,  0.24, 0, 0.44, 0.07], #largest right-hand leaflet
]
# IFS Tree
ifs = [
    [ 0.1950, -0.4880,  0.3440,  0.4430, 0.4431, 0.2452], 
    [ 0.4620,  0.4140, -0.2520,  0.3610, 0.2511, 0.5692], 
    [-0.6370,  0.0000,  0.0000,  0.5010, 0.8562, 0.2512], 
    [-0.0350,  0.0700, -0.4690,  0.0220, 0.4884, 0.5069], 
    [-0.0580, -0.0700,  0.4530, -0.1110, 0.5976, 0.0969], 
]
# TCG S. Triangle
tcg = [
    [0, 1, 0.5,                 0.5,                    0, 0, 0], 
    [0, 0, 0.8660254037844386,  0.2886751345948128822,  0, 0, 0], 
    [0, 0, 0,                   0.8164965809277260327,  0, 0, 0], 
]

class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

class Border:
    def __init__(self, minX, maxX, minY, maxY):
        self.minX = minX
        self.maxX = maxX
        self.minY = minY
        self.maxY = maxY


class Example(QWidget):
    
    def __init__(self, functions, pointsCount):
        super().__init__()
        
        self.functions = functions
        self.pointsCount = pointsCount

        self.generatePoints(functions, pointsCount)

        self.initUI()
        
        
    def initUI(self):      

        self.setGeometry(300, 300, 400, 500)
        self.setWindowTitle('DRA0042 | Fractals')
        self.show()
        
    def paintEvent(self, e):

        qp = QPainter()
        qp.begin(self)
        self.drawPoints(qp)
        qp.end()

    def scalePoint(self, p, b):
        h = self.size().height()
        w = self.size().width()
        sx = (p.x - b.minX) * (w - 1) / (b.maxX - b.minX)
        sy = h - ((p.y - b.minY) * (h / (b.maxY - b.minY)))
        #print("sp: (", sx, sy, ") <- (", p.x, p.y, ")")

        return Point(sx, sy)

    def generatePoints(self, functions, pointsCount):
        self.points = []

        if(functions == tcg):
            h = self.size().height()
            w = self.size().width()
            triangle_corners = [Point(0, 0), Point(w, 0), Point(w/2, h)]
            start = triangle_corners[random.randint(0, len(triangle_corners) - 1)]
            for i in range(0, pointsCount):
                end = triangle_corners[random.randint(0, len(triangle_corners) - 1)]
                start = Point(((start.x + end.x) / 2), ((start.y + end.y) / 2))
                self.points.append(Point(start.x, start.y))
        else:
            p = Point(0, 0)
            border = Border(999999, -999999, 999999, -999999)

            for i in range(pointsCount):
                r = random.randint(0,len(functions)-1)
                a = functions[r][0]
                b = functions[r][1]
                c = functions[r][2]
                d = functions[r][3]
                e = functions[r][4]
                f = functions[r][5]

                p.x = a * p.x + b * p.y + e
                p.y = c * p.x + d * p.y + f
                #print("p: (", p.x, p.y, ")")
                
                if(border.minX > p.x):
                    border.minX = p.x
                if(border.maxX < p.x):
                    border.maxX = p.x
                if(border.minY > p.y):
                    border.minY = p.y
                if(border.maxY < p.y):
                    border.maxY = p.y

                self.points.append(Point(p.x, p.y))

            self.border = border
            #print("borders:", border.minX, border.minY, border.maxX, border.maxY)

    def drawPoints(self, qp):
        qp.setPen(Qt.red)
        if(self.functions == tcg): 
            for i in range(self.pointsCount):  
                sp = self.points[i] 
                qp.drawPoint(sp.x, sp.y)
        else:
            for i in range(self.pointsCount):  
                sp = self.scalePoint(self.points[i], self.border)   
                qp.drawPoint(sp.x, sp.y)
        
#if __name__ == '__main__':

function = []
count = 1000
for i in range(len(sys.argv)):
    if(sys.argv[i] == "-func"):
        if(sys.argv[i + 1] == "fern"):
            function = fern
        if(sys.argv[i + 1] == "ifs"):
            function = ifs
        if(sys.argv[i + 1] == "tcg"):
            function = tcg
    if(sys.argv[i] == "-count"):
        count = int(sys.argv[i+1])

if(len(function) <= 0):
    print ("Error: You have to choose some function!")
    print ("Usage: -func [fern | ifs | tcg] [-count number]")
    exit()

app = QApplication(sys.argv)
ex = Example(function, count)
sys.exit(app.exec_())