namespace Ryujinx.HLE.HOS.Tamper.Operations
{
    class OpProcCtrl : IOperation
    {
<<<<<<< HEAD
        private readonly ITamperedProcess _process;
        private readonly bool _pause;
=======
        private ITamperedProcess _process;
        private bool _pause;
>>>>>>> 1ec71635b (sync with main branch)

        public OpProcCtrl(ITamperedProcess process, bool pause)
        {
            _process = process;
            _pause = pause;
        }

        public void Execute()
        {
            if (_pause)
            {
                _process.PauseProcess();
            }
            else
            {
                _process.ResumeProcess();
            }
        }
    }
}
