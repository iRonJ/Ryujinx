<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    struct HandlesToClose
    {
        private int _handle0;
        private int _handle1;
        private int _handle2;
        private int _handle3;
        private int _handle4;
        private int _handle5;
        private int _handle6;
        private int _handle7;

        public int Count;

        public int this[int index]
        {
<<<<<<< HEAD
            readonly get
=======
            get
>>>>>>> 1ec71635b (sync with main branch)
            {
                return index switch
                {
                    0 => _handle0,
                    1 => _handle1,
                    2 => _handle2,
                    3 => _handle3,
                    4 => _handle4,
                    5 => _handle5,
                    6 => _handle6,
                    7 => _handle7,
<<<<<<< HEAD
                    _ => throw new IndexOutOfRangeException(),
=======
                    _ => throw new IndexOutOfRangeException()
>>>>>>> 1ec71635b (sync with main branch)
                };
            }
            set
            {
                switch (index)
                {
<<<<<<< HEAD
                    case 0:
                        _handle0 = value;
                        break;
                    case 1:
                        _handle1 = value;
                        break;
                    case 2:
                        _handle2 = value;
                        break;
                    case 3:
                        _handle3 = value;
                        break;
                    case 4:
                        _handle4 = value;
                        break;
                    case 5:
                        _handle5 = value;
                        break;
                    case 6:
                        _handle6 = value;
                        break;
                    case 7:
                        _handle7 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
=======
                    case 0: _handle0 = value; break;
                    case 1: _handle1 = value; break;
                    case 2: _handle2 = value; break;
                    case 3: _handle3 = value; break;
                    case 4: _handle4 = value; break;
                    case 5: _handle5 = value; break;
                    case 6: _handle6 = value; break;
                    case 7: _handle7 = value; break;
                    default: throw new IndexOutOfRangeException();
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }
    }
}
