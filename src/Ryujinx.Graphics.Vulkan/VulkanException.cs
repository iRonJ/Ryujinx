<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Runtime.Serialization;

namespace Ryujinx.Graphics.Vulkan
{
    static class ResultExtensions
    {
<<<<<<< HEAD
        public static bool IsError(this Result result)
        {
            // Only negative result codes are errors.
            return result < Result.Success;
        }

        public static void ThrowOnError(this Result result)
        {
            // Only negative result codes are errors.
            if (result.IsError())
=======
        public static void ThrowOnError(this Result result)
        {
            // Only negative result codes are errors.
            if ((int)result < (int)Result.Success)
>>>>>>> 1ec71635b (sync with main branch)
            {
                throw new VulkanException(result);
            }
        }
    }

    class VulkanException : Exception
    {
        public VulkanException()
        {
        }

        public VulkanException(Result result) : base($"Unexpected API error \"{result}\".")
        {
        }

        public VulkanException(string message) : base(message)
        {
        }

        public VulkanException(string message, Exception innerException) : base(message, innerException)
        {
        }
<<<<<<< HEAD
=======

        protected VulkanException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
