using Ryujinx.Graphics.Shader.Decoders;
using Ryujinx.Graphics.Shader.Translation;

namespace Ryujinx.Graphics.Shader.Instructions
{
    static partial class InstEmit
    {
        public static void AtomCas(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstAtomCas>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction AtomCas is not implemented.");
=======
            InstAtomCas op = context.GetOp<InstAtomCas>();

            context.Config.GpuAccessor.Log("Shader instruction AtomCas is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void AtomsCas(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstAtomsCas>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction AtomsCas is not implemented.");
=======
            InstAtomsCas op = context.GetOp<InstAtomsCas>();

            context.Config.GpuAccessor.Log("Shader instruction AtomsCas is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void B2r(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstB2r>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction B2r is not implemented.");
=======
            InstB2r op = context.GetOp<InstB2r>();

            context.Config.GpuAccessor.Log("Shader instruction B2r is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Bpt(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstBpt>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Bpt is not implemented.");
=======
            InstBpt op = context.GetOp<InstBpt>();

            context.Config.GpuAccessor.Log("Shader instruction Bpt is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Cctl(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstCctl>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Cctl is not implemented.");
=======
            InstCctl op = context.GetOp<InstCctl>();

            context.Config.GpuAccessor.Log("Shader instruction Cctl is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Cctll(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstCctll>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Cctll is not implemented.");
=======
            InstCctll op = context.GetOp<InstCctll>();

            context.Config.GpuAccessor.Log("Shader instruction Cctll is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Cctlt(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstCctlt>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Cctlt is not implemented.");
=======
            InstCctlt op = context.GetOp<InstCctlt>();

            context.Config.GpuAccessor.Log("Shader instruction Cctlt is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Cs2r(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstCs2r>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Cs2r is not implemented.");
=======
            InstCs2r op = context.GetOp<InstCs2r>();

            context.Config.GpuAccessor.Log("Shader instruction Cs2r is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void FchkR(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstFchkR>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction FchkR is not implemented.");
=======
            InstFchkR op = context.GetOp<InstFchkR>();

            context.Config.GpuAccessor.Log("Shader instruction FchkR is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void FchkI(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstFchkI>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction FchkI is not implemented.");
=======
            InstFchkI op = context.GetOp<InstFchkI>();

            context.Config.GpuAccessor.Log("Shader instruction FchkI is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void FchkC(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstFchkC>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction FchkC is not implemented.");
=======
            InstFchkC op = context.GetOp<InstFchkC>();

            context.Config.GpuAccessor.Log("Shader instruction FchkC is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Getcrsptr(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstGetcrsptr>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Getcrsptr is not implemented.");
=======
            InstGetcrsptr op = context.GetOp<InstGetcrsptr>();

            context.Config.GpuAccessor.Log("Shader instruction Getcrsptr is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Getlmembase(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstGetlmembase>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Getlmembase is not implemented.");
=======
            InstGetlmembase op = context.GetOp<InstGetlmembase>();

            context.Config.GpuAccessor.Log("Shader instruction Getlmembase is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Ide(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstIde>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Ide is not implemented.");
=======
            InstIde op = context.GetOp<InstIde>();

            context.Config.GpuAccessor.Log("Shader instruction Ide is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void IdpR(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstIdpR>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction IdpR is not implemented.");
=======
            InstIdpR op = context.GetOp<InstIdpR>();

            context.Config.GpuAccessor.Log("Shader instruction IdpR is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void IdpC(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstIdpC>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction IdpC is not implemented.");
=======
            InstIdpC op = context.GetOp<InstIdpC>();

            context.Config.GpuAccessor.Log("Shader instruction IdpC is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void ImadspR(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstImadspR>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction ImadspR is not implemented.");
=======
            InstImadspR op = context.GetOp<InstImadspR>();

            context.Config.GpuAccessor.Log("Shader instruction ImadspR is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void ImadspI(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstImadspI>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction ImadspI is not implemented.");
=======
            InstImadspI op = context.GetOp<InstImadspI>();

            context.Config.GpuAccessor.Log("Shader instruction ImadspI is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void ImadspC(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstImadspC>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction ImadspC is not implemented.");
=======
            InstImadspC op = context.GetOp<InstImadspC>();

            context.Config.GpuAccessor.Log("Shader instruction ImadspC is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void ImadspRc(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstImadspRc>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction ImadspRc is not implemented.");
=======
            InstImadspRc op = context.GetOp<InstImadspRc>();

            context.Config.GpuAccessor.Log("Shader instruction ImadspRc is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Jcal(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstJcal>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Jcal is not implemented.");
=======
            InstJcal op = context.GetOp<InstJcal>();

            context.Config.GpuAccessor.Log("Shader instruction Jcal is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Jmp(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstJmp>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Jmp is not implemented.");
=======
            InstJmp op = context.GetOp<InstJmp>();

            context.Config.GpuAccessor.Log("Shader instruction Jmp is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Jmx(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstJmx>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Jmx is not implemented.");
=======
            InstJmx op = context.GetOp<InstJmx>();

            context.Config.GpuAccessor.Log("Shader instruction Jmx is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Ld(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstLd>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Ld is not implemented.");
=======
            InstLd op = context.GetOp<InstLd>();

            context.Config.GpuAccessor.Log("Shader instruction Ld is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Lepc(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstLepc>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Lepc is not implemented.");
=======
            InstLepc op = context.GetOp<InstLepc>();

            context.Config.GpuAccessor.Log("Shader instruction Lepc is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Longjmp(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstLongjmp>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Longjmp is not implemented.");
=======
            InstLongjmp op = context.GetOp<InstLongjmp>();

            context.Config.GpuAccessor.Log("Shader instruction Longjmp is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Pexit(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstPexit>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Pexit is not implemented.");
=======
            InstPexit op = context.GetOp<InstPexit>();

            context.Config.GpuAccessor.Log("Shader instruction Pexit is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Pixld(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstPixld>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Pixld is not implemented.");
=======
            InstPixld op = context.GetOp<InstPixld>();

            context.Config.GpuAccessor.Log("Shader instruction Pixld is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Plongjmp(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstPlongjmp>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Plongjmp is not implemented.");
=======
            InstPlongjmp op = context.GetOp<InstPlongjmp>();

            context.Config.GpuAccessor.Log("Shader instruction Plongjmp is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Pret(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstPret>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Pret is not implemented.");
=======
            InstPret op = context.GetOp<InstPret>();

            context.Config.GpuAccessor.Log("Shader instruction Pret is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void PrmtR(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstPrmtR>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction PrmtR is not implemented.");
=======
            InstPrmtR op = context.GetOp<InstPrmtR>();

            context.Config.GpuAccessor.Log("Shader instruction PrmtR is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void PrmtI(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstPrmtI>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction PrmtI is not implemented.");
=======
            InstPrmtI op = context.GetOp<InstPrmtI>();

            context.Config.GpuAccessor.Log("Shader instruction PrmtI is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void PrmtC(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstPrmtC>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction PrmtC is not implemented.");
=======
            InstPrmtC op = context.GetOp<InstPrmtC>();

            context.Config.GpuAccessor.Log("Shader instruction PrmtC is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void PrmtRc(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstPrmtRc>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction PrmtRc is not implemented.");
=======
            InstPrmtRc op = context.GetOp<InstPrmtRc>();

            context.Config.GpuAccessor.Log("Shader instruction PrmtRc is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void R2b(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstR2b>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction R2b is not implemented.");
=======
            InstR2b op = context.GetOp<InstR2b>();

            context.Config.GpuAccessor.Log("Shader instruction R2b is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Ram(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstRam>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Ram is not implemented.");
=======
            InstRam op = context.GetOp<InstRam>();

            context.Config.GpuAccessor.Log("Shader instruction Ram is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Rtt(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstRtt>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Rtt is not implemented.");
=======
            InstRtt op = context.GetOp<InstRtt>();

            context.Config.GpuAccessor.Log("Shader instruction Rtt is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Sam(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstSam>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Sam is not implemented.");
=======
            InstSam op = context.GetOp<InstSam>();

            context.Config.GpuAccessor.Log("Shader instruction Sam is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Setcrsptr(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstSetcrsptr>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Setcrsptr is not implemented.");
=======
            InstSetcrsptr op = context.GetOp<InstSetcrsptr>();

            context.Config.GpuAccessor.Log("Shader instruction Setcrsptr is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Setlmembase(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstSetlmembase>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Setlmembase is not implemented.");
=======
            InstSetlmembase op = context.GetOp<InstSetlmembase>();

            context.Config.GpuAccessor.Log("Shader instruction Setlmembase is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void St(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstSt>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction St is not implemented.");
=======
            InstSt op = context.GetOp<InstSt>();

            context.Config.GpuAccessor.Log("Shader instruction St is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Stp(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstStp>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Stp is not implemented.");
=======
            InstStp op = context.GetOp<InstStp>();

            context.Config.GpuAccessor.Log("Shader instruction Stp is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Txa(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstTxa>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Txa is not implemented.");
=======
            InstTxa op = context.GetOp<InstTxa>();

            context.Config.GpuAccessor.Log("Shader instruction Txa is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Vabsdiff(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstVabsdiff>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Vabsdiff is not implemented.");
=======
            InstVabsdiff op = context.GetOp<InstVabsdiff>();

            context.Config.GpuAccessor.Log("Shader instruction Vabsdiff is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Vabsdiff4(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstVabsdiff4>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Vabsdiff4 is not implemented.");
=======
            InstVabsdiff4 op = context.GetOp<InstVabsdiff4>();

            context.Config.GpuAccessor.Log("Shader instruction Vabsdiff4 is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Vadd(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstVadd>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Vadd is not implemented.");
=======
            InstVadd op = context.GetOp<InstVadd>();

            context.Config.GpuAccessor.Log("Shader instruction Vadd is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Votevtg(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstVotevtg>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Votevtg is not implemented.");
=======
            InstVotevtg op = context.GetOp<InstVotevtg>();

            context.Config.GpuAccessor.Log("Shader instruction Votevtg is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Vset(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstVset>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Vset is not implemented.");
=======
            InstVset op = context.GetOp<InstVset>();

            context.Config.GpuAccessor.Log("Shader instruction Vset is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Vshl(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstVshl>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Vshl is not implemented.");
=======
            InstVshl op = context.GetOp<InstVshl>();

            context.Config.GpuAccessor.Log("Shader instruction Vshl is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Vshr(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstVshr>();

            context.TranslatorContext.GpuAccessor.Log("Shader instruction Vshr is not implemented.");
        }
    }
}
=======
            InstVshr op = context.GetOp<InstVshr>();

            context.Config.GpuAccessor.Log("Shader instruction Vshr is not implemented.");
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
