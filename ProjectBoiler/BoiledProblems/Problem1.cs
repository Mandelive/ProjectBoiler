using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public class Problem1: IProblem
    {
        readonly int id = 1;
        readonly string description = @"{\rtf1\fbidis\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fmodern\fprq1\fcharset0 Consolas;}{\f1\fnil\fcharset0 Consolas;}}
{\colortbl ;\red237\green125\blue49;\red255\green255\blue255;}
\viewkind4\uc1\pard\ltrpar\sa160\sl252\slmult1\cf1\b\f0\fs22 Problem 1:\par
\cf0\b0\fs24 If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\par
\par
\cf1\b >>\cf0\b0  Find the sum of all the multiples of 3 or 5 below 1000.\par
\pard\ltrpar\cf2\f1\par
}";

        string[] parametersInfo = { "n:num - find the sum of all the multiple below this number" };
        string[] defaultParameters = { "1000" };

        public int GetID()
        {
            return id;
        }

        public string GetDescription()
        {
            return description;
        }

        public string[] GetParametersInfo()
        {
            return parametersInfo;
        }

        public string[] GetDefaultParameters()
        {
            return defaultParameters;
        }

        public string Solve(string[] parameters)
        {
            throw new NotImplementedException("TODO");
        }
    }
}
