using Microsoft.Win32.SafeHandles;
using Ryujinx.Common.Logging;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

namespace Ryujinx.Common.SystemInterop
{
    public partial class StdErrAdapter : IDisposable
    {
<<<<<<< HEAD
        private bool _disposable;
=======
        private bool _disposable = false;
>>>>>>> 1ec71635b (sync with main branch)
        private Stream _pipeReader;
        private Stream _pipeWriter;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _worker;

        public StdErrAdapter()
        {
            if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
            {
                RegisterPosix();
            }
        }

        [SupportedOSPlatform("linux")]
        [SupportedOSPlatform("macos")]
        private void RegisterPosix()
        {
<<<<<<< HEAD
            const int StdErrFileno = 2;

            (int readFd, int writeFd) = MakePipe();
            dup2(writeFd, StdErrFileno);
=======
            const int stdErrFileno = 2;

            (int readFd, int writeFd) = MakePipe();
            dup2(writeFd, stdErrFileno);
>>>>>>> 1ec71635b (sync with main branch)

            _pipeReader = CreateFileDescriptorStream(readFd);
            _pipeWriter = CreateFileDescriptorStream(writeFd);

            _cancellationTokenSource = new CancellationTokenSource();
            _worker = Task.Run(async () => await EventWorkerAsync(_cancellationTokenSource.Token), _cancellationTokenSource.Token);
            _disposable = true;
        }
<<<<<<< HEAD

=======
        
>>>>>>> 1ec71635b (sync with main branch)
        [SupportedOSPlatform("linux")]
        [SupportedOSPlatform("macos")]
        private async Task EventWorkerAsync(CancellationToken cancellationToken)
        {
            using TextReader reader = new StreamReader(_pipeReader, leaveOpen: true);
            string line;
            while (cancellationToken.IsCancellationRequested == false && (line = await reader.ReadLineAsync(cancellationToken)) != null)
            {
                Logger.Error?.PrintRawMsg(line);
            }
        }
<<<<<<< HEAD

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            if (_disposable)
            {
                _disposable = false;

=======
        
        private void Dispose(bool disposing)
        {
            if (_disposable)
            {
                _disposable = false;
                
>>>>>>> 1ec71635b (sync with main branch)
                if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                {
                    _cancellationTokenSource.Cancel();
                    _worker.Wait(0);
                    _pipeReader?.Close();
                    _pipeWriter?.Close();
                }
            }
        }

<<<<<<< HEAD
=======
        public void Dispose()
        {
            Dispose(true);
        }

>>>>>>> 1ec71635b (sync with main branch)
        [LibraryImport("libc", SetLastError = true)]
        private static partial int dup2(int fd, int fd2);

        [LibraryImport("libc", SetLastError = true)]
        private static partial int pipe(Span<int> pipefd);

        private static (int, int) MakePipe()
        {
<<<<<<< HEAD
            Span<int> pipefd = stackalloc int[2];
=======
            Span<int> pipefd = stackalloc int[2]; 
>>>>>>> 1ec71635b (sync with main branch)

            if (pipe(pipefd) == 0)
            {
                return (pipefd[0], pipefd[1]);
            }
<<<<<<< HEAD

            throw new();
        }

=======
            else
            {
                throw new();
            }
        }
        
>>>>>>> 1ec71635b (sync with main branch)
        [SupportedOSPlatform("linux")]
        [SupportedOSPlatform("macos")]
        private static Stream CreateFileDescriptorStream(int fd)
        {
            return new FileStream(
<<<<<<< HEAD
                new SafeFileHandle(fd, ownsHandle: true),
                FileAccess.ReadWrite
            );
        }

=======
                new SafeFileHandle((IntPtr)fd, ownsHandle: true),
                FileAccess.ReadWrite
            );
        }
       
>>>>>>> 1ec71635b (sync with main branch)
    }
}
