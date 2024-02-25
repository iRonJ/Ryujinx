<<<<<<< HEAD
=======
﻿using System.Runtime.CompilerServices;

>>>>>>> 1ec71635b (sync with main branch)
namespace Ryujinx.Audio.Renderer.Dsp.Effect
{
    public struct ExponentialMovingAverage
    {
        private float _mean;

        public ExponentialMovingAverage(float mean)
        {
            _mean = mean;
        }

<<<<<<< HEAD
        public readonly float Read()
=======
        public float Read()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _mean;
        }

        public float Update(float value, float alpha)
        {
            _mean += alpha * (value - _mean);

            return _mean;
        }
    }
}
