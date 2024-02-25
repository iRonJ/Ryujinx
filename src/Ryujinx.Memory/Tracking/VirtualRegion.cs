<<<<<<< HEAD
using Ryujinx.Memory.Range;
=======
﻿using Ryujinx.Memory.Range;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;

namespace Ryujinx.Memory.Tracking
{
    /// <summary>
    /// A region of virtual memory.
    /// </summary>
    class VirtualRegion : AbstractRegion
    {
<<<<<<< HEAD
        public List<RegionHandle> Handles = new();
=======
        public List<RegionHandle> Handles = new List<RegionHandle>();
>>>>>>> 1ec71635b (sync with main branch)

        private readonly MemoryTracking _tracking;
        private MemoryPermission _lastPermission;

        public VirtualRegion(MemoryTracking tracking, ulong address, ulong size, MemoryPermission lastPermission = MemoryPermission.Invalid) : base(address, size)
        {
            _lastPermission = lastPermission;
            _tracking = tracking;
        }

        /// <inheritdoc/>
        public override void Signal(ulong address, ulong size, bool write, int? exemptId)
        {
            IList<RegionHandle> handles = Handles;

            for (int i = 0; i < handles.Count; i++)
            {
                if (exemptId == null || handles[i].Id != exemptId.Value)
                {
                    handles[i].Signal(address, size, write, ref handles);
                }
            }

            UpdateProtection();
        }

        /// <inheritdoc/>
        public override void SignalPrecise(ulong address, ulong size, bool write, int? exemptId)
        {
            IList<RegionHandle> handles = Handles;

            bool allPrecise = true;

            for (int i = 0; i < handles.Count; i++)
            {
                if (exemptId == null || handles[i].Id != exemptId.Value)
                {
                    allPrecise &= handles[i].SignalPrecise(address, size, write, ref handles);
                }
            }

            // Only update protection if a regular signal handler was called.
            // This allows precise actions to skip reprotection costs if they want (they can still do it manually).
            if (!allPrecise)
            {
                UpdateProtection();
            }
        }

        /// <summary>
        /// Signal that this region has been mapped or unmapped.
        /// </summary>
        /// <param name="mapped">True if the region has been mapped, false if unmapped</param>
        public void SignalMappingChanged(bool mapped)
        {
            _lastPermission = MemoryPermission.Invalid;

            foreach (RegionHandle handle in Handles)
            {
                handle.SignalMappingChanged(mapped);
            }
        }

        /// <summary>
        /// Gets the strictest permission that the child handles demand. Assumes that the tracking lock has been obtained.
        /// </summary>
        /// <returns>Protection level that this region demands</returns>
        public MemoryPermission GetRequiredPermission()
        {
            // Start with Read/Write, each handle can strip off permissions as necessary.
            // Assumes the tracking lock has already been obtained.

            MemoryPermission result = MemoryPermission.ReadAndWrite;

            foreach (var handle in Handles)
            {
                result &= handle.RequiredPermission;
<<<<<<< HEAD
                if (result == 0)
                {
                    return result;
                }
=======
                if (result == 0) return result;
>>>>>>> 1ec71635b (sync with main branch)
            }
            return result;
        }

        /// <summary>
        /// Updates the protection for this virtual region.
        /// </summary>
        public bool UpdateProtection()
        {
            MemoryPermission permission = GetRequiredPermission();

            if (_lastPermission != permission)
            {
                _tracking.ProtectVirtualRegion(this, permission);
                _lastPermission = permission;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes a handle from this virtual region. If there are no handles left, this virtual region is removed.
        /// </summary>
        /// <param name="handle">Handle to remove</param>
        public void RemoveHandle(RegionHandle handle)
        {
            lock (_tracking.TrackingLock)
            {
                Handles.Remove(handle);
                UpdateProtection();
                if (Handles.Count == 0)
                {
                    _tracking.RemoveVirtual(this);
                }
            }
        }

        public override INonOverlappingRange Split(ulong splitAddress)
        {
<<<<<<< HEAD
            VirtualRegion newRegion = new(_tracking, splitAddress, EndAddress - splitAddress, _lastPermission);
=======
            VirtualRegion newRegion = new VirtualRegion(_tracking, splitAddress, EndAddress - splitAddress, _lastPermission);
>>>>>>> 1ec71635b (sync with main branch)
            Size = splitAddress - Address;

            // The new region inherits all of our parents.
            newRegion.Handles = new List<RegionHandle>(Handles);
            foreach (var parent in Handles)
            {
                parent.AddChild(newRegion);
            }

            return newRegion;
        }
    }
}
