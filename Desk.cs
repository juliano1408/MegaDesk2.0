﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Stratton
{
    public class Desk
    {
        private const int MINWIDTH = 24;
        private const int MAXWIDTH = 96;
        private const int MINDEPTH = 12;
        private const int MAXDEPTH = 48;
        private int width = 0;
        private int depth = 0;
        private int drawerCount;
        private int area;
        private DesktopMaterial desktopMaterial = DesktopMaterial.pine;

        public Desk() { }
        public int GetMINWIDTH() { return MINWIDTH; }
        public int GetMAXWIDTH() { return MAXWIDTH; }
        public int GetMINDEPTH() { return MINDEPTH; }
        public int GetMAXDEPTH() { return MAXDEPTH; }
        public int GetWidth() { return width; }
        public void SetWidth(int widthInput) { if (ValidatedWidth(widthInput)) { width = widthInput; } }
        public int GetDepth() { return depth; }
        public void SetDepth(int depthInput) { if (ValidatedDepth(depthInput)) { depth = depthInput;}}
        public bool ValidatedWidth(int widthInput) { if (widthInput >= MINWIDTH && widthInput <= MAXWIDTH) return true; else return false; }

        public bool ValidatedDepth(int depthInput) { if (depthInput >= MINDEPTH && depthInput <= MAXDEPTH) return true; else return false; }
        public int GetArea() { return area; }
        public void SetArea(int width, int depth) { area = width * depth; }
        public int GetDrawerCount() { return drawerCount; }

        public void SetDrawerCount(decimal count) { drawerCount = Decimal.ToInt32(count); }
        public DesktopMaterial GetDesktopMaterial() {return desktopMaterial;}
        public void SetDesktopMaterial( DesktopMaterial sm)
        {
            desktopMaterial = sm;

        }
        public void SetDesktopMaterial(string sm)
        { 
            switch (sm)
            {
                case "laminate":desktopMaterial= DesktopMaterial.laminate; break;
                case "oak": desktopMaterial= DesktopMaterial.oak; break;
                case "pine": desktopMaterial = DesktopMaterial.pine; break;
                case "rosewood": desktopMaterial = DesktopMaterial.rosewood; break;
                case "veneer": desktopMaterial = DesktopMaterial.veneer; break;
                default: desktopMaterial = DesktopMaterial.pine; break;
            }
        }
        public override string ToString()
        {
            return base.ToString(); 
        }

    }
    public enum DesktopMaterial
    {
        laminate, oak, pine, rosewood, veneer
    }
}