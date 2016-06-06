using UnityEngine;
using System.Collections;

public class AssetsRepository{

#if PRE
    public static string url { get { return "https://az879424.vo.msecnd.net/virtualtour-assets"; } }
#elif PRO
    public static string url { get { return "https://az878819.vo.msecnd.net/virtualtour-assets"; } }
        AssetsUrl = "";
#else
    public static string url { get { return "https://rmdevcdntour.blob.core.windows.net/virtualtour-assets"; } }
#endif
}
