<<<<<<< HEAD
using Ryujinx.Graphics.Shader.Translation;
=======
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ryujinx.Graphics.Shader.Decoders
{
    readonly struct DecodedProgram : IEnumerable<DecodedFunction>
    {
        public DecodedFunction MainFunction { get; }
        private readonly IReadOnlyDictionary<ulong, DecodedFunction> _functions;
        private readonly List<DecodedFunction> _functionsWithId;
        public int FunctionsWithIdCount => _functionsWithId.Count;

<<<<<<< HEAD
        public AttributeUsage AttributeUsage { get; }
        public FeatureFlags UsedFeatures { get; }
        public byte ClipDistancesWritten { get; }
        public int Cb1DataSize { get; }

        public DecodedProgram(
            DecodedFunction mainFunction,
            IReadOnlyDictionary<ulong, DecodedFunction> functions,
            AttributeUsage attributeUsage,
            FeatureFlags usedFeatures,
            byte clipDistancesWritten,
            int cb1DataSize)
        {
            MainFunction = mainFunction;
            _functions = functions;
            _functionsWithId = new();
            AttributeUsage = attributeUsage;
            UsedFeatures = usedFeatures;
            ClipDistancesWritten = clipDistancesWritten;
            Cb1DataSize = cb1DataSize;
=======
        public DecodedProgram(DecodedFunction mainFunction, IReadOnlyDictionary<ulong, DecodedFunction> functions)
        {
            MainFunction = mainFunction;
            _functions = functions;
            _functionsWithId = new List<DecodedFunction>();
>>>>>>> 1ec71635b (sync with main branch)
        }

        public DecodedFunction GetFunctionByAddress(ulong address)
        {
            if (_functions.TryGetValue(address, out DecodedFunction function))
            {
                return function;
            }

            return null;
        }

        public DecodedFunction GetFunctionById(int id)
        {
            if ((uint)id >= (uint)_functionsWithId.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return _functionsWithId[id];
        }

        public void AddFunctionAndSetId(DecodedFunction function)
        {
            function.Id = _functionsWithId.Count;
            _functionsWithId.Add(function);
        }

<<<<<<< HEAD
        public IoUsage GetIoUsage()
        {
            return new IoUsage(UsedFeatures, ClipDistancesWritten, AttributeUsage.UsedOutputAttributes);
        }

=======
>>>>>>> 1ec71635b (sync with main branch)
        public IEnumerator<DecodedFunction> GetEnumerator()
        {
            return _functions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
