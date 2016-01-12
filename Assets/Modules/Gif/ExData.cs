namespace GifUtility
{
    public class ExData
    {
        private static readonly byte _extensionIntroducer = 0x21;
        private static readonly byte _blockTerminator = 0;

        internal byte ExtensionIntroducer {
            get { return _extensionIntroducer; }
        }

        internal byte BlockTerminator
        {
            get { return _blockTerminator; }
        }
    }
}