# DotNet.Misc
[![Build Status](https://carlubian.visualstudio.com/DotNet.Misc/_apis/build/status/DotNet.Misc%20Build)](https://carlubian.visualstudio.com/DotNet.Misc/_build/latest?definitionId=16)

This repository contains several minor libraries providing utility and convenience.

## DotNet.Misc.Collections
Injects a new class <strong>LenientDictionary&lt;TKey, TValue&gt;</strong> into the System.Collections.Generic namespace.

A LenientDictionary behaves as a regular Dictionary, but offers a more <em>lenient</em> operation:
* Calls to .Add() when the key is already present in the LenientDictionary won't throw an exception. Instead, the value will be overwrittem.
* Using the indexer to get an element whose key is not present in the LenientDictionary won't throw an exception. Instead, a default value will be returned.

Additionally, the .ContainsValue() method is addded as an extension for IDictionary&lt;TKey, TValue&gt;, having a similar behaviour as the standard .ContainsKey().

## DotNet.Misc.Security
Simplifies data encryption and decryption, removing the need to handle byte arrays, memory slices and other low level implementation details.

Instead, a call to <strong>Simply.Encrypt("Secret")</strong> will return a piece of encrypted data that can then be decrypted or stored securely. To decrypt it, use <strong>Simply.Decrypt(data)</strong>.

To operate with a custom password, use the IDisposable <strong>Password</strong> class:

<pre>using(new Password("H3lloK1tty"))
{
    var secure = Simply.Encrypt("secret message");
}</pre>

## DotNet.Misc.Extensions
Offers utility extension methods:
* IEnumerable.ForEach: Execute an action on every element in the sequence, consuming them.
* IEnumerable.Peek: Execute an action on every element in the sequence, without consuming them.
* T.Generate: Produce an infinite sequence from an object and a generator function.
* T.Enumerate: Produce a sequence with a single element in it.
* IEnumerable.Stringify: Convert a sequence into a string, with an optional separator.
* IEnumerable.Random: Return a random element within the sequence.
