using Ryujinx.Audio.Renderer.Dsp.Command;
using System;
using System.Diagnostics;

namespace Ryujinx.Audio.Renderer.Server
{
    /// <summary>
    /// <see cref="ICommandProcessingTimeEstimator"/> version 5. (added with REV11)
    /// </summary>
    public class CommandProcessingTimeEstimatorVersion5 : CommandProcessingTimeEstimatorVersion4
    {
        public CommandProcessingTimeEstimatorVersion5(uint sampleCount, uint bufferCount) : base(sampleCount, bufferCount) { }

        public override uint Estimate(DelayCommand command)
        {
<<<<<<< HEAD
            Debug.Assert(SampleCount == 160 || SampleCount == 240);

            if (SampleCount == 160)
            {
                if (command.Enabled)
                {
                    return command.Parameter.ChannelCount switch
                    {
                        1 => 8929,
                        2 => 25501,
                        4 => 47760,
                        6 => 82203,
                        _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                    };
                }

                return command.Parameter.ChannelCount switch
                {
                    1 => (uint)1295.20f,
                    2 => (uint)1213.60f,
                    4 => (uint)942.03f,
                    6 => (uint)1001.6f,
                    _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                };
=======
            Debug.Assert(_sampleCount == 160 || _sampleCount == 240);

            if (_sampleCount == 160)
            {
                if (command.Enabled)
                {
                    switch (command.Parameter.ChannelCount)
                    {
                        case 1:
                            return 8929;
                        case 2:
                            return 25501;
                        case 4:
                            return 47760;
                        case 6:
                            return 82203;
                        default:
                            throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                    }
                }
                else
                {
                    switch (command.Parameter.ChannelCount)
                    {
                        case 1:
                            return (uint)1295.20f;
                        case 2:
                            return (uint)1213.60f;
                        case 4:
                            return (uint)942.03f;
                        case 6:
                            return (uint)1001.6f;
                        default:
                            throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)
            }

            if (command.Enabled)
            {
<<<<<<< HEAD
                return command.Parameter.ChannelCount switch
                {
                    1 => 11941,
                    2 => 37197,
                    4 => 69750,
                    6 => 12004,
                    _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                };
            }

            return command.Parameter.ChannelCount switch
            {
                1 => (uint)997.67f,
                2 => (uint)977.63f,
                4 => (uint)792.31f,
                6 => (uint)875.43f,
                _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
            };
=======
                switch (command.Parameter.ChannelCount)
                {
                    case 1:
                        return 11941;
                    case 2:
                        return 37197;
                    case 4:
                        return 69750;
                    case 6:
                        return 12004;
                    default:
                        throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                }
            }
            else
            {
                switch (command.Parameter.ChannelCount)
                {
                    case 1:
                        return (uint)997.67f;
                    case 2:
                        return (uint)977.63f;
                    case 4:
                        return (uint)792.31f;
                    case 6:
                        return (uint)875.43f;
                    default:
                        throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                }
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override uint Estimate(ReverbCommand command)
        {
<<<<<<< HEAD
            Debug.Assert(SampleCount == 160 || SampleCount == 240);

            if (SampleCount == 160)
            {
                if (command.Enabled)
                {
                    return command.Parameter.ChannelCount switch
                    {
                        1 => 81475,
                        2 => 84975,
                        4 => 91625,
                        6 => 95332,
                        _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                    };
                }

                return command.Parameter.ChannelCount switch
                {
                    1 => (uint)536.30f,
                    2 => (uint)588.80f,
                    4 => (uint)643.70f,
                    6 => (uint)706.0f,
                    _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                };
=======
            Debug.Assert(_sampleCount == 160 || _sampleCount == 240);

            if (_sampleCount == 160)
            {
                if (command.Enabled)
                {
                    switch (command.Parameter.ChannelCount)
                    {
                        case 1:
                            return 81475;
                        case 2:
                            return 84975;
                        case 4:
                            return 91625;
                        case 6:
                            return 95332;
                        default:
                            throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                    }
                }
                else
                {
                    switch (command.Parameter.ChannelCount)
                    {
                        case 1:
                            return (uint)536.30f;
                        case 2:
                            return (uint)588.80f;
                        case 4:
                            return (uint)643.70f;
                        case 6:
                            return (uint)706.0f;
                        default:
                            throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)
            }

            if (command.Enabled)
            {
<<<<<<< HEAD
                return command.Parameter.ChannelCount switch
                {
                    1 => 120170,
                    2 => 125260,
                    4 => 135750,
                    6 => 141130,
                    _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                };
            }

            return command.Parameter.ChannelCount switch
            {
                1 => (uint)617.64f,
                2 => (uint)659.54f,
                4 => (uint)711.44f,
                6 => (uint)778.07f,
                _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
            };
=======
                switch (command.Parameter.ChannelCount)
                {
                    case 1:
                        return 120170;
                    case 2:
                        return 125260;
                    case 4:
                        return 135750;
                    case 6:
                        return 141130;
                    default:
                        throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                }
            }
            else
            {
                switch (command.Parameter.ChannelCount)
                {
                    case 1:
                        return (uint)617.64f;
                    case 2:
                        return (uint)659.54f;
                    case 4:
                        return (uint)711.44f;
                    case 6:
                        return (uint)778.07f;
                    default:
                        throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                }
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override uint Estimate(Reverb3dCommand command)
        {
<<<<<<< HEAD
            Debug.Assert(SampleCount == 160 || SampleCount == 240);

            if (SampleCount == 160)
            {
                if (command.Enabled)
                {
                    return command.Parameter.ChannelCount switch
                    {
                        1 => 116750,
                        2 => 125910,
                        4 => 146340,
                        6 => 165810,
                        _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                    };
                }

                return command.Parameter.ChannelCount switch
                {
                    1 => 735,
                    2 => (uint)766.62f,
                    4 => (uint)834.07f,
                    6 => (uint)875.44f,
                    _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                };
=======
            Debug.Assert(_sampleCount == 160 || _sampleCount == 240);

            if (_sampleCount == 160)
            {
                if (command.Enabled)
                {
                    switch (command.Parameter.ChannelCount)
                    {
                        case 1:
                            return 116750;
                        case 2:
                            return 125910;
                        case 4:
                            return 146340;
                        case 6:
                            return 165810;
                        default:
                            throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                    }
                }
                else
                {
                    switch (command.Parameter.ChannelCount)
                    {
                        case 1:
                            return 735;
                        case 2:
                            return (uint)766.62f;
                        case 4:
                            return (uint)834.07f;
                        case 6:
                            return (uint)875.44f;
                        default:
                            throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)
            }

            if (command.Enabled)
            {
<<<<<<< HEAD
                return command.Parameter.ChannelCount switch
                {
                    1 => 170290,
                    2 => 183880,
                    4 => 214700,
                    6 => 243850,
                    _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                };
            }

            return command.Parameter.ChannelCount switch
            {
                1 => (uint)508.47f,
                2 => (uint)582.45f,
                4 => (uint)626.42f,
                6 => (uint)682.47f,
                _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
            };
=======
                switch (command.Parameter.ChannelCount)
                {
                    case 1:
                        return 170290;
                    case 2:
                        return 183880;
                    case 4:
                        return 214700;
                    case 6:
                        return 243850;
                    default:
                        throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                }
            }
            else
            {
                switch (command.Parameter.ChannelCount)
                {
                    case 1:
                        return (uint)508.47f;
                    case 2:
                        return (uint)582.45f;
                    case 4:
                        return (uint)626.42f;
                    case 6:
                        return (uint)682.47f;
                    default:
                        throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                }
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override uint Estimate(CompressorCommand command)
        {
<<<<<<< HEAD
            Debug.Assert(SampleCount == 160 || SampleCount == 240);

            if (SampleCount == 160)
            {
                if (command.Enabled)
                {
                    return command.Parameter.ChannelCount switch
                    {
                        1 => 34431,
                        2 => 44253,
                        4 => 63827,
                        6 => 83361,
                        _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                    };
                }

                return command.Parameter.ChannelCount switch
                {
                    1 => (uint)630.12f,
                    2 => (uint)638.27f,
                    4 => (uint)705.86f,
                    6 => (uint)782.02f,
                    _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                };
=======
            Debug.Assert(_sampleCount == 160 || _sampleCount == 240);

            if (_sampleCount == 160)
            {
                if (command.Enabled)
                {
                    switch (command.Parameter.ChannelCount)
                    {
                        case 1:
                            return 34431;
                        case 2:
                            return 44253;
                        case 4:
                            return 63827;
                        case 6:
                            return 83361;
                        default:
                            throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                    }
                }
                else
                {
                    switch (command.Parameter.ChannelCount)
                    {
                        case 1:
                            return (uint)630.12f;
                        case 2:
                            return (uint)638.27f;
                        case 4:
                            return (uint)705.86f;
                        case 6:
                            return (uint)782.02f;
                        default:
                            throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)
            }

            if (command.Enabled)
            {
<<<<<<< HEAD
                return command.Parameter.ChannelCount switch
                {
                    1 => 51095,
                    2 => 65693,
                    4 => 95383,
                    6 => 124510,
                    _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
                };
            }

            return command.Parameter.ChannelCount switch
            {
                1 => (uint)840.14f,
                2 => (uint)826.1f,
                4 => (uint)901.88f,
                6 => (uint)965.29f,
                _ => throw new NotImplementedException($"{command.Parameter.ChannelCount}"),
            };
        }
    }
}
=======
                switch (command.Parameter.ChannelCount)
                {
                    case 1:
                        return 51095;
                    case 2:
                        return 65693;
                    case 4:
                        return 95383;
                    case 6:
                        return 124510;
                    default:
                        throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                }
            }
            else
            {
                switch (command.Parameter.ChannelCount)
                {
                    case 1:
                        return (uint)840.14f;
                    case 2:
                        return (uint)826.1f;
                    case 4:
                        return (uint)901.88f;
                    case 6:
                        return (uint)965.29f;
                    default:
                        throw new NotImplementedException($"{command.Parameter.ChannelCount}");
                }
            }
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
