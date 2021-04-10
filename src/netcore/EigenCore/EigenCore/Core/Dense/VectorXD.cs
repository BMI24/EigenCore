﻿using EigenCore.Eigen;
using System;
using System.Linq;

namespace EigenCore.Core.Dense
{
    public class VectorXD : VectorDenseBase<double>
    {
        public static VectorXD Random(int size, double min = 0, double max = 1, int seed = 0)
        {
            double[] input = new double[size];
            double maxMinusMin = max - min;

            if (_random == null) SetRandomState(seed);

            for (int i = 0; i < size; i++)
            {
                input[i] = maxMinusMin * _random.NextDouble() + min;
            }

            return new VectorXD(input);
        }

        public static VectorXD Linespace(double start, double end, int numberOfPoints)
        {
            double step = Math.Abs((end - start) / (numberOfPoints - 1.0));
            double[] input = new double[numberOfPoints];
            double value = start;
            for (int i = 0; i < numberOfPoints; i++)
            {
                input[i] = value;
                value += step;
            }

            return new VectorXD(input);
        }

        public double Min() => _values.Min();

        public double Max() => _values.Max();

        public double Sum() => _values.Sum();

        public double Dot(VectorXD other)
        {
            return EigenDenseUtilities.Dot(GetValues(), other.GetValues(), Length);
        }

        public VectorXD Add(VectorXD other)
        {
            double[] outVector = new double[Length];
            EigenDenseUtilities.Add(GetValues(), other.GetValues(), Length, outVector);
            return new VectorXD(outVector);
        }

        public VectorXD Scale(double scalar)
        {
            double[] outVector = new double[Length];
            EigenDenseUtilities.Scale(GetValues(), scalar, Length, outVector);
            return new VectorXD(outVector);
        }

        public VectorXD(double[] values) : base(values)
        {
        }
    }
}
