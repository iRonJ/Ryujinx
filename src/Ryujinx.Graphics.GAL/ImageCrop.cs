namespace Ryujinx.Graphics.GAL
{
    public readonly struct ImageCrop
    {
<<<<<<< HEAD
        public int Left { get; }
        public int Right { get; }
        public int Top { get; }
        public int Bottom { get; }
        public bool FlipX { get; }
        public bool FlipY { get; }
        public bool IsStretched { get; }
=======
        public int   Left         { get; }
        public int   Right        { get; }
        public int   Top          { get; }
        public int   Bottom       { get; }
        public bool  FlipX        { get; }
        public bool  FlipY        { get; }
        public bool  IsStretched  { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public float AspectRatioX { get; }
        public float AspectRatioY { get; }

        public ImageCrop(
<<<<<<< HEAD
            int left,
            int right,
            int top,
            int bottom,
            bool flipX,
            bool flipY,
            bool isStretched,
            float aspectRatioX,
            float aspectRatioY)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
            FlipX = flipX;
            FlipY = flipY;
            IsStretched = isStretched;
=======
            int   left,
            int   right,
            int   top,
            int   bottom,
            bool  flipX,
            bool  flipY,
            bool  isStretched,
            float aspectRatioX,
            float aspectRatioY)
        {
            Left         = left;
            Right        = right;
            Top          = top;
            Bottom       = bottom;
            FlipX        = flipX;
            FlipY        = flipY;
            IsStretched  = isStretched;
>>>>>>> 1ec71635b (sync with main branch)
            AspectRatioX = aspectRatioX;
            AspectRatioY = aspectRatioY;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
