using System;
using System.Collections.Generic;
using System.Text;

namespace GifUtility
{
    public class GifExtensions
    {
        public const byte ExtensionIntroducer = 0x21;
        public const byte Terminator = 0;
        public const byte ApplicationExtensionLabel = 0xFF;
        public const byte CommentLabel = 0xFE;
        public const byte ImageDescriptorLabel = 0x2C;
        public const byte PlainTextLabel = 0x01;
        public const byte GraphicControlLabel = 0xF9;
        public const byte ImageLabel = 0x2C;
        public const byte EndIntroducer = 0x3B;
    }
}
