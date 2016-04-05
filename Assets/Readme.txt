To be able to build for Windows Phone 8, you have to extract the content of this archive to the root /Assets/ folder.

Using Unity 5 you have to set the /Assets/TcpClientImplementation.dll's platforms to all but WP8Player using the Plugin Inspector(http://docs.unity3d.com/Manual/PluginInspector.html).
For /Assets/WP8/TcpClientImplementation.dll you may also have to set the 'Placeholder' to /Assets/TcpClientImplementation.dll.