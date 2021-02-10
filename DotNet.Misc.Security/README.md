# DotNet.Misc
[![Build Status](https://carlubian.visualstudio.com/DotNet.Misc/_apis/build/status/DotNet.Misc%20Build)](https://carlubian.visualstudio.com/DotNet.Misc/_build/latest?definitionId=16)

This repository contains several minor libraries providing utility and convenience.

## DotNet.Misc.Security
Simplifies data encryption and decryption, removing the need to handle byte arrays, memory slices and other low level implementation details.

Instead, a call to <strong>Simply.Encrypt("Secret")</strong> will return a piece of encrypted data that can then be decrypted or stored securely. To decrypt it, use <strong>Simply.Decrypt(data)</strong>.

To operate with a custom password, use the IDisposable <strong>Password</strong> class:

<pre>using(new Password("H3lloK1tty"))
{
    var secure = Simply.Encrypt("secret message");
}</pre>

Note that using a custom password is highly encouraged.
